using SistemaFinanceiro.Model;
namespace Teste1;

[TestClass]
public class Teste1
{
    [TestMethod]
    public void TestMethod1()
    {
        decimal saldoInicial = 1000;
        decimal valorDeposito = 1000;
        decimal saldoFinal = 2000;
        Conta conta1 = new Conta(123, saldoInicial);

        conta1.Deposito(valorDeposito);
        Assert.AreEqual(saldoFinal, conta1.Saldo);
    }

    [TestMethod]
    public void TestMethod2()
    {
        decimal saldoInicial = 1000;
        decimal valorSaque = 500;
        decimal saldoFinal = 500;
        Conta conta1 = new Conta(321, saldoInicial);

        conta1.Saque(valorSaque);
        Assert.AreEqual(saldoFinal, conta1.Saldo);
    }
}