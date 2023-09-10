using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfsGames.Data.Models;
using WolfsGames.Managers.Classes;

namespace WolfsGames.Managers.Interfaces
{
	public interface INumManager
	{
		NumSeries FindNumSeriesById(int id);
		NumSeries FindNumSeriesByUrl(string url);
		List<NumSeries> FindAllNumSeries();
		void SaveNumSeries(NumSeries numSeries, IFormFile file);
		void UpdateNumSeries(NumSeries numSeries, IFormFile file);
		void DeleteNumSeries(int id);

	}
}
