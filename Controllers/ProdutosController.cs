using apiCadastroProduto.Models;
using apiCadastroProduto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IRepositorioProduto repositorio;
        public ProdutosController(IRepositorioProduto _context)
        {
            repositorio = _context;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "ProdutosController ::  Acessado em  : " + DateTime.Now.ToLongDateString();
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterProdutos()
        {
            var produtos = await repositorio.ObterTodos();
            if (produtos == null)
            {
                return BadRequest();
            }
            return Ok(produtos.ToList());
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> ObterProduto(int id)
        {
            var produto = await repositorio.ObterPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado pelo id informado");
            }
            return Ok(produto);
        }
        // POST api/<controller>  
        [HttpPost]
        public async Task<IActionResult> InserirProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto é null");
            }
            await repositorio.Inserir(produto);
            return CreatedAtAction(nameof(ObterProduto), new { Id = produto.ProdutoId }, produto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest($"O código do produto {id} não confere");
            }
            try
            {
                await repositorio.Atualizar(id, produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização do produto realizada com sucesso");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> ExcluirProduto(int id)
        {
            var produto = await repositorio.ObterPorId(id);
            if (produto == null)
            {
                return NotFound($"Produto de {id} foi não encontrado");
            }
            await repositorio.Excluir(id);
            return Ok(produto);
        }
    }
}