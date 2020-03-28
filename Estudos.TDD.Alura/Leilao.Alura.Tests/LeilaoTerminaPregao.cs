using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Leilao.Alura.Tests
{
    public class LeitlaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        private void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(
            double valorEsperado
            , double[] ofertas)
        {
            //Arranje - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                    leilao.RecebeLance(fulano, valor);
                else
                    leilao.RecebeLance(maria, valor);
            }

            //Act - Método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetonaZeroDadoLeilaoSemLance()
        {
            //Arranje - cenário de entrada
            var leilao = new Leilao("Van Gogh");

            leilao.IniciaPregao();

            //Act - Método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadopregaoNaoIniciado()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");

            //Assert
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(
                //Act - Método sob teste
                () => leilao.TerminaPregao()
            );

            var msgEsperada = "Não é possível terminar pregão sem iniciar o mesmo, favor iniciar o pregão pelo método IniciaPregao().";

            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}
