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
using Org.Json;
using Xamarin.Facebook;
using static Xamarin.Facebook.GraphRequest;

namespace DPelos.Mobile.Droid.Interfaces
{
	public class GraphJSONObjectCallback : Java.Lang.Object, IGraphJSONObjectCallback
	{
		public Action<JSONObject, GraphResponse> Completed { get; set; }
		public void OnCompleted(JSONObject p0, GraphResponse p1)
		{
			Completed?.Invoke(p0, p1);
		}
	}
}