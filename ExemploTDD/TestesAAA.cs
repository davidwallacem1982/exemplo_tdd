using ProjetoExemplo;

namespace ExemploTDD
{
    public class TestesAAA
    {
        //Exemplos de Fact usando a estrutura de teste AAA
        //(Arrange, Act, Assert) usuando o m�todos CalcularIdade
        //e GetMaiorDeIdade
        [Fact]
        public void ClienteMaiorDeIdade()
        {
            // Arrange
            var cliente = new Clientes{
                Nome = "Genilce",
                DataNascimento = Convert.ToDateTime("27/11/1986"),
                };
            var idade = Util.CalcularIdade(cliente.DataNascimento);
            bool expected = true;
            // Act
            bool result = Util.GetMaiorDeIdade(idade);
            // Assert
            Assert.Equal(expected, result);
        }

        //Exemplo com DisplayName
        [Fact(DisplayName = "Verifica se Cliente � Menor de Idade")]
        public void ClienteMenorDeIdade()
        {
            // Arrange
            var cliente = new Clientes
            {
                Nome = "Enzo",
                DataNascimento = Convert.ToDateTime("09/02/2013"),
            };
            var idade = Util.CalcularIdade(cliente.DataNascimento);
            bool expected = false;
            // Act
            bool result = Util.GetMaiorDeIdade(idade);
            // Assert
            Assert.Equal(expected, result);
        }

        //Exemplo de Skip para m�todo n�o implementado
        [Fact(Skip = "N�o implementado", DisplayName = "ClienteAtivo n�o implementado")]
        public void ClienteAtivo()
        {
            // TODO: Needs to be implemented or
            // HACK: Needs to be implemented or
            // UNDONE: Needs to be implemented
        }
    }
}