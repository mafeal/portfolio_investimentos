using portfolio_investimentos.Models;

#region ACAO
//Console.WriteLine("[INICIO] Iniciando o programa: \n");

//var acao1 = new Acao(
//    "PETR4",
//    100,
//    30.00m,
//    "trimestral",
//    100.00m,
//    32.50m,
//    1.25m
//    );

//Console.WriteLine("[INFO] Calculando a rentabilidade para a ação:");
//Console.WriteLine($"| Nome {acao1.Nome}");
//Console.WriteLine($"| Quantidade {acao1.Quantidade}" );
//Console.WriteLine($"| Preco Medio {acao1.PrecoMedioCompra}" );
//Console.WriteLine($"| Periodicidade {acao1.Periodicidade}" );
//Console.WriteLine($"| Dividendos Recebidos {acao1.DividendosRecebidos}" );
//Console.WriteLine($"| Preco Mercado {acao1.PrecoMercado}" );
//Console.WriteLine($"| Variacao Diaria {acao1.VariacaoDiaria}" );

//var rentabilidade = acao1.CalcularRentabilidade();
//var rentabilidadePeriodica = acao1.CalcularRendaPeriodica();

//Console.WriteLine();         
//Console.WriteLine($"| Rentabilidade:           | {rentabilidade}");
//Console.WriteLine($"| Rentabilidade periódica: | {rentabilidadePeriodica}");

//Console.WriteLine();
//Console.WriteLine("[FIM] Fim da execução.");
#endregion

#region RENDA FIXA
// Console.WriteLine("[INICIO] Iniciando o programa: \n");

// var rendaFixa1 = new TituloRendaFixa(
//     "CDB Prefixado 10% a.a.",
//     10000,
//     10,
//     "29/03/2026",
//     "12/09/2029"
//     );

// Console.WriteLine("[INFO] Calculando a rentabilidade para o Título de Renda Fixa:");
// Console.WriteLine($"| Nome {rendaFixa1.Nome}");
// Console.WriteLine($"| Valor Investido {rendaFixa1.ValorInvestido}");
// Console.WriteLine($"| Taxa Anual {rendaFixa1.TaxaAnual}");
// Console.WriteLine($"| Data de Aplicacao {rendaFixa1.DataAplicacao}");
// Console.WriteLine($"| Data de Vencimento {rendaFixa1.DataVencimento}");

// var rentabilidade = rendaFixa1.CalcularRentabilidade();
// var diasParaVencimento = rendaFixa1.DiasParaVencimento();

// Console.WriteLine();
// Console.WriteLine($"| Valor Atual:          | {rendaFixa1.ValorAtual}");
// Console.WriteLine($"| Rentabilidade:        | {rentabilidade}");
// Console.WriteLine($"| Dias Para Vencimento: | {diasParaVencimento}");

// Console.WriteLine();
// Console.WriteLine("[FIM] Fim da execução.");
#endregion

#region FUNDOS
Console.WriteLine("[INICIO] Iniciando o programa: \n");

var fundo1 = new FundoInvestimento(
    "Fundo Multimercado XP",
    100,
    80,
    84.20m,
    1.20m,
    0.50m,
    "Mensal"
    );

Console.WriteLine("[INFO] Calculando a rentabilidade para o Fundo:");
Console.WriteLine($"| Nome {fundo1.Nome}");
Console.WriteLine($"| Quantidade de cotas {fundo1.QuantidadeCotas}");
Console.WriteLine($"| Valor da cota na compra {fundo1.ValorCotaCompra}");
Console.WriteLine($"| Valor atual da cota {fundo1.ValorCotaAtual}");
Console.WriteLine($"| Taxa de administração {fundo1.TaxaAdministracao}");
Console.WriteLine($"| Rendimento por cota {fundo1.RendimentoPorCota}");
Console.WriteLine($"| Periodicidade {fundo1.Periodicidade}");

var rentabilidade = fundo1.CalcularRentabilidade();
var rentabilidadePeriodica = fundo1.CalcularRendaPeriodica();

Console.WriteLine();
Console.WriteLine($"| Rentabilidade:           | {rentabilidade}");
Console.WriteLine($"| Rentabilidade periódica: | {rentabilidadePeriodica}");

Console.WriteLine();
Console.WriteLine("[FIM] Fim da execução.");
#endregion