using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			App.PostSuccessFacebookAction = async token =>
			{
				var result = await App.FacebookService.GetProfile();
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

	public class FacebookLoginButton : Button
	{

	}

}
