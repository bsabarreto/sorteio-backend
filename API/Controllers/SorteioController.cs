using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {
        private IRegrasSorteio _regras;
        private IManipulacaoArquivoDeDados _manipulacaoArquivo;

        public SorteioController(IRegrasSorteio regras, IManipulacaoArquivoDeDados manipulacaoArquivo)
        {
            _regras = regras;
            _manipulacaoArquivo = manipulacaoArquivo;
        }

        [Route("Get")]
        [HttpGet]
        public IActionResult Get()
        {

            List<Pessoa> listaPessoa = _manipulacaoArquivo.PopularDados();
            List<Pessoa> listaPessoaValidadas = _regras.ValidarListaDePessoa(listaPessoa);
            ListaDePessoas listaPessoasSeparadasPorTipo = _manipulacaoArquivo.SepararPessoaTipo(listaPessoaValidadas);
            return Ok(listaPessoasSeparadasPorTipo);

        }

        [Route("GetWinners")]
        [HttpGet]
        public IActionResult GetWinners()
        {

            List<Pessoa> listaPessoa = _manipulacaoArquivo.PopularDados();
            List<Pessoa> listaPessoaValidadas = _regras.ValidarListaDePessoa(listaPessoa);
            ListaDePessoas listaPessoasSeparadasPorTipo = _manipulacaoArquivo.SepararPessoaTipo(listaPessoaValidadas);
            ListaDeGanhadores listaGanhadores = _regras.SelecionarVencedor(listaPessoasSeparadasPorTipo);
            
            return Ok(listaGanhadores);

        }
    }
}
