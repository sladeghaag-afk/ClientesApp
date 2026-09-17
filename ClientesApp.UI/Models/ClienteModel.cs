namespace ClientesApp.UI.Models
{

       public class ClienteModel
        {
            public string Id { get; set; } = string.Empty;
            public string Nome { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public DateTime DataHoraCadastro { get; set; }
            public DateTime? DataHoraAlteracao { get; set; }

        }
}