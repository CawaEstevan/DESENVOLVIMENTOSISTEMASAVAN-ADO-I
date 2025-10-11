using System.Linq.Expressions;

namespace GerenciamentoBiblioteca.Infraestrutura.Interfaces
{
    /// <summary>
    /// Interface genérica base para repositórios
    /// </summary>
    public interface IRepositorioBase<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task<T> AdicionarAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<bool> DeletarAsync(int id);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado);
    }
}