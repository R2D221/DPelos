using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using NodaTime;

namespace DPelos.Mobile.DataModels
{
	public class Carnet
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public DateTime FechaCreacion { get; set; }
	}

	public class Usuario
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string Nombre { get; set; }

		public string Email { get; set; }

		public string Direccion { get; set; }

		public int Tipo { get; set; }

		public string FacebookToken { get; set; }

		public string Foto { get; set; }
	}

	public class Perro
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string Nombre { get; set; }

		public DateTime FechaNacimiento { get; set; }

		public string Raza { get; set; }

		public string QR { get; set; }

		public string CarnetId { get; set; }

		public string UsuarioId { get; set; }

		public string Edad
		{
			get
			{
				var fechaNacimiento = new LocalDate(FechaNacimiento.Year, FechaNacimiento.Month, FechaNacimiento.Day);
				var DateTimeNow = DateTime.Now;
				var now = new LocalDate(DateTimeNow.Year, DateTimeNow.Month, DateTimeNow.Day);
				var period = Period.Between(fechaNacimiento, now);

				if (period.Years > 0) return $"{period.Years} años";
				if (period.Months > 0) return $"{period.Months} meses";
				if (period.Weeks > 0) return $"{period.Weeks} semanas";
				return $"{period.Days} días";
			}
		}
	}

	public class LugarVeterinaria
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string Nombre { get; set; }

		public double Longitud { get; set; }

		public double Latitud { get; set; }

		public string Direccion { get; set; }

		public bool EsVisible => Longitud != 0 && Latitud != 0;
	}

	public class Veterinario
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		//public string Nombre { get; set; }

		//public string Email { get; set; }

		public string Cedula { get; set; }

		public DateTime FechaNacimiento { get; set; }

		//public string Especialidad { get; set; }

		public string LugarVeterinariaId { get; set; }

		public string UsuarioId { get; set; }

		public string Telefono { get; set; }
	}

	public class Cliente
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string UsuarioId { get; set; }

		public DateTime FechaNacimiento { get; set; }

		public string Telefono { get; set; }
	}

	public class Consulta
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public DateTime Fecha { get; set; }

		public string Diagnostico { get; set; }

		public double Peso { get; set; }

		public double Tamano { get; set; }

		public string VeterinarioId { get; set; }

		public string PerroId { get; set; }

		public string CarnetId { get; set; }
	}

	public class Calificacion
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public int Ponderacion { get; set; }

		public string Comentario { get; set; }

		public string LugarVeterinariaId { get; set; }
	}

	public class VeterinarioHasPerro
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string VeterinarioId { get; set; }

		public string PerroId { get; set; }
	}

	public class Vacuna
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string Nombre { get; set; }
	}

	public class CarnetHasVacuna
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string CarnetId { get; set; }

		public string VacunaId { get; set; }

		public DateTime FechaAplicacion { get; set; }
	}
}
