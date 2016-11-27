using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;
using Xamarin.Forms;

namespace DPelos.Mobile.Views.Vet
{
	public partial class RegisterDogPage : ContentPage
	{
		public RegisterDogPage()
		{
			InitializeComponent();
		}
	
		async void Save(object s, EventArgs e)
		{
			await App.AzureService.RegistrarPerro((string)Application.Current.Properties["userId"], this.EmailEntry.Text, new Perro
			{
				Nombre = this.NameEntry.Text,
				FechaNacimiento = this.BirthdayEntry.Date,
				Raza = this.RazaEntry.Text,
			});
			await Navigation.PopModalAsync();
		}
	}
}
