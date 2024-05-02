using System.ComponentModel.DataAnnotations;

namespace SuperVendas.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome deve ser preenchido")]
        public string? ClientName { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF deve ser preenchido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 números")]
        [RegularExpression(@"^\d{11}$")]
        public string? Cpf { get; set; }

        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage = "Data deve ser preenchida")]
        [RegularExpression(@"^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|          (29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$", ErrorMessage = "Data invalida")]
        public string? DateOfBirth { get; set; }

        [Display(Name = "Telefone de Contato")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Telefone Inválido")]
        public string? ContactNumber { get; set; }

        [Display(Name = "Endereço")]
        public string? Address { get; set; }

        [Display(Name = "Número")]
        public string? AddressNumber { get; set; }

        [Display(Name = "Complemento")]
        public string? AddressLine { get; set; }

        [Display(Name = "Cidade")]
        public string? City { get; set; }

        [Display(Name = "Estado")]
        public string? State { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O Email deve ser preenchido")]
        public string? Email { get; set; }
    }   
}
