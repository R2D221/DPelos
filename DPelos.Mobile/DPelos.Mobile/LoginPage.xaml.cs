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
		}


		 private void LoginFacebook(object sender, EventArgs e)
		{
			
		}

		void Login(object sender, EventArgs e)
		{
			App.Current.MainPage = new MainPage();
		}

	}

}
