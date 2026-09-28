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

    /*
        Exemplo
            Considere:
                Valor investido: R$ 10.000,00
                Taxa anual:      10%
                Dias decorridos: 180

            A rentabilidade será: 10 × (180 / 365) ≈ 4,93%

            O valor atual poderá ser calculado como:
                ValorAtual = ValorInvestido × (1 + Rentabilidade / 100)
                Logo:
                ValorAtual = 10.000 × (1 + 4,93 / 100)
                ValorAtual ≈ R$ 10.493,15

            O método: DiasParaVencimento()
                deverá retornar apenas a diferença, em dias, entre DataVencimento e a data atual.

            Para evitar regras financeiras adicionais, utilize nomes como:
                CDB Prefixado 10% a.a.
                ou:
                Título Prefixado 12% a.a. 
     */
}
