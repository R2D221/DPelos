using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile
{
	public partial class DogsListPage : ContentPage
	{
		public DogsListPage()
		{
			InitializeComponent();
		}
	
		async void AddDog(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new AddDog());
		}
	}
}
