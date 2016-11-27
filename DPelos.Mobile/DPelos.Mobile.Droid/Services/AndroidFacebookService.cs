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

		public Task<DPelos.Mobile.Models.Profile> GetProfile()
		{
			TaskCompletionSource<DPelos.Mobile.Models.Profile> task = new TaskCompletionSource<DPelos.Mobile.Models.Profile>();

			var request = GraphRequest.NewMeRequest(Xamarin.Facebook.AccessToken.CurrentAccessToken, new GraphJSONObjectCallback
			{
				Completed = (obj, response) =>
				{
					var result = new DPelos.Mobile.Models.Profile
					{
						Name = obj.GetString("name"),
						Email = obj.GetString("email"),
						Picture = obj.GetJSONObject("picture").GetJSONObject("data").GetString("url"),
					};
					task.SetResult(result);
				},
			});

			request.Parameters = new Bundle();
			request.Parameters.PutString("fields", "name,email,picture.type(large)");
			request.ExecuteAsync();
			return task.Task;
		}
	}
}