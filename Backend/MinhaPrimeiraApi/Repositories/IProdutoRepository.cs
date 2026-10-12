using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> ObterTodos();
        Produto? ObterPorId(int id);
        bool NomeJaExiste(string nome, int? idIgnorado = null);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);

    }
}