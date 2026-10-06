using Xunit;
using CalculadoraDescontos.App;

namespace CalculadoraDescontos.Tests
{
    public class DescontoServiceTests
    {
        // • Teste 1 (string): Valide todas as categorias
        [Theory]
        [InlineData(2, "BRONZE")]
        [InlineData(7, "PRATA")]
        [InlineData(15, "OURO")]
        public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string categoriaEsperada)
        {
            // Act
            string categoriaObtida = DescontoService.ObterCategoriaCliente(totalCompras);

            // Assert
            Assert.Equal(categoriaEsperada, categoriaObtida);
        }

        // • Teste 2 (int): Valide o cálculo do desconto
        [Theory]
        [InlineData(100, 10, 90)]
        [InlineData(200, 20, 160)]
        [InlineData(50, 0, 50)]
        public void CalcularDescontoPorPercentual_DeveRetornarValorFinal(int valorOriginal, int percentualDesconto, int valorEsperado)
        {
            // Act
            int valorFinalObtido = DescontoService.CalcularDescontoPorPercentual(valorOriginal, percentualDesconto);

            // Assert
            Assert.Equal(valorEsperado, valorFinalObtido);
        }

        // • Teste 3 (bool): Valide a elegibilidade ao cupom
        [Theory]
        [InlineData(20, false, true)]
        [InlineData(16, true, true)]
        [InlineData(17, false, false)]
        public void EValidoParaCupom_DeveValidarElegibilidade(int idade, bool primeiraCompra, bool resultadoEsperado)
        {
            // Arrange (Como EValidoParaCupom NÃO é static, precisamos instanciar)
            var service = new DescontoService();

            // Act
            bool resultadoObtido = service.EValidoParaCupom(idade, primeiraCompra);

            // Assert
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }
    }
}