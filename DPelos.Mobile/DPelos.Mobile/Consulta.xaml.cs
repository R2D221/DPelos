using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DPelos.Mobile.Views
{
	public partial class Consulta : ContentPage
	{
		public Consulta()
		{
			InitializeComponent();
		}

		async void Save(object s, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
