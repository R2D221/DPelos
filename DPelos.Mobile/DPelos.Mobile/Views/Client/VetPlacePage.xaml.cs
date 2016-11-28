using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using DPelos.Mobile.Services;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DPelos.Mobile.Views.Client
{
	public partial class VetPlacePage : ContentPage
	{
		public VetPlacePage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var locator = CrossGeolocator.Current;

			var position = await locator.GetPositionAsync(10000);

			Map.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					new Position(position.Latitude, position.Longitude),
					Distance.FromKilometers(0.5)
				)
			);

			var lugares = await App.AzureService.ObtenerLugaresVeterinarias();

			foreach (var lugar in lugares)
			{
				Map.Pins.Add(new Pin
				{
					Label = lugar.Nombre ?? "",
					Address = lugar.Direccion,
					Position = new Position(lugar.Latitud, lugar.Longitud),
				});
			}
		}
	}
}
