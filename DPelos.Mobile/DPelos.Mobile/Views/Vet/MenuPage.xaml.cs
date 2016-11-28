using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.Models;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace DPelos.Mobile.Views.Vet
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
			BindingContext = new Profile
			{
				Name = (string)Application.Current.Properties["Nombre"],
				Email = (string)Application.Current.Properties["Email"],
				Picture = (string)Application.Current.Properties["Foto"],
			};
		}
	
		async void HistorialClinico(object s, EventArgs e)
		{
			var masterDetailPage = (MasterDetailPage)Parent;
			masterDetailPage.IsPresented = false;
			await masterDetailPage.Detail.Navigation.PushAsync(new Views.Vet.DogsListPage());
		}

		async void LeerQR(object s, EventArgs e)
		{
			var scanner = new ZXingScannerPage(new MobileBarcodeScanningOptions
			{
				PossibleFormats = { ZXing.BarcodeFormat.QR_CODE }
			});
			scanner.OnScanResult += (result) =>
			{
				// Stop scanning
				scanner.IsScanning = false;

				// Pop the page and show the result
				Device.BeginInvokeOnMainThread(async () =>
				{
					await Navigation.PopModalAsync(); //result.Text
					await App.AzureService.AgregarPerroAVeterinario(result.Text, (string)Application.Current.Properties["userId"]);

					var masterDetailPage = (MasterDetailPage)Parent;
					masterDetailPage.IsPresented = false;
					await masterDetailPage.Detail.Navigation.PushAsync(new Views.Vet.DogsListPage());
				});
			};
			await Navigation.PushModalAsync(scanner);
		}

		async void CerrarSesion(object s, EventArgs e)
		{
			App.FacebookService.Logout();
			await App.AzureService.Purge();
			Application.Current.Properties.Remove("userId");
			Application.Current.Properties.Remove("Nombre");
			Application.Current.Properties.Remove("Email");
			Application.Current.Properties.Remove("Foto");
			Application.Current.Properties.Remove("TipoUsuario");
			Application.Current.MainPage = new LoginPage();
		}
	}
}
