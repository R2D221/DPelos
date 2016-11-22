using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook;

namespace DPelos.Mobile.Droid.Renderers
{
	public class FacebookCallback<TResult> : Java.Lang.Object, IFacebookCallback where TResult : Java.Lang.Object
	{
		public Action HandleCancel { get; set; }
		public Action<FacebookException> HandleError { get; set; }
		public Action<TResult> HandleSuccess { get; set; }

		public void OnCancel()
		{
			HandleCancel?.Invoke();
		}

		public void OnError(FacebookException error)
		{
			HandleError?.Invoke(error);
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			HandleSuccess?.Invoke(result.JavaCast<TResult>());
		}
	}
}