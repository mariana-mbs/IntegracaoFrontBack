using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Services
{
    public interface IProdutoService
    {
        List<Produto> ObterTodos();
        Produto? ObterPorId(int id);
        bool Adicionar(Produto produto);
        bool Atualizar(Produto produto);
        bool Remover(int id);
    }
}