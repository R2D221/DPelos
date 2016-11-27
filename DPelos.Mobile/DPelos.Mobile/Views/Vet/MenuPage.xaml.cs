using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile.Views.Vet
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();
		}
	
		async void GoToDetails(object s, EventArgs e)
		{
			((MasterDetailPage)this.Parent).IsPresented = false;
			await ((MasterDetailPage)this.Parent).Detail.Navigation.PushAsync(new DetailsPage());
		}
	}
}
