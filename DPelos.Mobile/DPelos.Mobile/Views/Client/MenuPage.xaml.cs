using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.Models;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Client
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
			await masterDetailPage.Detail.Navigation.PushAsync(new Views.Client.DogsListPage());
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
