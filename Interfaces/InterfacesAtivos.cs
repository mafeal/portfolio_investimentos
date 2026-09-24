namespace portfolio_investimentos.Interfaces;

// Interface base mínima: todo ativo financeiro deve implementar
public interface IAtivoFinanceiro
{
    string Nome { get; }
    decimal ValorInvestido { get; }
    decimal ValorAtual { get; }

    decimal CalcularRentabilidade();

}

// Interface específica: ativos que possuem data de vencimento
public interface IAtivoComVencimento
{
    DateTime DataVencimento { get; }

    int DiasParaVencimento();
}

// Interface específica: ativos que geram renda periódica
// como dividendos, distribuições etc.
public interface IGeradorDeRenda
{
    string Periodicidade { get; }
    decimal CalcularRendaPeriodica();
}

// Interface específica: ativos negociáveis em mercado
public interface IAtivoNegociavel
{
    decimal PrecoMercado { get; }
    decimal VariacaoDiaria { get; }
}



