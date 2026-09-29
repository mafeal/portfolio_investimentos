using portfolio_investimentos.Interfaces;
using portfolio_investimentos.Models;
using portfolio_investimentos.Repository;

Console.WriteLine("[INICIO] Iniciando o programa: \n");

// Chama os métodos que instanciam os ativos e os adiciona na lista de ativos
var acao1 = PortfolioRepository.CarregarAcao();
Portfolio<IAtivoFinanceiro>.AdicionaAtivo(acao1);

var rendaFixa1 = PortfolioRepository.CarregarRendaFixa();
Portfolio<IAtivoFinanceiro>.AdicionaAtivo(rendaFixa1);

var fundo1 = PortfolioRepository.CarregaFundo();
Portfolio<IAtivoFinanceiro>.AdicionaAtivo(fundo1);

//EXTRA - PRINCIPIOS O e L - a implementação do ativo Cripo
//        funciona sem alterar nenehuma funcionalidade e prova
//        que qulquer IAtivoFinanceiro pode ser implementado por Portfolio.
var cripto1 = PortfolioRepository.CarregarCripto();
Portfolio<IAtivoFinanceiro>.AdicionaAtivo(cripto1);

// Carrega os métodos de cálculo e relatório
Portfolio<IAtivoFinanceiro>.CalcularValorTotal();
Portfolio<IAtivoFinanceiro>.CalcularRentabilidade();
Portfolio<IAtivoFinanceiro>.CalculaRendaPeriodicaTotal();
Portfolio<IAtivoFinanceiro>.GeradorDeRelatorio();

//EXTRA - Filtro genérico.
Portfolio<IAtivoFinanceiro>.FiltrarPor(a => a.ValorAtual > 10000);

Console.WriteLine("[FIM] Fim da execução.");