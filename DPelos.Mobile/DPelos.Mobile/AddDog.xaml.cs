using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile
{
	public partial class AddDog : ContentPage
	{
		public AddDog()
		{
			InitializeComponent();
		}
	
		async void Save(object s, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
