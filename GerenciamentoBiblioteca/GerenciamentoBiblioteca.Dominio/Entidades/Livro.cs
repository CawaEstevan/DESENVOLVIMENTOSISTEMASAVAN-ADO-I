namespace GerenciamentoBiblioteca.Dominio.Entidades
{
    /// <summary>
    /// Entidade de domínio representando um Livro
    /// </summary>
    public class Livro : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public string Editora { get; set; }
        public int AnoPublicacao { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeTotal { get; set; }
        public string Categoria { get; set; }

        // Relacionamento com Empréstimos
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }

        public Livro()
        {
            Emprestimos = new List<Emprestimo>();
        }

        // Métodos de domínio
        public bool EstaDisponivel()
        {
            return QuantidadeDisponivel > 0 && Ativo;
        }

        public void EmprestarLivro()
        {
            if (!EstaDisponivel())
                throw new InvalidOperationException("Livro não disponível para empréstimo.");
            
            QuantidadeDisponivel--;
        }

        public void DevolverLivro()
        {
            if (QuantidadeDisponivel >= QuantidadeTotal)
                throw new InvalidOperationException("Quantidade disponível não pode ser maior que o total.");
            
            QuantidadeDisponivel++;
        }
    }
}