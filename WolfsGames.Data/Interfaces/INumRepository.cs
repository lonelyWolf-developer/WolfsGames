using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfsGames.Data.Models;

namespace WolfsGames.Data.Interfaces
{
	public interface INumRepository : IRepository<NumSeries>
	{
		NumSeries FindByUrl(string url);
	}
}
