using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication.mvc.Models
{
	[Table("Inscrito")]
	public class Inscrito
	{
		[Display(Name = "InscritoID")]
		[Column("InscritoID")]
		public int InscritoID { get; set; }

		[Display(Name = "Nome")]
		[Column("Nome")]
		public string Nome { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		[Display(Name = "DataNascimento")]
		[Column("DataNascimento")]
		public DateTime DataNascimento { get; set; }

		[Display(Name = "Email")]
		[Column("Email")]
		public string Email { get; set; }

		[Display(Name = "EnderecoInstagram")]
		[Column("EnderecoInstagram")]
		public string EnderecoInstagram { get; set; }

		public Live Live { get; set; }
	}
}
