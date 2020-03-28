using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leilao.Alura
{
    public class MaiorValor : IModalidadeAvaliacao
    {
        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(x => x.Valor)
                .LastOrDefault();
        }
    }
}
