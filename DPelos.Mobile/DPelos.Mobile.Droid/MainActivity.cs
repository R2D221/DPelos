using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook;
using DPelos.Mobile.Droid.Services;
using Android.Content;

[assembly: UsesPermission (Android.Manifest.Permission.Flashlight)]

namespace DPelos.Mobile.Droid
{
	[Activity(Label = "DPelos.Mobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		public static ICallbackManager CallbackManager = CallbackManagerFactory.Create();
		public static readonly string[] PERMISSIONS = { };

		protected override void OnCreate(Bundle savedInstanceState)
		{
			ZXing.Net.Mobile.Forms.Android.Platform.Init(); 

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			// Initialize Azure Mobile Apps
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
			FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);

			FacebookSdk.SdkInitialize(this.ApplicationContext);

			App.FacebookService = new AndroidFacebookService();

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			Xamarin.FormsMaps.Init(this, savedInstanceState);
			LoadApplication(new App());
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}

