using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile.Views.Vet
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
			BindingContext = infoPerro;

			VacunasListView.HeightRequest = infoPerro.Vacunas.Count * VacunasListView.RowHeight;
			ConsultasListView.HeightRequest = infoPerro.Consultas.Count * ConsultasListView.RowHeight;
		}
	}
}
