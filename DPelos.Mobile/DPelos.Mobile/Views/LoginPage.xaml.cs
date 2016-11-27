using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile.Views
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			App.PostSuccessFacebookAction = token =>
			{
				Task.Run(async () =>
				{
					var profile = await App.FacebookService.GetProfile();
					var usuario = await App.AzureService.ObtenerOCrearUsuario(profile);

					Application.Current.Properties["userId"] = usuario.Id;
					Application.Current.Properties["Nombre"] = profile.Name;
					Application.Current.Properties["Email"] = profile.Email;
					Application.Current.Properties["Foto"] = profile.Picture;

					switch (usuario.Tipo)
					{
						case 1:
							Application.Current.Properties["TipoUsuario"] = "Veterinario";
							Device.BeginInvokeOnMainThread(() =>
							{
								Application.Current.MainPage = new Views.Vet.MainPage();
							});
							break;
						case 2:
							Application.Current.Properties["TipoUsuario"] = "Cliente";
							Device.BeginInvokeOnMainThread(() =>
							{
								Application.Current.MainPage = new Views.Client.MainPage();
							});
							break;
						default:
							Application.Current.Properties["TipoUsuario"] = "Indefinido";
							Device.BeginInvokeOnMainThread(() =>
							{
								Application.Current.MainPage = new Views.ChooseAccountTypePage();
							});
							break;
					}
				});
			};
		}


		private void LoginFacebook(object sender, EventArgs e)
		{

		}

		void Login(object sender, EventArgs e)
		{
			Application.Current.MainPage = new MainPage();
		}

	}

}
