using System.ComponentModel.DataAnnotations;

namespace SuperVendas.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Nome da Categoria")]
        [Required]
        public string? CategoryName { get; set; }
    }
}
