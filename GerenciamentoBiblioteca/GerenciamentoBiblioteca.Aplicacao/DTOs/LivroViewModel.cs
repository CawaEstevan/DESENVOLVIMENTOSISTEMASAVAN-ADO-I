using System.ComponentModel.DataAnnotations;

namespace GerenciamentoBiblioteca.Aplicacao.DTOs
{
    /// <summary>
    /// ViewModel para operações com Livro
    /// </summary>
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(200, ErrorMessage = "O título deve ter no máximo 200 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório")]
        [StringLength(150, ErrorMessage = "O nome do autor deve ter no máximo 150 caracteres")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O ISBN é obrigatório")]
        [StringLength(20, ErrorMessage = "O ISBN deve ter no máximo 20 caracteres")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "A editora é obrigatória")]
        [StringLength(100, ErrorMessage = "O nome da editora deve ter no máximo 100 caracteres")]
        [Display(Name = "Editora")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "O ano de publicação é obrigatório")]
        [Range(1500, 2100, ErrorMessage = "Ano de publicação inválido")]
        [Display(Name = "Ano de Publicação")]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "A quantidade disponível é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade disponível deve ser positiva")]
        [Display(Name = "Quantidade Disponível")]
        public int QuantidadeDisponivel { get; set; }

        [Required(ErrorMessage = "A quantidade total é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade total deve ser maior que zero")]
        [Display(Name = "Quantidade Total")]
        public int QuantidadeTotal { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }
    }
}