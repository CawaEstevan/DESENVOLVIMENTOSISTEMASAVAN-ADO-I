using GerenciamentoBiblioteca.Aplicacao.DTOs;

namespace GerenciamentoBiblioteca.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface de serviço para operações com Livro
    /// </summary>
    public interface ILivroServico
    {
        Task<IEnumerable<LivroViewModel>> ObterTodosAsync();
        Task<LivroViewModel> ObterPorIdAsync(int id);
        Task<LivroViewModel> CriarAsync(LivroViewModel livroViewModel);
        Task<LivroViewModel> AtualizarAsync(LivroViewModel livroViewModel);
        Task<bool> DeletarAsync(int id);
        Task<IEnumerable<LivroViewModel>> BuscarPorTituloAsync(string titulo);
        Task<IEnumerable<LivroViewModel>> BuscarPorAutorAsync(string autor);
        Task<IEnumerable<LivroViewModel>> BuscarPorCategoriaAsync(string categoria);
    }
}