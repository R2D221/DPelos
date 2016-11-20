using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Xamarin.Forms;
using DPelos.Mobile.DataModels;

namespace DPelos.Mobile.Services
{
	public class AzureDataService
	{
		public MobileServiceClient MobileService { get; set; }

		IMobileServiceSyncTable<Perro> tablaPerro;

		bool isInitialized;

		public async Task Initialize()
		{
			if (isInitialized)
				return;

			MobileService = new MobileServiceClient("http://dpelos.azurewebsites.net");

			const string path = "syncstore.db";

			var store = new MobileServiceSQLiteStore(path);
			store.DefineTable<Perro>();
			await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

			tablaPerro = MobileService.GetSyncTable<Perro>();
			isInitialized = true;
		}

		public async Task<IEnumerable<Perro>> ObtenerPerro()
		{
			await Initialize();
			await SyncPerro();

			var tbp = tablaPerro.OrderBy(c => c.Nombre).ToEnumerableAsync();
			return await tbp;
		}

		public async Task<Perro> AgregarPerro (string nombre, DateTime fechaNacimiento, string raza )
		{
			await Initialize();

			var item = new Perro
			{
				Nombre = nombre,
				FechaNacimiento = fechaNacimiento,
				Raza = raza
			};

			await tablaPerro.InsertAsync(item);

			await SyncPerro();
			return item;
		}

		public async Task SyncPerro()
		{
			await tablaPerro.PullAsync("Perro", tablaPerro.CreateQuery());
			await MobileService.SyncContext.PushAsync();
		}
	}
}