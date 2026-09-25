using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

internal class FundoInvestimento : IAtivoFinanceiro, IGeradorDeRenda
{
    public string Nome { get; set; }

    public decimal ValorInvestido { get; set; } // = QuantidadeCotas × ValorCotaCompr

    public decimal ValorAtual { get; set; } // = QuantidadeCotas × ValorCotaAtual

    public string Periodicidade { get; set; }

    public int QuantidadeCotas { get; set; }

    public decimal ValorCotaCompra { get; set; }

    public decimal ValorCotaAtual { get; set; }

    public decimal TaxaAdministracao { get; set; }

    public decimal RendimentoPorCota { get; set; }


    public decimal CalcularRendaPeriodica()
    {
        /*
         RendaPeriodica = QuantidadeCotas × RendimentoPorCota 
        */
        throw new NotImplementedException();
    }

    public decimal CalcularRentabilidade()
    {
        /*
         Rentabilidade (%) = ((ValorCotaAtual - ValorCotaCompra) 
            / ValorCotaCompra) × 100 
        */
        throw new NotImplementedException();
    }

    /*
     Exemplo
        Considere:
            Quantidade de cotas: 100
            Valor da cota na compra: R$ 80,00
            Valor atual da cota: R$ 84,20

        Assim:
            ValorInvestido = 100 × 80,00 = R$ 8.000,00
            ValorAtual = 100 × 84,20 = R$ 8.420,00

        A rentabilidade será: ((84,20 - 80,00) / 80,00) × 100 = 5,25%

        Para simplificar o exercício, TaxaAdministracao será apenas uma propriedade informativa 
        e não deverá participar do cálculo da rentabilidade.
        Considere que eventuais custos administrativos já estão refletidos no valor atual da cota.
    */
}
