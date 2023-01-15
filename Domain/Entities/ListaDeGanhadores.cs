using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ListaDeGanhadores
    {
        public Pessoa IdososGanhador { get; set; }
        public Pessoa DeficienteFisicoGanhador { get; set; }
        public List<Pessoa> GeralGanhador { get; set; }
    }
}
