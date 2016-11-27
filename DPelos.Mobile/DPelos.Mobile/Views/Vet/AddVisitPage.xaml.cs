using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Vet
{
	public partial class AddVisitPage : ContentPage
	{
		string perroId;
		List<Vacuna> vacunas;

		public AddVisitPage(string perroId)
		{
			InitializeComponent();
			this.perroId = perroId;
		}

		protected override async void OnAppearing()
		{
		}

		async void Save(object s, EventArgs e)
		{
			await App.AzureService.GuardarConsulta(perroId, DateEntry.Date, PesoEntry.Text, TamanoEntry.Text, DiagnosticoEntry.Text);
			await Navigation.PopModalAsync();
		}
	}
}
