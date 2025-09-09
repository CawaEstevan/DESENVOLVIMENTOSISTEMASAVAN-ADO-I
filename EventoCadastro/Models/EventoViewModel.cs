using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.ViewModels
{
    public class EventoViewModel
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumeroParticipantes { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}