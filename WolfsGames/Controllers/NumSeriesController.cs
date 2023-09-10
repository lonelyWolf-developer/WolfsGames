using Microsoft.AspNetCore.Mvc;
using WolfsGames.Data.Models;
using WolfsGames.Managers.Interfaces;
using WolfsGames.Models.NumSeriesViewModels;

namespace WolfsGames.Controllers
{
	public class NumSeriesController : Controller
	{
		private readonly INumManager numManager;

		public NumSeriesController(INumManager numManager)
		{
			this.numManager = numManager;
		}
		
		public IActionResult Index(NumSeriesIndexViewModel model)
		{
			model.Series = numManager.FindAllNumSeries();
			
			return View(model);
		}

		public IActionResult Detail(string url)
		{
			var model = new NumSeriesDetailViewModel
			{
				NumSeries = numManager.FindNumSeriesByUrl(url)
			};

			return View(model);
		}

		[HttpGet]
		public IActionResult ManageNumSeries(string url) 
		{
			var model = new NumSeriesManageViewModel
			{
				FormCaption = string.IsNullOrWhiteSpace(url) ? "Nová číselná řada" : "Editovat číselnou řadu"
			};

			model.NumSeries = string.IsNullOrWhiteSpace(url) ?
			   new NumSeries() :
			   numManager.FindNumSeriesByUrl(url) ?? throw new NullReferenceException($"Číselná řada {url} nebyla nalezena.");

			return View(model);
		}

		[HttpPost]
		public IActionResult ManageNumSeries(NumSeriesManageViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.FormCaption = model.NumSeries.Id == 0 ? "Nová číselná řada" : "Editovat číselnou řadu";

				return View(model);
			}

			numManager.SaveNumSeries(model.NumSeries, model.Image);

			return RedirectToAction(actionName: "Index", controllerName: "NumSeries");
		}
	}
}
