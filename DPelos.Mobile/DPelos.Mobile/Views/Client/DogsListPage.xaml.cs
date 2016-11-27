using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Client
{
	public partial class DogsListPage : ContentPage
	{
		public DogsListPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var perros = await App.AzureService.ObtenerPerrosDeVeterinario((string)Application.Current.Properties["userId"]);
			BindingContext = new
			{
				Perros = perros,
			};
		}

		void DogsListPage_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}

		async void DogsListPage_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var perro = (Perro)e.Item;
			//await Navigation.PushAsync(new DogDetailsPage(perro.Id));
		}

		async void AddDog(object s, EventArgs e)
		{
			//await Navigation.PushModalAsync(new RegisterDogPage());
		}
	}
}
