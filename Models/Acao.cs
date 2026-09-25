using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegociavel
{   

    public string Nome { get; set; } = string.Empty;

    public decimal Quantidade { get; set; } = 0;

    public decimal PrecoMedioCompra { get; set; }

    public string Periodicidade { get; set; } = string.Empty;

    public decimal DividendosRecebidos { get; set; }

    public decimal PrecoMercado { get; set; }

    public decimal VariacaoDiaria { get; set; }

    public decimal ValorInvestido { get; set; } // = Quantidade × PrecoMedioCompra

    public decimal ValorAtual { get; set; } // = Quantidade × PrecoMercado

    public Acao(string nome, decimal quantidade, decimal precoMedioCompra, string periodicidade,
        decimal dividendosRecebidos, decimal precoMercado, decimal variacaoDiaria)
    {
        Nome = nome;
        Quantidade = quantidade;
        PrecoMedioCompra = precoMedioCompra;
        Periodicidade = periodicidade;
        DividendosRecebidos = dividendosRecebidos;
        PrecoMercado = precoMercado;
        VariacaoDiaria = variacaoDiaria;

        ValorInvestido = Quantidade * PrecoMedioCompra;
        ValorAtual = Quantidade * PrecoMercado;
    }



    // SOLID - Exemplos de Single Responsability:
    // Cada método abaixo tem apenas uma responsabilidade,
    // além da classe tratar exclusivamente sobre uma ação.

    /// <summary>
    /// Implementação do método da interface IGeradorDeRenda.
    /// Calcula a rentabilidade periódica da ação.
    /// </summary>
    /// <returns>decimal rendaPeriódica</returns>
    public decimal CalcularRendaPeriodica() 
    {        
        decimal rendaPeriodica = Quantidade * DividendosRecebidos;

        return rendaPeriodica;
    }

    /// <summary>
    /// Implementação do método da interface IAtivoFinanceiro.
    /// Calcula a rentabilidade da ação.
    /// </summary>
    /// <returns>decimal rentabilidade</returns>
    public decimal CalcularRentabilidade()
    {
         decimal rentabilidade = ((ValorAtual + DividendosRecebidos - ValorInvestido) / ValorInvestido) * 100;
        
         return rentabilidade;
    }
}

/*
 * Exemplo (servirá para criar o teste)
    Considere:

    Quantidade:            100 ações
    Preço médio de compra: R$ 30,00
    Preço atual:           R$ 32,50
    Dividendos recebidos:  R$ 100,00

    Logo:
    ValorInvestido = 100 × 30,00 = R$ 3.000,00
    ValorAtual = 100 × 32,50 = R$ 3.250,00

    A rentabilidade será:
    ((3.250 + 100 - 3.000) / 3.000) × 100 = 11,67%
*/