using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SabeNaoSabe.RazorClassLibrary.Models
{
    public class QuestionarioModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Corpo { get; set; }

        public string? Guids { get; set; }
    }
}
