using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Vet
{
	public partial class AddVaccinePage : ContentPage
	{
		string perroId;
		List<Vacuna> vacunas;

		public AddVaccinePage(string perroId)
		{
			InitializeComponent();
			this.perroId = perroId;
		}

		protected override async void OnAppearing()
		{
			vacunas = await App.AzureService.ObtenerVacunas();

			foreach (var vacuna in vacunas)
			{
				VacunaPicker.Items.Add(vacuna.Nombre);
			}
		}

		async void Save(object s, EventArgs e)
		{
			var vacuna = vacunas[VacunaPicker.SelectedIndex];

			await App.AzureService.GuardarVacuna(perroId, vacuna.Id, DateEntry.Date);
			await Navigation.PopModalAsync();
		}
	}
}
