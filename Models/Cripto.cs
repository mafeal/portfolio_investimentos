using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

internal class Cripto : IAtivoFinanceiro, IAtivoNegociavel
{
    public string Nome { get; set; }

    public decimal ValorInvestido { get; set; } // = Quantidade × PrecoMedioCompra

    public decimal ValorAtual { get; set; } // = Quantidade × PrecoMercado

    public decimal PrecoMercado { get; set; }

    public decimal VariacaoDiaria { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoMedioCompra { get; set; }

    public decimal CalcularRentabilidade()
    {
        /*
        Rentabilidade (%) = ((ValorAtual - ValorInvestido)
                             / ValorInvestido) × 100

        ou

        Rentabilidade(%) = ((PrecoMercado - PrecoMedioCompra)
                            / PrecoMedioCompra) × 100
        */
        throw new NotImplementedException();
    }
}
