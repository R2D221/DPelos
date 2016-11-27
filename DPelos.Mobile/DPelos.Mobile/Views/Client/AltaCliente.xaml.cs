using System;
using System.Collections.Generic;
using DPelos.Mobile.Models;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Client
{
	public partial class AltaCliente : ContentPage
	{
		public AltaCliente()
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
			await App.AzureService.GuardarInfoCliente
			(
				userId: (string)Application.Current.Properties["userId"],
				fechaNacimiento: this.BirthdayEntry.Date,
				telefono: this.PhoneEntry.Text
			);
			Application.Current.Properties["TipoUsuario"] = "Cliente";
			Application.Current.MainPage = new Views.Client.MainPage();
		}
	}
}
