using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfsGames.Data.Interfaces;
using WolfsGames.Data.Models;

namespace WolfsGames.Data.Repositories
{
	public class NumRepository : BaseRepository<NumSeries>, INumRepository
	{
		public NumRepository(ApplicationDbContext context) : base(context)
		{
		}

		public NumSeries FindByUrl(string url)
		{
			var numSeries = dbSet.SingleOrDefault(a => a.Url == url);
			return numSeries;
		}
	}
}
