using System.ComponentModel.DataAnnotations;

namespace SuperVendas.Models
{
    public class AccessLevel
    {

        [Key]
        public int AccessLevelId { get; set; }

        [Display(Name = "Nome do acesso")]
        [Required]
        public string? AccessLevelName { get; set; }

        [Display(Name = "Tipo de acesso")]
        [Required]
        public string? AccessLevelType { get; set; }
    }
}
