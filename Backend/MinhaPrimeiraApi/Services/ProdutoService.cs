using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Repositories;

namespace MinhaPrimeiraApi.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public List<Produto> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public Produto? ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public bool Adicionar(Produto produto)
        {
            if (_repository.NomeJaExiste(produto.Nome))
            {
                return false;
            }

            _repository.Adicionar(produto);
            return true;
        }

        public bool Atualizar(Produto produto)
        {
            if (_repository.ObterPorId(produto.Id) == null ||
                _repository.NomeJaExiste(produto.Nome, produto.Id))
            {
                return false;
            }

            _repository.Atualizar(produto);
            return true;
        }

        public bool Remover(int id)
        {
            Produto? produto = _repository.ObterPorId(id);

            if (produto == null)
            {
                return false;
            }

            _repository.Remover(produto);
            return true;
        }
    }
}