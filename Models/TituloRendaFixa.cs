using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

internal class TituloRendaFixa : IAtivoFinanceiro, IAtivoComVencimento
{
    public string Nome { get; set; }

    public decimal ValorInvestido { get; set; }

    public decimal ValorAtual { get; set; } // = ValorInvestido × (1 + Rentabilidade / 100)

    public string Periodicidade { get; set; }

    public decimal TaxaAnual { get; set; } // porcentagem

    public DateOnly DataAplicacao { get; set; }

    public DateOnly DataVencimento { get; set; }

    DateTime IAtivoComVencimento.DataVencimento => throw new NotImplementedException();

    public decimal CalcularRentabilidade()
    {
        /*
            DiasDecorridos = DataAtual - DataAplicacao
            Rentabilidade (%) = TaxaAnual × (DiasDecorridos / 365)
         */

        throw new NotImplementedException();
    }

    public int DiasParaVencimento()
    {
        //deverá retornar apenas a diferença, em dias,
        //entre DataVencimento e a data atual.
        throw new NotImplementedException();
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
