using GerenciamentoBiblioteca.Infraestrutura.Contexto;
using GerenciamentoBiblioteca.Infraestrutura.Interfaces;
using GerenciamentoBiblioteca.Infraestrutura.Repositorios;

namespace GerenciamentoBiblioteca.Infraestrutura.Fabricas
{
    /// <summary>
    /// Factory para criação de repositórios
    /// </summary>
    public class RepositorioFabrica
    {
        private readonly BibliotecaContexto _contexto;

        public RepositorioFabrica(BibliotecaContexto contexto)
        {
            _contexto = contexto;
        }

        public ILivroRepositorio CriarLivroRepositorio()
        {
            return new LivroRepositorio(_contexto);
        }

        public IUsuarioRepositorio CriarUsuarioRepositorio()
        {
            return new UsuarioRepositorio(_contexto);
        }

        public IEmprestimoRepositorio CriarEmprestimoRepositorio()
        {
            return new EmprestimoRepositorio(_contexto);
        }
    }
}