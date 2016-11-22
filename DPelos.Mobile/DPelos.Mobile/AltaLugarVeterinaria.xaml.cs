using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DPelos.Mobile
{
	public partial class AltaLugarVeterinaria : ContentPage
	{
		public AltaLugarVeterinaria()
		{
			InitializeComponent();
		}

		async void Save(object s, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
