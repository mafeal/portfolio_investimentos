using portfolio_investimentos.Interfaces;

namespace portfolio_investimentos.Models;

// Ela deve conter, no mínimo:

// Método para adicionar ativos. - OK
// Propriedade ou método que retorne o valor total do portfólio. - OK
// Método que calcule a rentabilidade média ponderada. - OK
// Implemente um gerador de relatório que, utilizando Reflection: - ok


// Método genérico de filtro, opcional, mas recomendado:
// IEnumerable<T> FiltrarPor(Func<T, bool> predicado)


// Percorra todos os ativos do portfólio. - ok
// Exiba o nome da classe de cada ativo. - ok
// Liste dinamicamente todas as propriedades públicas. - ok
// Chame e exiba o resultado de CalcularRentabilidade(). - ok
// Detecte em tempo de execução se o ativo implementa interfaces adicionais:
// IAtivoComVencimento
// IGeradorDeRenda
// IAtivoNegociavel
// Mostre informações extras apenas quando essas interfaces existirem.

public class Portfolio<T> where T : IAtivoFinanceiro
{
    public static decimal ValorTotalPortfolio { get; set; } // = soma do ValorAtual de todos os ativos

    private static List<T> Ativos { get; } = [];

    public static void AdicionaAtivo(T ativo)
    {
        Ativos.Add(ativo);
    }

    public static decimal CalcularValorTotal()
    {
        // ValorTotalPortfolio = Ativos.Sum(a => a.ValorAtual);
        foreach (var ativo in Ativos)
        {
            var tipo = ativo.GetType().Name;
            Console.WriteLine($"| Ativo {tipo} - Valor Atual: R$ {ativo.ValorAtual.ToString("F2")}");
            ValorTotalPortfolio += ativo.ValorAtual;
        }
        Console.WriteLine("| ----------------------------------");
        Console.WriteLine($"| Valor Total do Portfólio: R$ {ValorTotalPortfolio.ToString("F2")}\n");

        return ValorTotalPortfolio;
    }

    public static decimal CalcularRentabilidade()
    {
        decimal rentabilidadeMedia = 0;
        ValorTotalPortfolio = Ativos.Sum(a => a.ValorAtual);
        foreach (var ativo in Ativos)
        {
            var tipo = ativo.GetType().Name;
            var peso = ativo.ValorAtual / ValorTotalPortfolio;
            var rentabilidadePonderada = ativo.CalcularRentabilidade() * peso;
            Console.WriteLine($"| Ativo {tipo} - Rentabilidade Ponderada: {ativo.CalcularRentabilidade().ToString("F2")} * {peso.ToString("F2")} = {rentabilidadePonderada.ToString("F2")}");
            rentabilidadeMedia += rentabilidadePonderada;
        }
        Console.WriteLine("| ----------------------------------");
        Console.WriteLine($"| Valor Rentabilidade Média Ponderada: R$ {rentabilidadeMedia.ToString("F2")}\n");

        return rentabilidadeMedia;
    }

    public static decimal CalculaRendaPeriodicaTotal()
    {
        decimal rentabilidadePeriodicaTotal = 0m;
        foreach (var ativo in Ativos)
        {
            var interfaceGeradorDeRenda = ativo.GetType()
                .GetInterfaces()
                .FirstOrDefault(interfaceAtivo => interfaceAtivo == typeof(IGeradorDeRenda));

            if (interfaceGeradorDeRenda is null) continue;

            var metodoRendaPeriodica = interfaceGeradorDeRenda.GetMethod(nameof(IGeradorDeRenda.CalcularRendaPeriodica));

            var resultado = metodoRendaPeriodica?.Invoke(ativo, null);

            if (resultado is decimal rendaPeriodica)
            {
                rentabilidadePeriodicaTotal += rendaPeriodica;
                Console.WriteLine($"| Ativo {ativo.GetType().Name} - Renda Periódica: R$ {rendaPeriodica:F2}");
            }
        }
        Console.WriteLine("| ----------------------------------");
        Console.WriteLine($"| Valor Rentabilidade Periódica Total: R$ {rentabilidadePeriodicaTotal:F2}\n");

        return rentabilidadePeriodicaTotal;
    }

