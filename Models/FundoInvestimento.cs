using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class FundoInvestimento : IAtivoFinanceiro, IGeradorDeRenda
{
    public string Nome { get; set; } = string.Empty;

    public int QuantidadeCotas { get; set; }

    public decimal ValorCotaCompra { get; set; }

    public decimal ValorCotaAtual { get; set; }

    public decimal TaxaAdministracao { get; set; }

    public decimal RendimentoPorCota { get; set; }

    public string Periodicidade { get; set; } = string.Empty;

    public decimal ValorInvestido { get; set; } // = QuantidadeCotas × ValorCotaCompr

    public decimal ValorAtual { get; set; } // = QuantidadeCotas × ValorCotaAtual

    public FundoInvestimento() { }

    public FundoInvestimento(string nome, int quantidadeCotas, decimal valorCotaCompra, decimal valorCotaAtual, decimal taxaAdministracao, decimal rendimentoPorCota, string periodicidade)
    {
        Nome = nome;
        QuantidadeCotas = quantidadeCotas;
        ValorCotaCompra = valorCotaCompra;
        ValorCotaAtual = valorCotaAtual;
        TaxaAdministracao = taxaAdministracao;
        RendimentoPorCota = rendimentoPorCota;
        Periodicidade = periodicidade;

        ValorInvestido = QuantidadeCotas * ValorCotaCompra;
        ValorAtual = QuantidadeCotas * ValorCotaAtual;
    }

    public decimal CalcularRendaPeriodica()
    {
        var rendaPeriodica = QuantidadeCotas * RendimentoPorCota;

        return rendaPeriodica;
    }

    public decimal CalcularRentabilidade()
    {

        var rentabilidade = ((ValorCotaAtual - ValorCotaCompra) / ValorCotaCompra) * 100;

        return rentabilidade;
    }
}
