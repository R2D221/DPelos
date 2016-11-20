using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

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
	}

	public class LugarVeterinaria
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public float Longitud { get; set; }
		public float Latitud { get; set; }

		public string Direccion { get; set; }
	}

	public class Veterinario
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Version]
		public string AzureVersion { get; set; }

		public string Nombre { get; set; }

		public string Email { get; set; }

		public string Cedula { get; set; }

		public string FechaNacimiento { get; set; }

		public string Especialidad { get; set; }

		public string LugarVeterinariaId { get; set; }

		public string UsuarioId { get; set; }
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
	}
}
