using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SabeNaoSabe.WebAPI.Model
{
    public class QuestionarioModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public string Email { get; set;}
        [Required]
        public string Corpo { get; set; }
    }
}
