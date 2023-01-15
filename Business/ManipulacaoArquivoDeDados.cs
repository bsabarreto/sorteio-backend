using Domain.Entities;
using Domain.Enum;
using Domain.Interface;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ManipulacaoArquivoDeDados : IManipulacaoArquivoDeDados
    {
        private  IDados _dados;

        public ManipulacaoArquivoDeDados(IDados dados)
        {
            _dados = dados;
        }
        public List<Pessoa> PopularDados()
        {
            List<string> listagemDePessoasDoArquivo = _dados.LerArquivoDeDados();
            List<Pessoa> listaDeObjetosDePessoas = _dados.FormatarObjetoPessoa(listagemDePessoasDoArquivo);
            return listaDeObjetosDePessoas;
        }

        public ListaDePessoas SepararPessoaTipo(List<Pessoa> dadosSemFormatacaoPorTipo)

        {
            ListaDePessoas lista = new ListaDePessoas();


            foreach (var item in dadosSemFormatacaoPorTipo)
            {
                switch (item.Cota)
                {
                    case EnumCota.GERAL: 
                        if(lista.Geral == null) 
                        lista.Geral = new List<Pessoa> { item } ; 
                            else
                                lista.Geral.Add(item); break;

                    case EnumCota.DEFICIENTE_FISICO:
                        if (lista.DeficienteFisico == null && !String.IsNullOrEmpty(item.CID))
                            lista.DeficienteFisico = new List<Pessoa> { item };
                                else if(!String.IsNullOrEmpty(item.CID))lista.DeficienteFisico.Add(item); break;

                    case EnumCota.IDOSO:
                        if (lista.Idosos == null && item.Idade > 60)
                            lista.Idosos = new List<Pessoa> { item } ;
                                else if (item.Idade > 60) lista.Idosos.Add(item);break;

                    default: break;
                }
            }
            lista.NumeroDeParticipantes = lista.Geral.Count + lista.Idosos.Count + lista.DeficienteFisico.Count;
            return lista;
        }
    }
}
