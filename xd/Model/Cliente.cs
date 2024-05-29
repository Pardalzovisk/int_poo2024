using SistemaFinanceiro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaFinanceiro
{
    public class Cliente
    {
        private string _nome;
        private string _cpf;
        private int _anoNascimento;

        public Cliente(string nome, string cpf, int anoNascimento)
        {
            if (cpf.Length != 11)
            {
                throw new ArgumentException("CPF deve conter 11 dígitos.");
            }
            if (DateTime.Now.Year - anoNascimento <= 18)
            {
                throw new ArgumentException("Cliente deve ter mais de 18 anos.");
            }
            _nome = nome;
            _cpf = cpf;
            _anoNascimento = anoNascimento;
        }

        public string Nome
        {
            get => _nome;
            private set => _nome = value;
        }

        public string Cpf
        {
            get => _cpf;
            private set => _cpf = value;
        }

        public int AnoNascimento
        {
            get => _anoNascimento;
            private set => _anoNascimento = value;
        }
    }
}

//Vinculação da Classe Conta com a Classe Cliente
//Na implementação acima, cada Cliente possui uma instância de Conta associada.
//Isso é realizado através do construtor da classe Cliente, que recebe uma instância de Conta.
//Desta forma, cada cliente está diretamente vinculado a uma conta, representando uma relação de titularidade.