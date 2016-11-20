using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DPelos.Mobile.DataModels
{
	public class Perro
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[Microsoft.WindowsAzure.MobileServices.Version]
		public string AzureVersion { get; set; }

		public string Nombre { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Raza { get; set; }
	}
}
