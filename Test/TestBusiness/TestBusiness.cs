using Business;
using Domain.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test.TestBusiness
{
    public class TestBusiness
    {
        private RegrasSorteio _regrasSorteio = new RegrasSorteio();
        private Dados _dados = new Dados();


        [Fact(DisplayName = "Verifica o número de CPFs validos")]
        [Trait("Valido", "CPF")]
        public void TESTE_NUMERO_DE_CPFS_VALIDOS()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            List<Pessoa> listaPessoa = _dados.FormatarObjetoPessoa(listaString);
            int numeroDeCPFsValidos = 0;
            foreach (var item in listaPessoa)
            {
                if(_regrasSorteio.ValidarCPF(item.CPF))
                    numeroDeCPFsValidos++;

            }

            Assert.True(numeroDeCPFsValidos == 17);
        }

        [Fact(DisplayName = "Verifica o número de CPFs invalidos")]
        [Trait("Invalido", "CPF")]
        public void TESTE_NUMERO_DE_CPFS_INVALIDOS()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            List<Pessoa> listaPessoa = _dados.FormatarObjetoPessoa(listaString);
            int numeroDeCPFsInvalidos = 0;
            foreach (var item in listaPessoa)
            {
                if (!_regrasSorteio.ValidarCPF(item.CPF))
                    numeroDeCPFsInvalidos++;

            }

            Assert.True(numeroDeCPFsInvalidos == 3);
        }

        [Fact(DisplayName = "Idade maior que quinze anos")]
        [Trait("Idade", "Maior")]
        public void TESTE_VERIFICAR_SE_IDADE_E_MAIOR_QUE_QUINZE_ANOS()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            List<Pessoa> listaPessoa = _dados.FormatarObjetoPessoa(listaString);
            int numeroDeMaioresDeQuinzeAnos = 0;
            foreach (var item in listaPessoa)
            {
                if (_regrasSorteio.ValidarIdade(item.DataNascimento))
                    numeroDeMaioresDeQuinzeAnos++;

            }

            Assert.True(numeroDeMaioresDeQuinzeAnos == 20);
        }

        [Fact(DisplayName = "Idade menor que quinze anos")]
        [Trait("Idade", "Menor")]
        public void TESTE_VERIFICAR_SE_IDADE_E_MENOR_QUE_QUINZE_ANOS()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            List<Pessoa> listaPessoa = _dados.FormatarObjetoPessoa(listaString);
            int numeroDeMenoresDeQuinzeAnos = 0;
            foreach (var item in listaPessoa)
            {
                if (!_regrasSorteio.ValidarIdade(item.DataNascimento))
                    numeroDeMenoresDeQuinzeAnos++;

            }

            Assert.True(numeroDeMenoresDeQuinzeAnos == 0);
        }


        [Fact(DisplayName = "Número de pessoas que tem a renda no intervalo definido pelo sorteio")]
        [Trait("Renda", "Dentro do Intervalo")]
        public void TESTE_VERIFICAR_RENDA_NO_INTERVALO_DEFINIDO_NO_SORTEIO()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            List<Pessoa> listaPessoa = _dados.FormatarObjetoPessoa(listaString);
            int numeroDeRendaDentroDoIntervalo = 0;
            foreach (var item in listaPessoa)
            {
                if (_regrasSorteio.ValidarRenda(item.Renda))
                    numeroDeRendaDentroDoIntervalo++;

            }

            Assert.True(numeroDeRendaDentroDoIntervalo == 13);
        }

        [Fact(DisplayName = "Número de pessoas que tem a renda fora do intervalo definido pelo sorteio")]
        [Trait("Renda", "Fora do Intervalo")]
        public void TESTE_VERIFICAR_RENDA_FORA_DO_INTERVALO_DEFINIDO_NO_SORTEIO()
        {
            List<string> listaString = _dados.LerArquivoDeDados();
            List<Pessoa> listaPessoa = _dados.FormatarObjetoPessoa(listaString);
            int numeroDeRendaForaDoIntervalo = 0;
            foreach (var item in listaPessoa)
            {
                if (_regrasSorteio.ValidarRenda(item.Renda))
                    numeroDeRendaForaDoIntervalo++;

            }

            Assert.True(numeroDeRendaForaDoIntervalo > 7);
        }



    }
}
