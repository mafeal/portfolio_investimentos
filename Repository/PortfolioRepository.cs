using portfolio_investimentos.Models;

namespace portfolio_investimentos.Repository;

public static class PortfolioRepository
{   
    public static Acao CarregarAcao()
    {
        return new Acao(
            "PETR4",
             100,
             30.00m,
            "trimestral",
            100.00m,
            32.50m,
            1.25m
        );
    }

    public static TituloRendaFixa CarregarRendaFixa()
    {
        return new TituloRendaFixa(
            "CDB Prefixado 10% a.a.",
            10000,
            10,
            "29/03/2026",
            "12/09/2029"
        );
    }

    public static FundoInvestimento CarregaFundo()
    {
        return new FundoInvestimento(
            "Fundo Multimercado XP",
            100,
            80,
            84.20m,
            1.20m,
            0.50m,
            "Mensal"
        );
    }

    //EXTRA - Implementação do ativo Cripo 
    public static Cripto CarregarCripto()
    {
        return new Cripto(
            "Bitcoin",
            35000.00m,
            0.05m,
            2,
            30000.00m
        );
    }
}
