using apiCadastroProduto.Models;
using apiCadastroProduto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepositorioUsuario repositorio;
        public UsuariosController(IRepositorioUsuario _context)
        {
            repositorio = _context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterProdutos()
        {
            var produtos = await repositorio.ObterTodos();
            if (produtos == null)
            {
                return BadRequest();
            }
            return Ok(produtos.ToList());
        }
        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> ObterUsuario(int id)
        {
            var produto = await repositorio.ObterPorId(id);
            if (produto == null)
            {
                return NotFound("Usuário não encontrado pelo id informado");
            }
            return Ok(produto);
        }
        // POST api/<controller>  
        [HttpPost]
        public async Task<IActionResult> InserirUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário é null");
            }
            await repositorio.Inserir(usuario);
            return CreatedAtAction(nameof(ObterUsuario), new { Id = usuario.UsuarioId }, usuario);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest($"O código do usuário {id} não confere");
            }
            try
            {
                await repositorio.Atualizar(id, usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização do usuario realizada com sucesso");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> ExcluirUsuario(int id)
        {
            var usuario = await repositorio.ObterPorId(id);
            if (usuario == null)
            {
                return NotFound($"Usuario de {id} foi não encontrado");
            }
            await repositorio.Excluir(id);
            return Ok(usuario);
        }
    }
}

