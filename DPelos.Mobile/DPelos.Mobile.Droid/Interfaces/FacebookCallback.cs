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

namespace DPelos.Mobile.Droid.Interfaces
{
	public class FacebookCallback<TResult> : Java.Lang.Object, IFacebookCallback where TResult : Java.Lang.Object
	{
		public Action Cancel { get; set; }
		public Action<FacebookException> Error { get; set; }
		public Action<TResult> Success { get; set; }

		public void OnCancel()
		{
			Cancel?.Invoke();
		}

		public void OnError(FacebookException error)
		{
			Error?.Invoke(error);
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			Success?.Invoke(result.JavaCast<TResult>());
		}
	}
}