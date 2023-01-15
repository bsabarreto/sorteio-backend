using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Renda { get; set; }
        public EnumCota Cota { get; set; }
        public string CID { get; set; }
        public int Idade { get; set; }

    }
}
