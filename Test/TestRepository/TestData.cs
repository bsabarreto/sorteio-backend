using Domain.Entities;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test.TestRepository
{
    public class TestData
    {
        private Dados  _dados = new Dados();



        [Fact(DisplayName = "Teste que faz a leitura do arquivo e monta uma lista de string")]
        [Trait("Ler", "Listar")]
        public void TESTE_LEITURA_DE_ARQUIVO()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            Assert.NotNull(listaString);

        }

        [Fact(DisplayName = "Teste que faz a leitura do arquivo e monta uma lista de string e transforma a lista de string em uma lista de pessoas")]
        [Trait("String", "Pessoa")]
        public void TESTE_MONTAR_OBJETO_LISTA_DE_PESSOAS()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            List<Pessoa> listaPessoa = _dados.FormatarObjetoPessoa(listaString);

            Assert.NotEmpty(listaPessoa);

        }
    }
}
