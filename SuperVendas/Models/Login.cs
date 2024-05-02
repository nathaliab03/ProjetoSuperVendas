using System.ComponentModel.DataAnnotations;

namespace SuperVendas.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Display(Name = "Usuário")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 3 caracteres")]
        public string? Username { get; set; }

        [Display(Name = "Senha")]
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Mínimo de 6 e máximo de 15 caracteres")]
        public string? Password { get; set; }

        public int AccessLevelId { get; set; }
        public AccessLevel? AccessLevel { get; set; }
    }
}
