using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfsGames.Data.Models
{
	public class NumSeries
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
		public int Id { get; set; }

		[Required(ErrorMessage = "Vyplňte název hry")]
		[StringLength(250, ErrorMessage = "Název může obsahovat max. 100 znaků")]
		[RegularExpression(@"^[A-Za-z0-9\-]+$", ErrorMessage = "Použivejte jen malá nebo velká písmena bez diakritiky nebo číslice.")]
		[Display(Name = "Název hry")]
		public string Name { get; set; }

		[Display(Name = "Datum vytvoření")]
		public DateTime CreationDate { get; set; }

		public string TargetPicture { get; set; }

		[Display(Name = "Správné řešení")]
		public int Solution { get; set; }

		[Display(Name = "Obtížnost")]
		public int Difficulty { get; set; }


		[Required(ErrorMessage = "Vyplňte Url")]
		[StringLength(250, ErrorMessage = "Url může obsahovat max. 250 znaků")]
		[Display(Name = "Url")]
		[RegularExpression(@"^[a-z0-9\-]+$", ErrorMessage = "Použivejte jen malá písmena bez diakritiky nebo číslice.")]
		public string Url { get; set; }

		public NumSeries()
		{
			
		}
	}
}
