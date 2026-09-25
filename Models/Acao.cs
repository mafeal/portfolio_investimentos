using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

public class Acao : IAtivoFinanceiro, IGeradorDeRenda, IAtivoNegociavel
{
    public string Nome { get; set; }

    public decimal Quantidade { get; set; } = 0;

    public decimal PrecoMedioCompraa { get; set; }

    public decimal ValorInvestido { get; set; } // = Quantidade × PrecoMedioCompra

    public decimal ValorAtual { get; set; } // = Quantidade × PrecoMercado

    public string Periodicidade { get; set; }


    public decimal DividendosRecebidos { get; set; }

    public decimal PrecoMercado { get; set; }

    public decimal VariacaoDiaria { get; set; }

    

    public decimal CalcularRendaPeriodica() // IGeradorDeRenda
    {
        /*
         * RendaPeriodica = Quantidade × DividendoPorAcao
        */
        throw new NotImplementedException();
    }



    public decimal CalcularRentabilidade()
    {
        /*
         * Rentabilidade (%) = 
         * ((ValorAtual + DividendosRecebidos - ValorInvestido) / ValorInvestido) × 100     * 
        */
        throw new NotImplementedException();
    }
}

/*
 * Exemplo (serviráa para criar o teste)
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