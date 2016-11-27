using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Xamarin.Forms;
using DPelos.Mobile.DataModels;
using System.Diagnostics;
using DPelos.Mobile.Models;
using System.Linq;

namespace DPelos.Mobile.Services
{
	public class AzureDataService
	{
		public MobileServiceClient MobileService { get; set; }

		bool isInitialized;

		private IMobileServiceSyncTable<Carnet>	tablaCarnet;
		private IMobileServiceSyncTable<Usuario>	tablaUsuario;
		private IMobileServiceSyncTable<Perro>	tablaPerro;
		private IMobileServiceSyncTable<LugarVeterinaria>	tablaLugarVeterinaria;
		private IMobileServiceSyncTable<Veterinario>	tablaVeterinario;
		private IMobileServiceSyncTable<Consulta>	tablaConsulta;
		private IMobileServiceSyncTable<Calificacion>	tablaCalificacion;
		private IMobileServiceSyncTable<VeterinarioHasPerro>	tablaVeterinarioHasPerro;
		private IMobileServiceSyncTable<Vacuna>	tablaVacuna;
		private IMobileServiceSyncTable<CarnetHasVacuna>	tablaCarnetHasVacuna;

		private IMobileServiceTable<Carnet>	tablaRemotaCarnet;
		private IMobileServiceTable<Usuario>	tablaRemotaUsuario;
		private IMobileServiceTable<Perro>	tablaRemotaPerro;
		private IMobileServiceTable<LugarVeterinaria>	tablaRemotaLugarVeterinaria;
		private IMobileServiceTable<Veterinario>	tablaRemotaVeterinario;
		private IMobileServiceTable<Consulta>	tablaRemotaConsulta;
		private IMobileServiceTable<Calificacion>	tablaRemotaCalificacion;
		private IMobileServiceTable<VeterinarioHasPerro>	tablaRemotaVeterinarioHasPerro;
		private IMobileServiceTable<Vacuna>	tablaRemotaVacuna;
		private IMobileServiceTable<CarnetHasVacuna>	tablaRemotaCarnetHasVacuna;

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
		
			tablaCarnet	= MobileService.GetSyncTable<Carnet>();
			tablaUsuario	= MobileService.GetSyncTable<Usuario>();
			tablaPerro	= MobileService.GetSyncTable<Perro>();
			tablaLugarVeterinaria	= MobileService.GetSyncTable<LugarVeterinaria>();
			tablaVeterinario	= MobileService.GetSyncTable<Veterinario>();
			tablaConsulta	= MobileService.GetSyncTable<Consulta>();
			tablaCalificacion	= MobileService.GetSyncTable<Calificacion>();
			tablaVeterinarioHasPerro	= MobileService.GetSyncTable<VeterinarioHasPerro>();
			tablaVacuna	= MobileService.GetSyncTable<Vacuna>();
			tablaCarnetHasVacuna	= MobileService.GetSyncTable<CarnetHasVacuna>();
		
			tablaRemotaCarnet	= MobileService.GetTable<Carnet>();
			tablaRemotaUsuario	= MobileService.GetTable<Usuario>();
			tablaRemotaPerro	= MobileService.GetTable<Perro>();
			tablaRemotaLugarVeterinaria	= MobileService.GetTable<LugarVeterinaria>();
			tablaRemotaVeterinario	= MobileService.GetTable<Veterinario>();
			tablaRemotaConsulta	= MobileService.GetTable<Consulta>();
			tablaRemotaCalificacion	= MobileService.GetTable<Calificacion>();
			tablaRemotaVeterinarioHasPerro	= MobileService.GetTable<VeterinarioHasPerro>();
			tablaRemotaVacuna	= MobileService.GetTable<Vacuna>();
			tablaRemotaCarnetHasVacuna	= MobileService.GetTable<CarnetHasVacuna>();
		
			isInitialized = true;
		}

		public async Task<Usuario> ObtenerOCrearUsuario(Profile profile)
		{
			await Initialize();
			var usuario =
				(await tablaRemotaUsuario.Where(x => x.Email == profile.Email).ToEnumerableAsync())
				.FirstOrDefault();

			if (usuario == null)
			{
				usuario = new Usuario
				{
					Nombre = profile.Name,
					Email = profile.Email,
					Foto = profile.Picture,
				};

				await tablaUsuario.InsertAsync(usuario);
				await MobileService.SyncContext.PushAsync();
			}

			return usuario;
		}

		public async Task AsignarTipoAUsuario(string userId, int tipo)
		{
			await Initialize();
			var usuario = await tablaRemotaUsuario.LookupAsync(userId);
			usuario.Tipo = tipo;
			await tablaUsuario.UpdateAsync(usuario);
			await MobileService.SyncContext.PushAsync();
		}

		//public async Task<IEnumerable<Perro>> ObtenerPerro()
		//{
		//	await Initialize();
		//	await SyncPerro();

		//	var tbp = tablaPerro.OrderBy(c => c.Nombre).ToEnumerableAsync();
		//	return await tbp;
		//}

		//public async Task<Perro> AgregarPerro (string nombre, DateTime fechaNacimiento, string raza )
		//{
		//	await Initialize();

		//	var item = new Perro
		//	{
		//		Nombre = nombre,
		//		FechaNacimiento = fechaNacimiento,
		//		Raza = raza
		//	};

		//	await tablaPerro.InsertAsync(item);

		//	await SyncPerro();
		//	return item;
		//}

		//public async Task SyncPerro()
		//{
		//	await tablaPerro.PullAsync("Perro", tablaPerro.CreateQuery());
		//	await MobileService.SyncContext.PushAsync();
		//}
	}
}