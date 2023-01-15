using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ListaDePessoas
    {
        public List<Pessoa> Idosos { get; set; }
        public List<Pessoa> DeficienteFisico { get; set; }
        public List<Pessoa> Geral { get; set; }
        public int NumeroDeParticipantes { get; set; }  

    }
}
