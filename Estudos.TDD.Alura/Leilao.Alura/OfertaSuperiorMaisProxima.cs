using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leilao.Alura
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; }

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            this.ValorDestino = valorDestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(x => x.Valor > ValorDestino)
                .OrderBy(x => x.Valor)
                .FirstOrDefault();
        }
    }
}
