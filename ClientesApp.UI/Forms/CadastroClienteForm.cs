using System.ComponentModel.DataAnnotations;

namespace ClientesApp.UI.Forms
{
    public class CadastroClienteForm
    {
        [MinLength(6, ErrorMessage = "O nome deve ter pelo menos {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string? Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O cpf deve ter exatamente 11 dígitos numéricos.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string? Cpf { get; set; }
    }
}
