using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegociavel
{
    public string Nome => throw new NotImplementedException();

    public decimal Quantidade { get; set; } = 0;

    public decimal PrecoMedioCompraa { get; set; }

    public decimal ValorInvestido => throw new NotImplementedException();

    public decimal ValorAtual => throw new NotImplementedException();

    public string Periodicidade => throw new NotImplementedException();


    public decimal DividendosRecebidos { get; set; }

    public decimal PrecoMercado => throw new NotImplementedException();

    public decimal VariacaoDiaria => throw new NotImplementedException();

    public decimal CalcularRendaPeriodica()
    {
        throw new NotImplementedException();
    }

    public decimal CalcularRentabilidade()
    {
        throw new NotImplementedException();
    }
}
