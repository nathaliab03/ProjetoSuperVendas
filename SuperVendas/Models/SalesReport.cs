using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperVendas.Models
{
    public class SalesReport
    {
        public int SalesReportId { get; set; }

        [Display(Name = "Data Inicial")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Data Final")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set;}

        public int ProductId {  get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Display(Name = "Quantidade")]
        public double SalesTotal { get; set; }

        [Display(Name = "Soma total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public decimal SalesRevenue { get; set; }

    }
}
