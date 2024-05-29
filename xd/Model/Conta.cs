using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;
        private decimal _saldoInicial;
        private Cliente _titular;
        private Agencia _agencia;
        private const decimal TaxaSaque = 0.10m;

        public Conta(long numero, decimal saldo, Cliente titular, Agencia agencia)
        {
            if (titular == null)
            {
                throw new ArgumentException("A conta deve ter um titular.");
            }
            if (agencia == null)
            {
                throw new ArgumentException("A conta deve pertencer a uma agência.");
            }
            if (saldo <= 10.00m)
            {
                throw new ArgumentException("O saldo inicial deve ser superior a R$10,00.");
            }
            _numero = numero;
            _saldo = saldo;
            _saldoInicial = saldo;
            _titular = titular;
            _agencia = agencia;
        }

        public long Numero
        {
            get => _numero;
            private set => _numero = value;
        }

        public decimal Saldo
        {
            get => _saldo;
            private set => _saldo = value;
        }

        public decimal SaldoInicial
        {
            get => _saldoInicial;
        }

        public Cliente Titular
        {
            get => _titular;
            private set => _titular = value;
        }

        public Agencia Agencia
        {
            get => _agencia;
            private set => _agencia = value;
        }

        public void Deposito(decimal valor)
        {
            if (valor > 0)
            {
                _saldo += valor;
            }
            else
            {
                throw new ArgumentException("O valor do depósito deve ser positivo.");
            }
        }

        public void Saque(decimal valor)
        {
            if (_saldo >= valor + TaxaSaque)
            {
                _saldo -= valor + TaxaSaque;
            }
            else
            {
                throw new ArgumentException("Valor do saque ultrapassa saldo.");
            }
        }

        public void Transferencia(Conta contaDestino, decimal valor)
        {
            if (contaDestino == null)
            {
                throw new ArgumentException("Conta de destino não pode ser nula.");
            }
            if (_saldo >= valor + TaxaSaque)
            {
                _saldo -= valor + TaxaSaque;
                contaDestino.Deposito(valor);
            }
            else
            {
                throw new ArgumentException("Saldo insuficiente para transferência.");
            }
        }

    }
}