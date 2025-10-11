using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Dominio.Entidades;

namespace GerenciamentoBiblioteca.Infraestrutura.Contexto
{
    /// <summary>
    /// Contexto do banco de dados
    /// </summary>
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Livro
            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Autor).IsRequired().HasMaxLength(150);
                entity.Property(e => e.ISBN).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Editora).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Categoria).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DataCriacao).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();

                entity.HasIndex(e => e.ISBN).IsUnique();
            });

            // Configuração da entidade Usuário
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.CPF).IsRequired().HasMaxLength(14);
                entity.Property(e => e.Endereco).HasMaxLength(200);
                entity.Property(e => e.DataCriacao).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();

                entity.HasIndex(e => e.CPF).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Configuração da entidade Empréstimo
            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DataEmprestimo).IsRequired();
                entity.Property(e => e.DataPrevistaDevolucao).IsRequired();
                entity.Property(e => e.Observacoes).HasMaxLength(500);
                entity.Property(e => e.DataCriacao).IsRequired();
                entity.Property(e => e.Ativo).IsRequired();

                // Relacionamentos
                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Emprestimos)
                    .HasForeignKey(e => e.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Livro)
                    .WithMany(l => l.Emprestimos)
                    .HasForeignKey(e => e.LivroId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Dados iniciais (seed)
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed de Livros
            modelBuilder.Entity<Livro>().HasData(
                new Livro
                {
                    Id = 1,
                    Titulo = "Clean Code",
                    Autor = "Robert C. Martin",
                    ISBN = "978-0132350884",
                    Editora = "Prentice Hall",
                    AnoPublicacao = 2008,
                    QuantidadeDisponivel = 5,
                    QuantidadeTotal = 5,
                    Categoria = "Tecnologia",
                    Ativo = true,
                    DataCriacao = DateTime.Now
                },
                new Livro
                {
                    Id = 2,
                    Titulo = "Domain-Driven Design",
                    Autor = "Eric Evans",
                    ISBN = "978-0321125217",
                    Editora = "Addison-Wesley",
                    AnoPublicacao = 2003,
                    QuantidadeDisponivel = 3,
                    QuantidadeTotal = 3,
                    Categoria = "Tecnologia",
                    Ativo = true,
                    DataCriacao = DateTime.Now
                }
            );

            // Seed de Usuários
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "João Silva",
                    Email = "joao.silva@email.com",
                    Telefone = "(11) 98765-4321",
                    CPF = "123.456.789-00",
                    DataNascimento = new DateTime(1990, 5, 15),
                    Endereco = "Rua das Flores, 123",
                    Ativo = true,
                    DataCriacao = DateTime.Now
                }
            );
        }
    }
}