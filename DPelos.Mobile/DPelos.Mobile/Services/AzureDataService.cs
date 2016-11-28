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
using System.Threading;

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
		private IMobileServiceSyncTable<Cliente>	tablaCliente;
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
		private IMobileServiceTable<Cliente>	tablaRemotaCliente;
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
			store.DefineTable<Cliente>();
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
			tablaCliente	= MobileService.GetSyncTable<Cliente>();
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
			tablaRemotaCliente	= MobileService.GetTable<Cliente>();
			tablaRemotaConsulta	= MobileService.GetTable<Consulta>();
			tablaRemotaCalificacion	= MobileService.GetTable<Calificacion>();
			tablaRemotaVeterinarioHasPerro	= MobileService.GetTable<VeterinarioHasPerro>();
			tablaRemotaVacuna	= MobileService.GetTable<Vacuna>();
			tablaRemotaCarnetHasVacuna	= MobileService.GetTable<CarnetHasVacuna>();

			await tablaVacuna.PullAsync("Vacunas", tablaVacuna.CreateQuery());
		
			isInitialized = true;
		}

		public async Task Purge()
		{
			await Initialize();
		
			await tablaCarnet	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaUsuario	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaPerro	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaLugarVeterinaria	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaVeterinario	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaCliente	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaConsulta	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaCalificacion	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaVeterinarioHasPerro	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaVacuna	.PurgeAsync(null, null, true, CancellationToken.None);
			await tablaCarnetHasVacuna	.PurgeAsync(null, null, true, CancellationToken.None);
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
	
		public async Task GuardarInfoVeterinario(string userId, DateTime fechaNacimiento, string cedula, string telefono)
		{
			await Initialize();
			var usuario = await tablaRemotaUsuario.LookupAsync(userId);
			usuario.Tipo = 1;
			await tablaUsuario.UpdateAsync(usuario);
			await tablaVeterinario.InsertAsync(new Veterinario
			{
				UsuarioId = userId,
				FechaNacimiento = fechaNacimiento,
				Cedula = cedula,
				Telefono = telefono,
			});
			await MobileService.SyncContext.PushAsync();
		}
	
		public async Task GuardarInfoCliente(string userId, DateTime fechaNacimiento, string telefono)
		{
			await Initialize();
			var usuario = await tablaRemotaUsuario.LookupAsync(userId);
			usuario.Tipo = 2;
			await tablaUsuario.UpdateAsync(usuario);
			await tablaCliente.InsertAsync(new Cliente
			{
				UsuarioId = userId,
				FechaNacimiento = fechaNacimiento,
				Telefono = telefono,
			});
			await MobileService.SyncContext.PushAsync();
		}

		public async Task<string> ObtenerNombreUsuario(string veterinarioId)
		{
			await Initialize();
			var usuario = await tablaRemotaUsuario.LookupAsync(veterinarioId);
			return usuario.Nombre;
		}


		public async Task RegistrarPerro(string veterinarioId, string email, Perro perro)
		{
			await Initialize();
			var usuario =
				(await tablaRemotaUsuario.Where(x => x.Email == email).ToEnumerableAsync())
				.FirstOrDefault();

			if (usuario == null) throw new InvalidOperationException();

			var carnet = new Carnet
			{
				FechaCreacion = DateTime.Now,
			};

			await tablaCarnet.InsertAsync(carnet);

			perro.CarnetId = carnet.Id;
			perro.UsuarioId = usuario.Id;

			await tablaPerro.InsertAsync(perro);

			await tablaVeterinarioHasPerro.InsertAsync(new VeterinarioHasPerro
			{
				PerroId = perro.Id,
				VeterinarioId = veterinarioId,
			});

			await MobileService.SyncContext.PushAsync();
		}

		public async Task<IEnumerable<Perro>> ObtenerPerrosDeVeterinario(string veterinarioId)
		{
			await Initialize();

			await tablaVeterinarioHasPerro.PullAsync("VeterinarioHasPerro", tablaVeterinarioHasPerro.Where(x => x.VeterinarioId == veterinarioId));

			var perrosIds = 
				(await tablaVeterinarioHasPerro.ToEnumerableAsync())
				.Select(x => x.PerroId)
				.ToList();

			await tablaPerro.PullAsync("Perro", tablaPerro.Where(x => perrosIds.Contains(x.Id)));

			var perros = await tablaPerro.ToListAsync();

			return perros;
		}

		public async Task<IEnumerable<Perro>> ObtenerPerrosDeCliente(string clienteId)
		{
			await Initialize();

			await tablaPerro.PullAsync("Perro", tablaPerro.Where(x => x.UsuarioId == clienteId));

			var perros = await tablaPerro.ToListAsync();

			return perros;
		}

		public async Task<InfoPerro> ObtenerDetallesDePerro(string perroId)
		{
			await Initialize();

			var perro = await tablaPerro.LookupAsync(perroId);
			var carnet = await tablaRemotaCarnet.LookupAsync(perro.CarnetId);

			await tablaConsulta.PullAsync($"Consultas{perro.Id}", tablaConsulta.Where(x => x.PerroId == perro.Id && x.CarnetId == carnet.Id));
			await tablaCarnetHasVacuna.PullAsync($"Vacunas{perro.Id}", tablaCarnetHasVacuna.Where(x => x.CarnetId == carnet.Id));

			var vacunas =
				(await tablaRemotaVacuna.ToEnumerableAsync())
				.ToDictionary(x => x.Id, x => x.Nombre);

			var consultas = await tablaConsulta.Where(x => x.PerroId == perro.Id && x.CarnetId == carnet.Id).ToListAsync();

			var vacunasCarnet =
				(await tablaCarnetHasVacuna.Where(x => x.CarnetId == carnet.Id).ToEnumerableAsync())
				.Select(x => new VacunaAplicada
				{
					Nombre = vacunas[x.VacunaId],
					FechaAplicacion = x.FechaAplicacion,
				})
				.ToList();

			return new InfoPerro
			{
				Perro = perro,
				Consultas = consultas,
				Vacunas = vacunasCarnet,
			};
		}

		public async Task<List<Vacuna>> ObtenerVacunas()
		{
			await Initialize();
			return await tablaVacuna.ToListAsync();
		}

		public async Task GuardarVacuna(string perroId, string vacunaId, DateTime fechaAplicacion)
		{
			await Initialize();

			var perro = await tablaPerro.LookupAsync(perroId);
			var carnet = await tablaRemotaCarnet.LookupAsync(perro.CarnetId);

			await tablaCarnetHasVacuna.InsertAsync(new CarnetHasVacuna
			{
				CarnetId = carnet.Id,
				VacunaId = vacunaId,
				FechaAplicacion = fechaAplicacion,
			});
			await MobileService.SyncContext.PushAsync();
		}
		
		public async Task GuardarConsulta(string veterinarioId, string perroId, DateTime fecha, string peso, string tamano, string diagnostico)
		{
			await Initialize();

			var perro = await tablaPerro.LookupAsync(perroId);
			var carnet = await tablaRemotaCarnet.LookupAsync(perro.CarnetId);

			await tablaConsulta.InsertAsync(new Consulta
			{
				CarnetId = carnet.Id,
				PerroId = perro.Id,
				VeterinarioId = veterinarioId,
				Fecha = fecha,
				Peso = Double.Parse(peso),
				Tamano = Double.Parse(tamano),
				Diagnostico = diagnostico,
			});
			await MobileService.SyncContext.PushAsync();
		}

		public async Task AgregarPerroAVeterinario(string perroId, string veterinarioId)
		{
			await Initialize();
			await tablaVeterinarioHasPerro.InsertAsync(new VeterinarioHasPerro
			{
				PerroId = perroId,
				VeterinarioId = veterinarioId,
			});
			await MobileService.SyncContext.PushAsync();
		}

		public async Task<LugarVeterinaria> ObtenerLugarVeterinaria(string veterinarioId)
		{
			await Initialize();
			var lugarVeterinariaId =
				(await tablaRemotaVeterinario.Where(x => x.UsuarioId == veterinarioId).ToEnumerableAsync())
				.Select(x => x.LugarVeterinariaId)
				.FirstOrDefault();

			if (lugarVeterinariaId == null)
			{
				return new LugarVeterinaria();
			}

			await tablaLugarVeterinaria.PullAsync("LugarVeterinaria", tablaLugarVeterinaria.Where(x => x.Id == lugarVeterinariaId));
			return await tablaLugarVeterinaria.LookupAsync(lugarVeterinariaId);
		}

		public async Task GuardarLugarVeterinaria(string veterinarioId, LugarVeterinaria lugarVeterinaria)
		{
			await Initialize();
			if (lugarVeterinaria.Id == null)
			{
				await tablaLugarVeterinaria.InsertAsync(lugarVeterinaria);

				var veterinario =
					(await tablaRemotaVeterinario.Where(x => x.UsuarioId == veterinarioId).ToEnumerableAsync())
					.FirstOrDefault();

				veterinario.LugarVeterinariaId = lugarVeterinaria.Id;

				await tablaRemotaVeterinario.UpdateAsync(veterinario);
			}
			else
			{
				await tablaLugarVeterinaria.UpdateAsync(lugarVeterinaria);
			}

			await MobileService.SyncContext.PushAsync();
		}


	}
}