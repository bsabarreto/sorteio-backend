using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IManipulacaoArquivoDeDados
    {
        public List<Pessoa> PopularDados();
        public ListaDePessoas SepararPessoaTipo(List<Pessoa> dadosSemFormatacaoPorTipo);
    }
}
