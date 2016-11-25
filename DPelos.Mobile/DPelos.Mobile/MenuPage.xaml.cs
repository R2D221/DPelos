using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;


using Xamarin.Forms;

namespace DPelos.Mobile
{
	public partial class MenuPage : ContentPage
	{
		ZXingScannerView zxing;
		ZXingDefaultOverlay overlay;

		public MenuPage()
		{
			InitializeComponent();
		}
	
		async void GoToDetails(object s, EventArgs e)
		{
			((MasterDetailPage)this.Parent).IsPresented = false;
			await ((MasterDetailPage)this.Parent).Detail.Navigation.PushAsync(new DetailsPage());
		}

		async void QRTapped(object sender, EventArgs args)
		{
			var scanner = new ZXing.Mobile.MobileBarcodeScanner();
			//scanner.UseCustomOverlay = true;
			//scanPage = new ZXingScannerPage(customOverlay: customOverlay);
			//scanner. = CustomOverlayPage;
			//overlay.
			var result = await scanner.Scan();

			HandleResult(result);
		}

		void HandleResult(ZXing.Result result)
		{
			var msg = "No Barcode";

			if (result != null)
			{
				msg = "Barcode" + result.Text + " (" + result.BarcodeFormat + " )";
			}

		}

	}

}
