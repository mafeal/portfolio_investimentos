using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class TituloRendaFixa : IAtivoFinanceiro, IAtivoComVencimento
{
    public string Nome { get; set; } = string.Empty;

    public decimal ValorInvestido { get; set; }

    public decimal TaxaAnual { get; set; } // porcentagem

    public DateOnly DataAplicacao { get; set; }

    public DateOnly DataVencimento { get; set; }
    
    public decimal ValorAtual { get; set; } // = ValorInvestido × (1 + Rentabilidade / 100)

    public TituloRendaFixa(){}

    public TituloRendaFixa(string nome, decimal valorInvestido, decimal taxaAnual, string dataAplicacao, string dataVencimento)
    {
        Nome = nome;
        ValorInvestido = valorInvestido;
        TaxaAnual = taxaAnual;
        DataAplicacao = DateOnly.Parse(dataAplicacao);
        DataVencimento = DateOnly.Parse(dataVencimento);

        ValorAtual = ValorInvestido * (1 + CalcularRentabilidade() / 100);
    }

    /// <summary>
    /// Implementa o método da interface IAtivoFinanceiro.
    /// Calcula o rendimento do fundo.
    /// </summary>
    /// <returns>decimal rentabilidade</returns>
    public decimal CalcularRentabilidade()
    {
        var dataAtual = DateOnly.FromDateTime(DateTime.Now);
        var diaDeHoje = dataAtual.DayNumber;
        var diaDaAplicacao = DataAplicacao.DayNumber;
        var diasDecorridos = diaDeHoje - diaDaAplicacao;

        var rentabilidade = TaxaAnual * (diasDecorridos / 365m);

        return rentabilidade;
    }

    /// <summary>
    /// Implementa o método da interface IAtivoComVencimento.
    /// Calcula a quantidade de dias para o vencimento.
    /// </summary>
    /// <returns>int diasParaVencimento</returns>
    public int DiasParaVencimento()
    {
        var dataAtual = DateOnly.FromDateTime(DateTime.Now);
        var diaDeHoje = dataAtual.DayNumber;
        var diaVencimento = DataVencimento.DayNumber;

        var diasParaVencimento = diaVencimento - diaDeHoje;

        return diasParaVencimento;
    }
}
