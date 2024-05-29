// See https://aka.ms/new-console-template for more information
// Exercícios slides 26 x, 30 x , 31, 32
using SistemaFinanceiro;
using SistemaFinanceiro.Model;

Banco banco = new Banco("Banco Central", 1);

// Criar agência
Agencia agencia = new Agencia(101, "12345-678", "1234-5678", banco);

// Criar clientes
Cliente cliente1 = new Cliente("João Silva", "12345678901", 1995);
Cliente cliente2 = new Cliente("Maria Oliveira", "09876543210", 1990);

// Criar contas
Conta conta1 = new Conta(123456, 5000.00m, cliente1, agencia);
Conta conta2 = new Conta(654321, 2341.42m, cliente2, agencia);

decimal saldoInicialTotalGeral = conta1.SaldoInicial + conta2.SaldoInicial;

// Calcular e exibir o saldo total antes do depósito
decimal saldoTotalAntesDeposito = conta1.Saldo + conta2.Saldo;
Console.WriteLine($"Saldo total das duas contas antes do depósito: {saldoTotalAntesDeposito:C}");

// Depósito de 1000 na conta1
conta1.Deposito(1000.00m);

// Atualização do saldo total após o depósito
decimal saldoTotalDepoisDeposito = conta1.Saldo + conta2.Saldo;
Console.WriteLine($"Saldo total das duas contas depois do depósito: {saldoTotalDepoisDeposito:C}");

// Realizar uma transferência de 500 de conta1 para conta2
conta1.Transferencia(conta2, 500.00m);

// Exibir saldos após a transferência
Console.WriteLine($"Saldo da conta 1 após transferência: {conta1.Saldo:C}");
Console.WriteLine($"Saldo da conta 2 após transferência: {conta2.Saldo:C}");

// Cálculo do saldo total das duas contas
decimal saldoTotalFinal = conta1.Saldo + conta2.Saldo;
long numeroContaMaiorSaldo = conta1.Saldo > conta2.Saldo ? conta1.Numero : conta2.Numero;

// Exibir informações finais
Console.WriteLine($"Saldo total das duas contas: {saldoTotalFinal:C}");
Console.WriteLine($"Número da conta com maior saldo: {numeroContaMaiorSaldo}");
Console.WriteLine($"Saldo inicial total geral: {saldoInicialTotalGeral:C}");

