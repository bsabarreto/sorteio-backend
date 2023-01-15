using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IDados
    {
        public List<Pessoa> FormatarObjetoPessoa(List<string> dadosSemFormatacao);

        public List<string> LerArquivoDeDados();
    }
}
