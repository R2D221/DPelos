using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Vet
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
			await Navigation.PushAsync(new DogDetailsPage(perro.Id));
		}

		async void AddDog(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new RegisterDogPage());
		}

		async void AltaCliente(object s, EventArgs e)
		{
			//await Navigation.PushModalAsync(new AltaCliente());
		}

		async void AltaLugarVeterinaria(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new AltaLugarVeterinaria());
		}

		async void AltaVeterinario(object s, EventArgs e)
		{
			//await Navigation.PushModalAsync(new AltaVeterinario());
		}

		async void Consulta(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new Views.Consulta());
		}

		async void Vacunas(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new Vacunas());
		}
	}
}
