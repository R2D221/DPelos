using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using Xamarin.Forms;

namespace DPelos.Mobile.Views
{
	public partial class VisitDetailsPage : ContentPage
	{
		Consulta consulta;

		public VisitDetailsPage(Consulta consulta)
		{
			InitializeComponent();
			this.consulta = consulta;
		}

		protected override async void OnAppearing()
		{
			BindingContext = new
			{
				Consulta = consulta,
				NombreVeterinario = await App.AzureService.ObtenerNombreUsuario(consulta.VeterinarioId),
			};
		}
	}
}
