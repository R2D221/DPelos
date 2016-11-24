using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DPelos.Mobile.Droid.Interfaces;
using DPelos.Mobile.Services;
using Xamarin.Facebook;

namespace DPelos.Mobile.Droid.Services
{
	public class AndroidFacebookService : IFacebookService
	{
		public string AccessToken => Xamarin.Facebook.AccessToken.CurrentAccessToken?.Token;

		public Task<object> GetProfile()
		{
			TaskCompletionSource<object> task = new TaskCompletionSource<object>();

			GraphRequest.NewMeRequest(Xamarin.Facebook.AccessToken.CurrentAccessToken, new GraphJSONObjectCallback
			{
				Completed = (obj, response) =>
				{
					task.SetResult(obj);
				},
			});

			return task.Task;
		}
	}
}