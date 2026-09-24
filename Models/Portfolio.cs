using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class Portfolio<T> where T : IAtivoFinanceiro
{
    public string Nome => throw new NotImplementedException();

    public decimal ValorInvestido => throw new NotImplementedException();

    public decimal ValorAtual => throw new NotImplementedException();

    public decimal CalcularRentabilidade()
    {
        throw new NotImplementedException();
    }
}
