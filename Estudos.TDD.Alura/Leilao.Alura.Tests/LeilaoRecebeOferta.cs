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
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
                leilao.RecebeLance(fulano, valor);

            leilao.TerminaPregao();

            //Act - Método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdEsperada, qtdeObtida);
        }
    }
}
