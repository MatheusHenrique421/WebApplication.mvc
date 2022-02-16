using System.ComponentModel;
namespace WebApplication.mvc.Models.Enum
{
    public enum StatusPagmtoEnum
    {
        [Description("Pago")]
        Pago = 1,
        [Description("Não Pago")]
        NaoPago = 2
    }
}
