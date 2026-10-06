namespace CalculadoraDescontos.App
{
    public class DescontoService
    {
        public static string ObterCategoriaCliente(int totalCompras)
        {
            if (totalCompras < 5)
            {
                return "BRONZE";
            }
            else if (totalCompras >= 5 && totalCompras <= 10)
            {
                return "PRATA";
            }
            else
            {
                return "OURO";
            }
        }

        // Removido o parâmetro "int valorFinal" que estava sobrando na assinatura
        public static int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
        {
            int valorDesconto = (valorOriginal * percentualDesconto) / 100;
            int valorFinal = valorOriginal - valorDesconto;
            
            return valorFinal;
        }

        public bool EValidoParaCupom(int idade, bool primeiraCompra)
        {
            if (idade >= 18 || primeiraCompra)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}