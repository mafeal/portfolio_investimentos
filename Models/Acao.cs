using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegociavel
{   

    public string Nome { get; set; } = string.Empty;

    public int Quantidade { get; set; } = 0;

    public decimal PrecoMedioCompra { get; set; }

    public string Periodicidade { get; set; } = string.Empty;

    public decimal DividendosRecebidos { get; set; }

    public decimal PrecoMercado { get; set; }

    public decimal VariacaoDiaria { get; set; }

    public decimal ValorInvestido { get; set; } // = Quantidade × PrecoMedioCompra

    public decimal ValorAtual { get; set; } // = Quantidade × PrecoMercado

    // Construtor público sem parâmetros necessário para Activator.CreateInstance
    public Acao()
    {
        // Inicializa valores padrão seguros
        Nome = string.Empty;
        Quantidade = 0;
        PrecoMedioCompra = 0m;
        Periodicidade = string.Empty;
        DividendosRecebidos = 0m;
        PrecoMercado = 0m;
        VariacaoDiaria = 0m;

        ValorInvestido = Quantidade * PrecoMedioCompra;
        ValorAtual = Quantidade * PrecoMercado;
    }

    public Acao(string nome, int quantidade, decimal precoMedioCompra, string periodicidade,
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