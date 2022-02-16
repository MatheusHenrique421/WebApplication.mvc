using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WebApplication.mvc.Models
{
	[Table("Live")]
	public class Live
	{
		[Display(Name = "Id")]
		[Column("Id")]
		public int Id { get; set; }

		[Display(Name = "Nome")]
		[Column("Nome")]
		public string Nome { get; set; }

		[Display(Name = "Descricao")]
		[Column("Descicao")]
		public string Descricao { get; set; }

		[ForeignKey("Instrutor")]
		[Display(Name = "InstrutorId")]
		[Column("InstrutorId")]
		public int InstrutorId { get; set; }

		[Display(Name = "Instrutor")]
		[Column("Instrutor")]
		public virtual Instrutor Instrutor { get; set; }

		[ForeignKey("Inscrito")]
		[Display(Name = "InscritoId")]
		[Column("InscritoId")]
		public int InscritoId { get; set; }

		[Display(Name = "Inscrito")]
		[Column("Inscrito")]
		public virtual Inscrito Inscrito { get; set; }

		[Display(Name = "HoraInicio")]
		[Column("HoraInicio")]
		public DateTime HoraInicio { get; set; }

		[Display(Name = "DuracaoMin")]
		[Column("DuracaoMin")]
		public int DuracaoMin { get; set; }

		[Display(Name = "ValorInscricao")]
		[Column("ValorInscricao")]
		public decimal ValorInscricao { get; set; }

		public ICollection<Inscrito> Inscritos { get; set; }

	}
}