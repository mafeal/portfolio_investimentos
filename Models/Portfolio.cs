using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

// Ela deve conter, no mínimo:
   
// Método para adicionar ativos.
// Propriedade ou método que retorne o valor total do portfólio.
// Método que calcule a rentabilidade média ponderada.
// Método genérico de filtro, opcional, mas recomendado:
// IEnumerable<T> FiltrarPor(Func<T, bool> predicado)
// O cálculo do valor total deverá considerar:
   
// ValorTotal =
//     soma do ValorAtual de todos os ativos
   
// Implemente um gerador de relatório que, utilizando Reflection:
   
// Percorra todos os ativos do portfólio.
// Exiba o nome da classe de cada ativo.
// Liste dinamicamente todas as propriedades públicas.
// Chame e exiba o resultado de CalcularRentabilidade().
// Detecte em tempo de execução se o ativo implementa interfaces adicionais:
// IAtivoComVencimento
// IGeradorDeRenda
// IAtivoNegociavel
// Mostre informações extras apenas quando essas interfaces existirem.

public class Portfolio<T> where T : IAtivoFinanceiro
{
    public string Nome { get; set; }

    public decimal ValorInvestido { get; set; }

    public decimal ValorAtual { get; set; }

    public decimal ValorTotalPortfolio { get; set; } // = soma do ValorAtual de todos os ativos



    public decimal CalcularRentabilidade()
    {
        throw new NotImplementedException();
    }

    /*
     
    Exemplo conceitual
        Considere:
            Ativo A:
            Valor Atual = R$ 1.000
            Rentabilidade = 20%

            Ativo B:
            Valor Atual = R$ 9.000
            Rentabilidade = 5%

        Uma média simples produziria: (20 + 5) / 2 = 12,5%

        Entretanto, esse resultado trataria os dois investimentos como se tivessem o mesmo peso.

        Neste desafio, primeiro calcule o valor total do portfólio:
            ValorTotalPortfolio = soma do ValorAtual de todos os ativos

        Depois, o peso de cada ativo será:
            PesoDoAtivo = ValorAtualDoAtivo / ValorTotalPortfolio

        A rentabilidade média ponderada será:
            RentabilidadeMediaPonderada = soma(RentabilidadeDoAtivo × PesoDoAtivo)

        Uma forma equivalente, e normalmente mais simples de implementar, é:
            RentabilidadeMediaPonderada = soma(ValorAtualDoAtivo × RentabilidadeDoAtivo)
                                            / ValorTotalPortfolio

     Exemplo completo
        
        Considere o portfólio:
            Ativo	    Valor Atual	 Rentabilidade
            Ação	    R$ 3.300,00	  10%
            Renda Fixa	R$ 5.000,00	  8%
            Fundo	    R$ 1.700,00	 -2%
        
        O valor total será:
            3.300 + 5.000 + 1.700 = R$ 10.000

        Os pesos serão:
            Ação: 3.300 / 10.000 = 0,33
            Renda Fixa: 5.000 / 10.000 = 0,50
            Fundo: 1.700 / 10.000 = 0,17
    
        Portanto:

        Rentabilidade Média Ponderada =
            (10 × 0,33)
            + (8 × 0,50)
            + (-2 × 0,17)

        = 3,30 + 4,00 - 0,34 = 6,96%

        O método do Portfolio<T> deverá realizar esse cálculo de forma polimórfica, utilizando apenas os membros definidos por IAtivoFinanceiro.

        Exemplo:

        public decimal CalcularRentabilidadeMediaPonderada()
        {
            var valorTotal = _ativos.Sum(a => a.ValorAtual);

            if (valorTotal == 0)
                return 0;

            return _ativos.Sum(
                a => a.CalcularRentabilidade() * a.ValorAtual
            ) / valorTotal;
        }

        Não utilize if ou switch para descobrir o tipo concreto do ativo durante esse cálculo.

        O Portfolio<T> deve trabalhar apenas com a abstração IAtivoFinanceiro.

    */

}
