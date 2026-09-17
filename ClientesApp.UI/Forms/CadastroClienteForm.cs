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

      
    }
}
