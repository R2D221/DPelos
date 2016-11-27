using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.Services;
using Xamarin.Forms;

namespace DPelos.Mobile
{
	public class App : Application
	{
		public static AzureDataService AzureService;
		public static IFacebookService FacebookService;

		public static Action<string> PostSuccessFacebookAction { get; set; }

		public App()
		{
			AzureService = new AzureDataService();

			if (Application.Current.Properties.ContainsKey("userId"))
			{
				switch ((string)Application.Current.Properties["TipoUsuario"])
				{
					case "Veterinario":
						MainPage = new Views.Vet.MainPage();
						break;
					case "Cliente":
						MainPage = new Views.Client.MainPage();
						break;
					case "Indefinido":
						MainPage = new Views.ChooseAccountTypePage();
						break;
				}
			}
			else
			{
				MainPage = new Views.LoginPage();
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
