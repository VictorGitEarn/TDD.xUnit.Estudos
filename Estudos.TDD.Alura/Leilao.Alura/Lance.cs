using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.Alura
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Lance não pode ser negativo, lance deve ser igual ou maior que 0");
            Cliente = cliente;
            Valor = valor;
        }
    }
}
