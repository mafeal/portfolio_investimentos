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

// Carrega os métodos de cálculo e relatório
Portfolio<IAtivoFinanceiro>.CalcularValorTotal();
Portfolio<IAtivoFinanceiro>.CalcularRentabilidade();
Portfolio<IAtivoFinanceiro>.CalculaRendaPeriodicaTotal();
Portfolio<IAtivoFinanceiro>.GeradorDeRelatorio();

Console.WriteLine("[FIM] Fim da execução.");