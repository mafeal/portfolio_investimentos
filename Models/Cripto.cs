using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class Cripto : IAtivoFinanceiro, IAtivoNegociavel
{
    public string Nome { get; set; } = string.Empty;

    public decimal ValorInvestido { get; set; } // = Quantidade × PrecoMedioCompra

    public decimal ValorAtual { get; set; } // = Quantidade × PrecoMercado

    public decimal PrecoMercado { get; set; }

    public decimal VariacaoDiaria { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoMedioCompra { get; set; }

    public Cripto() { }

    public Cripto(string nome, decimal precoMercado, decimal variacaoDiaria, int quantidade, decimal precoMedioCompra)
    {
        Nome = nome;
        PrecoMercado = precoMercado;
        VariacaoDiaria = variacaoDiaria;
        Quantidade = quantidade;
        PrecoMedioCompra = precoMedioCompra;

        ValorInvestido = Quantidade * PrecoMedioCompra;
        ValorAtual = Quantidade * PrecoMercado;
    }

    public decimal CalcularRentabilidade()
    {
        var rentabilidade = ((ValorAtual - ValorInvestido) / ValorInvestido) * 100;

        return rentabilidade;
    }
}
