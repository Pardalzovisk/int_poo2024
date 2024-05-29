using SistemaFinanceiro;
using SistemaFinanceiro.Model;
namespace Teste1;

[TestClass]
public class Teste1
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "A conta deve ter um titular.")]
    public void TestContaSemTitular()
    {
        // Arrange
        Banco banco = new Banco("Banco Teste", 1);
        Agencia agencia = new Agencia(123, "12345-678", "1234-5678", banco);

        // Act
        Conta conta = new Conta(123456, 100.00m, null, agencia);

        // Assert
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "A conta deve pertencer a uma agência.")]
    public void TestContaSemAgencia()
    {
        // Arrange
        Cliente cliente = new Cliente("João Silva", "12345678901", 1995);

        // Act
        Conta conta = new Conta(123456, 100.00m, cliente, null);

        // Assert
    }

    [TestMethod]
    public void TestContaComTitularEAgencia()
    {
        // Arrange
        Banco banco = new Banco("Banco Teste", 1);
        Agencia agencia = new Agencia(123, "12345-678", "1234-5678", banco);
        Cliente cliente = new Cliente("João Silva", "12345678901", 1995);

        // Act
        Conta conta = new Conta(123456, 100.00m, cliente, agencia);

        // Assert
        Assert.IsNotNull(conta.Titular);
        Assert.IsNotNull(conta.Agencia);
        Assert.AreEqual(cliente, conta.Titular);
        Assert.AreEqual(agencia, conta.Agencia);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "O saldo inicial deve ser superior a R$10,00.")]
    public void TestContaSaldoInicialMinimo()
    {
        // Arrange
        Banco banco = new Banco("Banco Teste", 1);
        Agencia agencia = new Agencia(123, "12345-678", "1234-5678", banco);
        Cliente cliente = new Cliente("João Silva", "12345678901", 1995);

        // Act
        Conta conta = new Conta(123456, 10.00m, cliente, agencia);

        // Assert
    }

    [TestMethod]
    public void TestDeposito()
    {
        // Arrange
        Banco banco = new Banco("Banco Teste", 1);
        Agencia agencia = new Agencia(123, "12345-678", "1234-5678", banco);
        Cliente cliente = new Cliente("João Silva", "12345678901", 1995);
        Conta conta = new Conta(123456, 100.00m, cliente, agencia);

        // Act
        conta.Deposito(200.00m);

        // Assert
        Assert.AreEqual(300.00m, conta.Saldo);
    }

    [TestMethod]
    public void TestSaque()
    {
        // Arrange
        Banco banco = new Banco("Banco Teste", 1);
        Agencia agencia = new Agencia(123, "12345-678", "1234-5678", banco);
        Cliente cliente = new Cliente("João Silva", "12345678901", 1995);
        Conta conta = new Conta(123456, 100.00m, cliente, agencia);

        // Act
        conta.Saque(50.00m);

        // Assert
        Assert.AreEqual(49.90m, conta.Saldo); // 50 - 0.10 (taxa)
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Valor do saque ultrapassa saldo.")]
    public void TestValorSaqueMaiorQueSaldo()
    {
        // Arrange
        Banco banco = new Banco("Banco Teste", 1);
        Agencia agencia = new Agencia(123, "12345-678", "1234-5678", banco);
        Cliente cliente = new Cliente("João Silva", "12345678901", 1995);
        Conta conta = new Conta(123456, 100.00m, cliente, agencia);

        // Act
        conta.Saque(150.00m);

        // Assert
    }

}