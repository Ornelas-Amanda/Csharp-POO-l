using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bytebank.Titular;

namespace bytebank
{
    public class ContaCorrente
    {
       // public static int id { private set; get; }
        public int Numero_agencia { get; set; }
        public string Conta { get; set; }
        public Cliente? Titular { get; set; }

        private double saldo = 100;


     
     public ContaCorrente(Cliente titular ,int numero_agencia, string conta, double saldo)
        {

            Numero_agencia = numero_agencia;
            Conta = conta;
            Titular = titular;
            this.saldo = saldo;
        }

        public void Depositar(double saldo)
        {
            this.saldo += saldo;
        }

        public bool Sacar(double valor)
        {
            if (valor <= this.saldo)
            {
                this.saldo -= valor;

                return true;
            }
            else
            {
                return false;
            }

           

            
        }

        public bool Transferir(double valor , ContaCorrente destino)
        {
            if (this.saldo < valor)
            {
                return false;
            }
            else
            {
                this.Sacar(valor);
                destino.Depositar(valor);

                return true;

            }
        }

        public string ApresentaDados()
        {
            return $"ID:\nTitular:{this.Titular.Nome}\n Conta:{this.Conta}\n Agencia:{this.Numero_agencia}\n Saldo:{this.saldo}";
        }
    }
}
