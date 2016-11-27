using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile.Views
{
	public partial class DogDetailsPage : ContentPage
	{
		string perroId;

		public DogDetailsPage(string perroId)
		{
			InitializeComponent();
			this.perroId = perroId;
		}

		protected override async void OnAppearing()
		{
			var infoPerro = await App.AzureService.ObtenerDetallesDePerro(perroId);
			infoPerro.EsVeterinario = (string)Application.Current.Properties["TipoUsuario"] == "Veterinario";
			BindingContext = infoPerro;
		}

		void ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}

		void QR(object s, EventArgs e)
		{
			//Navigation.PushModalAsync(new AddVaccinePage(perroId));
		}

		void AgregarVacuna(object s, EventArgs e)
		{
			Navigation.PushModalAsync(new Views.Vet.AddVaccinePage(perroId));
		}

		void AgregarConsulta(object s, EventArgs e)
		{
			Navigation.PushModalAsync(new Views.Vet.AddVisitPage(perroId));
		}
	}
}
