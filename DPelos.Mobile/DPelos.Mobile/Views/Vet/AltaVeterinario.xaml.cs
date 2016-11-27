using System;
using System.Collections.Generic;
using DPelos.Mobile.Models;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Vet
{
	public partial class AltaVeterinario : ContentPage
	{
		public AltaVeterinario()
		{
			InitializeComponent();
			BindingContext = new Profile
			{
				Name = (string)Application.Current.Properties["Nombre"],
				Email = (string)Application.Current.Properties["Email"],
				Picture = (string)Application.Current.Properties["Foto"],
			};
		}

		async void Save(object s, EventArgs e)
		{
			await App.AzureService.GuardarInfoVeterinario
			(
				userId: (string)Application.Current.Properties["userId"],
				fechaNacimiento: this.BirthdayEntry.Date,
				cedula: this.CedulaEntry.Text,
				telefono: this.PhoneEntry.Text
			);
			Application.Current.Properties["TipoUsuario"] = "Veterinario";
			Application.Current.MainPage = new Views.Vet.MainPage();
		}
	}
}
