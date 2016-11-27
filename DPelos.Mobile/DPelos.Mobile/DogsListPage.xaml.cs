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

		async void AltaCliente(object s, EventArgs e)
		{
			//await Navigation.PushModalAsync(new AltaCliente());
		}

		async void AltaLugarVeterinaria(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new AltaLugarVeterinaria());
		}

		async void AltaVeterinario(object s, EventArgs e)
		{
			//await Navigation.PushModalAsync(new AltaVeterinario());
		}

		async void Consulta(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new Views.Consulta());
		}

		async void Vacunas(object s, EventArgs e)
		{
			await Navigation.PushModalAsync(new Vacunas());
		}
	}
}
