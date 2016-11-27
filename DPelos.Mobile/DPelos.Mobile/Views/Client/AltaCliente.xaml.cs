using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DPelos.Mobile.Views.Client
{
	public partial class AltaCliente : ContentPage
	{
		public AltaCliente()
		{
			InitializeComponent();
		}

		async void Save(object s, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
