using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication.mvc.Models.Enum;
using System;
using System.Collections.Generic;

namespace WebApplication.mvc.Models
{
	[Table("Inscricao")]
	public class Inscricao
	{
		[Display(Name = "Id")]
		[Column("Id")]
		public int Id { get; set; }

		[ForeignKey("Live")]
		[Display(Name = "LiveId")]
		[Column("LiveId")]
		public int LiveId { get; set; }

		[Column("Live")]
		[Display(Name = "Live")]
		public Live Live { get; set; }

		[Column("ValorInscricao")]
		[Display(Name = "ValorInscricao")]
		public Live ValorInscricao { get; set; }

		[ForeignKey("Inscrito")]
		[Display(Name = "InscritoId")]
		[Column("InscritoId")]
		public int InscritoId { get; set; }

		[Column("Inscrito")]
		[Display(Name = "Inscrito")]
		public Inscrito Inscrito { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		[Column("DataVencimento")]
		[Display(Name = "DataVencimento")]
		public DateTime? DataVencimento { get; set; }

		[Column("StatusPagamento")]
		[Display(Name = "StatusPagamento")]
		public StatusPagmtoEnum StatusPagamento { get; set; }
		public IEnumerable<Inscrito> Inscritos { get; set; }
	}
}
