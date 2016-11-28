using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DPelos.Mobile.Views
{
	public partial class DogQRPage : ContentPage
	{
		string perroId;
		string nombre;

		public DogQRPage(string perroId, string nombre)
		{
			InitializeComponent();
			this.perroId = perroId;
			this.nombre = nombre;
			BindingContext = new
			{
				Codigo = perroId,
				Nombre = nombre,
			};
		}

		protected override void OnAppearing()
		{
			Barcode.BarcodeOptions.Width = 300;
			Barcode.BarcodeOptions.Height = 300;
			//Barcode.BarcodeOptions.Margin = 10;
		}
	}
}
