using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.Dto
{
    public class EditarContatoDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O telefone deve ter 11 dígitos, incluindo o DDD.")]
        public string Telefone { get; set; }
    }
}