using GerenciamentoBiblioteca.Aplicacao.DTOs;
using GerenciamentoBiblioteca.Aplicacao.Interfaces;
using GerenciamentoBiblioteca.Dominio.Entidades;
using GerenciamentoBiblioteca.Infraestrutura.Interfaces;

namespace GerenciamentoBiblioteca.Aplicacao.Servicos
{
    /// <summary>
    /// Serviço de aplicação para Livro
    /// </summary>
    public class LivroServico : ILivroServico
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroServico(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<IEnumerable<LivroViewModel>> ObterTodosAsync()
        {
            var livros = await _livroRepositorio.ObterTodosAsync();
            return livros.Select(MapearParaViewModel);
        }

        public async Task<LivroViewModel> ObterPorIdAsync(int id)
        {
            var livro = await _livroRepositorio.ObterPorIdAsync(id);
            return livro != null ? MapearParaViewModel(livro) : null;
        }

        public async Task<LivroViewModel> CriarAsync(LivroViewModel livroViewModel)
        {
            var livro = MapearParaEntidade(livroViewModel);
            var livroCriado = await _livroRepositorio.AdicionarAsync(livro);
            return MapearParaViewModel(livroCriado);
        }

        public async Task<LivroViewModel> AtualizarAsync(LivroViewModel livroViewModel)
        {
            var livro = await _livroRepositorio.ObterPorIdAsync(livroViewModel.Id);
            if (livro == null) return null;

            livro.Titulo = livroViewModel.Titulo;
            livro.Autor = livroViewModel.Autor;
            livro.ISBN = livroViewModel.ISBN;
            livro.Editora = livroViewModel.Editora;
            livro.AnoPublicacao = livroViewModel.AnoPublicacao;
            livro.QuantidadeDisponivel = livroViewModel.QuantidadeDisponivel;
            livro.QuantidadeTotal = livroViewModel.QuantidadeTotal;
            livro.Categoria = livroViewModel.Categoria;
            livro.Ativo = livroViewModel.Ativo;
            livro.DataAtualizacao = DateTime.Now;

            var livroAtualizado = await _livroRepositorio.AtualizarAsync(livro);
            return MapearParaViewModel(livroAtualizado);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _livroRepositorio.DeletarAsync(id);
        }

        public async Task<IEnumerable<LivroViewModel>> BuscarPorTituloAsync(string titulo)
        {
            var livros = await _livroRepositorio.BuscarAsync(l => l.Titulo.Contains(titulo));
            return livros.Select(MapearParaViewModel);
        }

        public async Task<IEnumerable<LivroViewModel>> BuscarPorAutorAsync(string autor)
        {
            var livros = await _livroRepositorio.BuscarAsync(l => l.Autor.Contains(autor));
            return livros.Select(MapearParaViewModel);
        }

        public async Task<IEnumerable<LivroViewModel>> BuscarPorCategoriaAsync(string categoria)
        {
            var livros = await _livroRepositorio.BuscarAsync(l => l.Categoria.Contains(categoria));
            return livros.Select(MapearParaViewModel);
        }

        private LivroViewModel MapearParaViewModel(Livro livro)
        {
            return new LivroViewModel
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                ISBN = livro.ISBN,
                Editora = livro.Editora,
                AnoPublicacao = livro.AnoPublicacao,
                QuantidadeDisponivel = livro.QuantidadeDisponivel,
                QuantidadeTotal = livro.QuantidadeTotal,
                Categoria = livro.Categoria,
                Ativo = livro.Ativo,
                DataCriacao = livro.DataCriacao
            };
        }

        private Livro MapearParaEntidade(LivroViewModel viewModel)
        {
            return new Livro
            {
                Titulo = viewModel.Titulo,
                Autor = viewModel.Autor,
                ISBN = viewModel.ISBN,
                Editora = viewModel.Editora,
                AnoPublicacao = viewModel.AnoPublicacao,
                QuantidadeDisponivel = viewModel.QuantidadeDisponivel,
                QuantidadeTotal = viewModel.QuantidadeTotal,
                Categoria = viewModel.Categoria,
                Ativo = true
            };
        }
    }
}