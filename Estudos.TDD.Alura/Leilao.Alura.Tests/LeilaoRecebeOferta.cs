using System.Linq;
using Xunit;

namespace Leilao.Alura.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4, new double[] { 800, 900, 1000, 1100 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(
            int qtdEsperada, double[] ofertas)
        {
            //Arranje - cenário de entrada
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
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

            leilao.TerminaPregao();

            //Act - Método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdEsperada, qtdeObtida);
        }

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje - cenário de entrada
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(fulano, 1000);
            
            //Act - Método sob teste
            leilao.RecebeLance(fulano, 2000);

            //Assert
            var qtdEsperada = 1;
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdEsperada, qtdeObtida);
        }
    }
}
