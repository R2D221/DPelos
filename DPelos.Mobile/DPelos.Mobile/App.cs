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

		public App()
		{
			MainPage = new LoginPage();
			AzureService = new AzureDataService();
			MainPage = new NavigationPage(new AddDog());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
			Task.Run(() => AzureService.Initialize());
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
