using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using DPelos.Mobile.Models;
using Xamarin.Forms;

namespace DPelos.Mobile.Views
{
	public partial class DogDetailsPage : ContentPage
	{
		string perroId;
		InfoPerro infoPerro;

		public DogDetailsPage(string perroId)
		{
			InitializeComponent();
			this.perroId = perroId;
		}

		protected override async void OnAppearing()
		{
			infoPerro = await App.AzureService.ObtenerDetallesDePerro(perroId);
			infoPerro.EsVeterinario = (string)Application.Current.Properties["TipoUsuario"] == "Veterinario";
			BindingContext = infoPerro;
		}

		void ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}

		void Consultas_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var consulta = (Consulta)e.Item;
			Navigation.PushModalAsync(new VisitDetailsPage(consulta));
		}

		void QR(object s, EventArgs e)
		{
			if (infoPerro != null)
			{
				Navigation.PushModalAsync(new DogQRPage(perroId, infoPerro.Perro.Nombre));
			}
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
