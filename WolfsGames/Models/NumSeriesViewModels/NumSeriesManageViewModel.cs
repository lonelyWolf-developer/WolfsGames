using WolfsGames.Data.Models;

namespace WolfsGames.Models.NumSeriesViewModels
{
	public class NumSeriesManageViewModel
	{
		public NumSeries NumSeries { get; set; }

		public IFormFile Image { get; set; }
		
		public string FormCaption { get; set; }

		public NumSeriesManageViewModel() 
		{
			NumSeries = new NumSeries();
		}
	}
}
