using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication.mvc.Models
{
	[Table("Instrutor")]
	public class Instrutor
	{
		[Display(Name = "InstrutorId")]
		[Column("InstrutorId")]
		public int Id { get; set; }

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
		public string Instagram { get; set; }
	}
}
