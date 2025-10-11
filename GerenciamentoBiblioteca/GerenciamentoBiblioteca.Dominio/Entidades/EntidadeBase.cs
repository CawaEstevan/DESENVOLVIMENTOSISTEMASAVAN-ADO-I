namespace GerenciamentoBiblioteca.Dominio.Entidades
{
    /// <summary>
    /// Entidade base com propriedades comuns
    /// </summary>
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        protected EntidadeBase()
        {
            DataCriacao = DateTime.Now;
            Ativo = true;
        }
    }
}