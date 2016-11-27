using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPelos.Mobile.Services
{
	public interface IFacebookService
	{
		string AccessToken { get; }

		Task<DPelos.Mobile.Models.Profile> GetProfile();
	}
}
