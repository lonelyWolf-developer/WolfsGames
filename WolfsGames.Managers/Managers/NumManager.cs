using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfsGames.Data.Interfaces;
using WolfsGames.Data.Models;
using WolfsGames.Managers.Classes;
using WolfsGames.Managers.Interfaces;

namespace WolfsGames.Managers.Managers
{
	public class NumManager : INumManager
	{
		private const string imagePath = "wwwroot/img/NumImg";
		
		private readonly INumRepository numRepository;

		public NumManager(INumRepository numRepository)
		{
			this.numRepository = numRepository;
		}

		public void DeleteNumSeries(int id)
		{
			numRepository.Delete(id);
		}

		public List<NumSeries> FindAllNumSeries()
		{
			return numRepository.GetAll();
		}

		public NumSeries FindNumSeriesById(int id)
		{
			return numRepository.FindById(id);
		}

		public NumSeries FindNumSeriesByUrl(string url)
		{
			return numRepository.FindByUrl(url);
		}

		public void SaveNumSeries(NumSeries numSeries, IFormFile file)
		{
			numRepository.Insert(numSeries);

			string numSeriesId = numRepository.FindByUrl(numSeries.Url).Id.ToString();

			SaveImage(imagePath, numSeriesId, file);
		}

		public void UpdateNumSeries(NumSeries numSeries, IFormFile file)
		{
			numRepository.Update(numSeries);
			string numSeriesId = numSeries.Id.ToString();

			SaveImage(imagePath, numSeriesId, file);
		}

		private void SaveImage(string imagePath, string numSeriesId, IFormFile file)
		{
			string directoryPath = Path.Combine(imagePath, numSeriesId);
			string filePath = Path.Combine(directoryPath, "NumSeriesImg.png");

			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			using (var writeStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
			{
				file.CopyTo(writeStream);
			}
		}
	}
}
