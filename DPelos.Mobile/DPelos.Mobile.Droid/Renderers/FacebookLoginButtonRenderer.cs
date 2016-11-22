using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using DPelos.Mobile;
using DPelos.Mobile.Droid.Renderers;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRenderer))]

namespace DPelos.Mobile.Droid.Renderers
{
	public class FacebookLoginButtonRenderer : ViewRenderer<FacebookLoginButton, LoginButton>
	{
		private static Activity _activity;

		protected override void OnElementChanged(ElementChangedEventArgs<FacebookLoginButton> e)
		{
			base.OnElementChanged(e);

			_activity = this.Context as MainActivity;
			var loginButton = new LoginButton(this.Context);
			var facebookCallback = new FacebookCallback<LoginResult>
			{
				HandleSuccess = shareResult =>
				{
					App.PostSuccessFacebookAction?.Invoke(shareResult.AccessToken.Token);
				},
				HandleCancel = () =>
				{
					Console.WriteLine("HelloFacebook: Canceled");
				},
				HandleError = shareError =>
				{
					Console.WriteLine("HelloFacebook: Error: {0}", shareError);
				}
			};
			loginButton.RegisterCallback(MainActivity.CallbackManager, facebookCallback);
			base.SetNativeControl(loginButton);
		}
	}
}