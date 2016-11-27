using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPelos.Mobile.DataModels;

namespace DPelos.Mobile.Models
{
	public class InfoPerro
	{
		public Perro Perro { get; set; }
		public List<Consulta> Consultas { get; set; }
		public List<VacunaAplicada> Vacunas { get; set; }
		public bool EsVeterinario { get; internal set; }
	}

	public class VacunaAplicada
	{
		public string Nombre { get; set; }
		public DateTime FechaAplicacion { get; set; }
	}
}
