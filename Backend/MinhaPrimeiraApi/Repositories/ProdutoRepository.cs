using System.Linq;
using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Produto> ObterTodos()
        {
            return _context.Produtos.ToList();
        }

        public Produto? ObterPorId(int id)
        {
            return _context.Produtos.Find(id);
        }

        public bool NomeJaExiste(string nome, int? idIgnorado = null)
        {
            return _context.Produtos.Any(produto =>
                produto.Nome == nome &&
                (!idIgnorado.HasValue || produto.Id != idIgnorado.Value));
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            Produto? produtoExistente = _context.Produtos.Find(produto.Id);

            if (produtoExistente == null)
            {
                return;
            }

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Preco = produto.Preco;

            _context.SaveChanges();
        }

        public void Remover(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}