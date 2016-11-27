using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.Models;
using Xamarin.Forms;

namespace DPelos.Mobile.Views
{
	public partial class ChooseAccountTypePage : ContentPage
	{
		public ChooseAccountTypePage()
		{
			InitializeComponent();
			BindingContext = new Profile
			{
				Name = (string)Application.Current.Properties["Nombre"],
				Email = (string)Application.Current.Properties["Email"],
				Picture = (string)Application.Current.Properties["Foto"],
			};
		}

		public async void ChoseVet(object s, EventArgs e)
		{
			Application.Current.MainPage = new Views.Vet.AltaVeterinario();
		}

		public async void ChoseClient(object s, EventArgs e)
		{
			//Application.Current.Properties["TipoUsuario"] = "Cliente";
			//await App.AzureService.AsignarTipoAUsuario((string)Application.Current.Properties["userId"], 2);
			Application.Current.MainPage = new Views.Client.AltaCliente();
		}
	}
}
