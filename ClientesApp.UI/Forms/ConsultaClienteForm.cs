using System.ComponentModel.DataAnnotations;

namespace ClientesApp.UI.Forms
{
    public class ConsultaClienteForm
    {
        [MinLength(3, ErrorMessage = "O nome do cliente deve ter pelo menos 3 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do cliente para realizar a pesquisa.")]
        public string? Nome { get; set; }
    }
}
