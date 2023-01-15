using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Domain.Interface
{
    public interface IRegrasSorteio
    {
        public bool ValidarRenda(decimal renda);
        public bool ValidarIdade(DateTime idade);
        public bool ValidarCPF(string cpf);

        public List<Pessoa> ValidarListaDePessoa(List<Pessoa> listPessoas);
        public ListaDeGanhadores SelecionarVencedor(ListaDePessoas listaPessoas);



    }
}
