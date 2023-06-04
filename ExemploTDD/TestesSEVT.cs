using ProjetoExemplo;

namespace ExemploTDD
{
    public class TestesSEVT
    {
        //Exemplos de Fact usando Teste de 4 Passos SEVT
        //(Setup, Exercise, Verify, Teardown)
        //usando os métodos ValidateCPF e ValidarCNPJ
        [Fact]
        public void ValidarCPFCliente()
        {
            // Setup
            var cpf = "999.888.777-66";
            var expected = false;
            // Exercise
            var resultado = Util.ValidateCPF(cpf);
            // Verify
            Assert.False(resultado);
            Assert.Equal(expected, resultado);
            // Teardown
            cpf = null;
        }

        [Fact]
        public void ValidarCNPJCliente()
        {
            // Setup
            var cnpj = "99. 888. 777/0001-66";
            var expected = false;
            // Exercise
            var resultado = Util.ValidarCNPJ(cnpj);
            // Verify
            Assert.False(resultado);
            Assert.Equal(expected, resultado);
            // Teardown
            cnpj = null;
        }
    }
}
