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

namespace DPelos.Mobile.Views.Vet
{
	public partial class VetPlacePage : ContentPage
	{
		LugarVeterinaria lugarVeterinaria;
		Pin pin;

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

			lugarVeterinaria = await App.AzureService.ObtenerLugarVeterinaria((string)Application.Current.Properties["userId"]);
			NameEntry.Text = lugarVeterinaria.Nombre;
			AddressEntry.Text = lugarVeterinaria.Direccion;
			ActualizarPin();
		}

		void ActualizarPin()
		{
			if (pin != null)
				Map.Pins.Remove(pin);

			pin = null;

			if (lugarVeterinaria.EsVisible)
			{
				pin = new Pin
				{
					Label = lugarVeterinaria.Nombre ?? "",
					Address = lugarVeterinaria.Direccion,
					Position = new Position(lugarVeterinaria.Latitud, lugarVeterinaria.Longitud),
				};
				Map.Pins.Add(pin);
			}
		}

		async void Search(object s, EventArgs e)
		{
			var address = AddressEntry.Text;
			var coordinates = await MapsServices.GetCoordinatesForAddress(address);

			if (coordinates == null) return;

			lugarVeterinaria.Latitud = coordinates.Item1;
			lugarVeterinaria.Longitud = coordinates.Item2;
			ActualizarPin();

			Map.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					new Position(lugarVeterinaria.Latitud, lugarVeterinaria.Longitud),
					Distance.FromKilometers(0.5)
				)
			);
		}

		async void Save(object s, EventArgs e)
		{
			lugarVeterinaria.Nombre = NameEntry.Text;
			lugarVeterinaria.Direccion = AddressEntry.Text;
			await App.AzureService.GuardarLugarVeterinaria((string)Application.Current.Properties["userId"], lugarVeterinaria);
			await Navigation.PopAsync();
		}
	}
}
