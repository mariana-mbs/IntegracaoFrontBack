using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Services;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> ObterTodos()
        {
            return Ok(_produtoService.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> ObterPorId(int id)
        {
            Produto? produto = _produtoService.ObterPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Adicionar(Produto produto)
        {
            if (!_produtoService.Adicionar(produto))
            {
                return Conflict("Já existe um produto com esse nome.");
            }

            return CreatedAtAction(
                nameof(ObterPorId),
                new { id = produto.Id },
                produto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Atualizar(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest("O ID da rota deve ser igual ao ID do produto.");
            }

            if (_produtoService.ObterPorId(id) == null)
            {
                return NotFound();
            }

            if (!_produtoService.Atualizar(produto))
            {
                return Conflict("Já existe um produto com esse nome.");
            }

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remover(int id)
        {
            if (!_produtoService.Remover(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}