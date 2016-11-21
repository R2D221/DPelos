using System;

using Xamarin.Forms;

namespace DPelos.Mobile
{
	public class Vacunas : ContentPage
	{
		public Vacunas()
		{
			Label labelEspecialCachorros = new Label
			{
				Text = "Vacuna Especial para Cachorros",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Switch switchEspecialCachorros = new Switch
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Label labelPolivalente = new Label
			{
				Text = "Polivalente Canina",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Switch switchPolivalente = new Switch
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Label labelAntirrabica = new Label
			{
				Text = "Antirrábica",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Switch switchAntirrabica = new Switch
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Label labelTraqueobronquitis = new Label
			{
				Text = "Traqueobronquitis",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Switch switchTraqueobronquitis = new Switch
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Content = new StackLayout
			{
				Children = 
				{
					labelEspecialCachorros,
					switchEspecialCachorros,

					labelAntirrabica,
					switchAntirrabica,

					labelPolivalente,
					switchPolivalente,

					labelTraqueobronquitis,
					switchTraqueobronquitis
				}
			};
		}
	}
}

