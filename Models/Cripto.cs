using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

internal class Cripto : IAtivoFinanceiro, IAtivoNegociavel
{
    public string Nome => throw new NotImplementedException();

    public decimal ValorInvestido => throw new NotImplementedException();

    public decimal ValorAtual => throw new NotImplementedException();

    public decimal PrecoMercado => throw new NotImplementedException();

    public decimal VariacaoDiaria => throw new NotImplementedException();

    public decimal CalcularRentabilidade()
    {
        throw new NotImplementedException();
    }
}
