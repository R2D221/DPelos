using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Xamarin.Forms;
using DPelos.Mobile.DataModels;
using System.Diagnostics;

namespace DPelos.Mobile.Services
{
	public class AzureDataService
	{
		public MobileServiceClient MobileService { get; set; }

		bool isInitialized;

		private IMobileServiceSyncTable<Carnet> tablaCarnet;
		private IMobileServiceSyncTable<Usuario> tablaUsuario;
		private IMobileServiceSyncTable<Perro> tablaPerro;
		private IMobileServiceSyncTable<LugarVeterinaria> tablaLugarVeterinaria;
		private IMobileServiceSyncTable<Veterinario> tablaVeterinario;
		private IMobileServiceSyncTable<Consulta> tablaConsulta;
		private IMobileServiceSyncTable<Calificacion> tablaCalificacion;
		private IMobileServiceSyncTable<VeterinarioHasPerro> tablaVeterinarioHasPerro;
		private IMobileServiceSyncTable<Vacuna> tablaVacuna;
		private IMobileServiceSyncTable<CarnetHasVacuna> tablaCarnetHasVacuna;

		public async Task Initialize()
		{
			if (isInitialized)
				return;

			MobileService = new MobileServiceClient("http://dpelos.azurewebsites.net");

			const string path = "syncstore.db";

			var store = new MobileServiceSQLiteStore(path);
			store.DefineTable<Carnet>();
			store.DefineTable<Usuario>();
			store.DefineTable<Perro>();
			store.DefineTable<LugarVeterinaria>();
			store.DefineTable<Veterinario>();
			store.DefineTable<Consulta>();
			store.DefineTable<Calificacion>();
			store.DefineTable<VeterinarioHasPerro>();
			store.DefineTable<Vacuna>();
			store.DefineTable<CarnetHasVacuna>();

			await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
			tablaCarnet = MobileService.GetSyncTable<Carnet>();
			tablaUsuario = MobileService.GetSyncTable<Usuario>();
			tablaPerro = MobileService.GetSyncTable<Perro>();
			tablaLugarVeterinaria = MobileService.GetSyncTable<LugarVeterinaria>();
			tablaVeterinario = MobileService.GetSyncTable<Veterinario>();
			tablaConsulta = MobileService.GetSyncTable<Consulta>();
			tablaCalificacion = MobileService.GetSyncTable<Calificacion>();
			tablaVeterinarioHasPerro = MobileService.GetSyncTable<VeterinarioHasPerro>();
			tablaVacuna = MobileService.GetSyncTable<Vacuna>();
			tablaCarnetHasVacuna = MobileService.GetSyncTable<CarnetHasVacuna>();
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