    public static void GeradorDeRelatorio()
    {
        Console.WriteLine("\n|******************************************|");
        Console.WriteLine("|**** RELATÓRIO DE ATIVOS DO PORTFÓLIO ****|");
        Console.WriteLine("|******************************************|\n");

        foreach (var ativo in Ativos)
        {
            var tipo = ativo.GetType();
            var interfacesImplementadas = tipo.GetInterfaces();
            Console.WriteLine($"|**** Listando parâmetros do ativo: {tipo.Name}");
            var parametros = tipo.GetProperties().ToList();
            foreach(var p in parametros)
            {
                var nomeDaPropriedade = p.Name;
                var valorDaPropriedade = p.GetValue(ativo)!.ToString() ?? "";
                Console.WriteLine($"| {nomeDaPropriedade}: {valorDaPropriedade}");
            }
            string implementa = "Implementa: ";
            foreach(var i in interfacesImplementadas)
            {
                implementa += $" {i.Name}";
            }
            Console.WriteLine($"| {implementa}");
            Console.WriteLine("|*******************************************|\n");


        }
    }

    /*
        #region ACAO
        Console.WriteLine("[INFO] Calculando a rentabilidade para a ação:");
        Console.WriteLine($"| Nome {acao1.Nome}");
        Console.WriteLine($"| Quantidade {acao1.Quantidade}");
        Console.WriteLine($"| Preco Medio {acao1.PrecoMedioCompra}");
        Console.WriteLine($"| Periodicidade {acao1.Periodicidade}");
        Console.WriteLine($"| Dividendos Recebidos {acao1.DividendosRecebidos}");
        Console.WriteLine($"| Preco Mercado {acao1.PrecoMercado}");
        Console.WriteLine($"| Variacao Diaria {acao1.VariacaoDiaria}");
        Console.WriteLine($"| Valor Atual: {acao1.ValorAtual}");
        
        
        var rentabilidade = acao1.CalcularRentabilidade();
        var rentabilidadePeriodica = acao1.CalcularRendaPeriodica();
        
        Console.WriteLine();
        Console.WriteLine($"| Rentabilidade:           | {rentabilidade.ToString("F2")}");
        Console.WriteLine($"| Rentabilidade periódica: | {rentabilidadePeriodica.ToString("F2")}");
        
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------");
        #endregion
        
        #region RENDA FIXA
        Console.WriteLine("[INFO] Calculando a rentabilidade para o Título de Renda Fixa:");
        Console.WriteLine($"| Nome {rendaFixa1.Nome}");
        Console.WriteLine($"| Valor Investido {rendaFixa1.ValorInvestido}");
        Console.WriteLine($"| Taxa Anual {rendaFixa1.TaxaAnual}");
        Console.WriteLine($"| Data de Aplicacao {rendaFixa1.DataAplicacao}");
        Console.WriteLine($"| Data de Vencimento {rendaFixa1.DataVencimento}");
        Console.WriteLine($"| Valor Atual: {rendaFixa1.ValorAtual}");
        
        
        var rentabilidadeRF = rendaFixa1.CalcularRentabilidade();
        var diasParaVencimento = rendaFixa1.DiasParaVencimento();
        
        Console.WriteLine();
        Console.WriteLine($"| Valor Atual:          | {rendaFixa1.ValorAtual}");
        Console.WriteLine($"| Rentabilidade:        | {rentabilidadeRF}");
        Console.WriteLine($"| Dias Para Vencimento: | {diasParaVencimento}");
        
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------");
        #endregion
        
        #region FUNDOS
        Console.WriteLine("[INFO] Calculando a rentabilidade para o Fundo:");
        Console.WriteLine($"| Nome {fundo1.Nome}");
        Console.WriteLine($"| Quantidade de cotas {fundo1.QuantidadeCotas}");
        Console.WriteLine($"| Valor da cota na compra {fundo1.ValorCotaCompra}");
        Console.WriteLine($"| Valor atual da cota {fundo1.ValorCotaAtual}");
        Console.WriteLine($"| Taxa de administração {fundo1.TaxaAdministracao}");
        Console.WriteLine($"| Rendimento por cota {fundo1.RendimentoPorCota}");
        Console.WriteLine($"| Periodicidade {fundo1.Periodicidade}");
        Console.WriteLine($"| Valor Atual: {fundo1.ValorAtual}");
        
        
        var rentabilidadeFI = fundo1.CalcularRentabilidade();
        var rentabilidadePeriodicaFI = fundo1.CalcularRendaPeriodica();
        
        Console.WriteLine();
        Console.WriteLine($"| Rentabilidade:           | {rentabilidadeFI}");
        Console.WriteLine($"| Rentabilidade periódica: | {rentabilidadePeriodicaFI}");
        
        Console.WriteLine();
        #endregion
    */

}
