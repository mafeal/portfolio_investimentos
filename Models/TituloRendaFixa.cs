using portfolio_investimentos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio_investimentos.Models
{
    internal class TituloRendaFixa : IAtivoFinanceiro, IGeradorDeRenda
    {
        public string Nome => throw new NotImplementedException();

        public decimal ValorInvestido => throw new NotImplementedException();

        public decimal ValorAtual => throw new NotImplementedException();

        public string Periodicidade => throw new NotImplementedException();

        public decimal CalcularRendaPeriodica()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularRentabilidade()
        {
            throw new NotImplementedException();
        }
    }
}
