using System.ComponentModel.DataAnnotations;

namespace SuperVendas.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required]
        public string? ProductName { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Display(Name = "Marca")]
        [Required]
        public string? ProductBrand { get; set; }

        [Display(Name = "Modelo")]
        public string? ProductModel { get; set; }

        [Display(Name = "Preço")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        [Required]
        public decimal? Price { get; set; }

        [Display(Name = "Quantidade em Estoque")]
        public int Stock { get; set; }
    }
}
