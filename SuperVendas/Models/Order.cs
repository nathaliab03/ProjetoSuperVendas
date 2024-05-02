using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperVendas.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ClientId { get; set; }

        [Display(Name = "Cliente")]
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }

        public int EmployeeId { get; set; }

        [Display(Name = "Funcionário")]
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Display(Name = "Quantidade")]
        [Required]
        public int Quantity { get; set; }

        [Display(Name = "Preço")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public decimal Price { get; set; }


        [Display(Name = "Forma de Pagamento")]
        [Required]
        public string? PaymentMethod { get; set; }
    }
}
