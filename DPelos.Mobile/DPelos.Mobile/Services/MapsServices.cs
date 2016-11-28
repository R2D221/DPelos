using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DPelos.Mobile.Services
{
	public class MapsServices
	{
		static HttpClient client;

		static MapsServices()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public static async Task<Tuple<double, double>> GetCoordinatesForAddress(string address)
		{
			var uri = new Uri($@"https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyA5h_H5l8DR6IB2qqk8a9mWysId_jEi_kk&region=mx&address={System.Net.WebUtility.UrlEncode(address)}");

			var responseMessage = await client.GetAsync(uri);

			if (!responseMessage.IsSuccessStatusCode) return null;

			var response = JsonConvert.DeserializeObject<dynamic>(await responseMessage.Content.ReadAsStringAsync());

			var location = response.results[0].geometry.location;

			return Tuple.Create((double)location.lat, (double)location.lng);
		}
	}
}
