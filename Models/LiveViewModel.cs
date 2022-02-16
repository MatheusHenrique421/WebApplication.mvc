using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApplication.mvc.Models
{
	public class LiveViewModel
	{
		public Live Live { get; set; }
		public List<SelectListItem> LivesSelect { get; set; }
	}
}
