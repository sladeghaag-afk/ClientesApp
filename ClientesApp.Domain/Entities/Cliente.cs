using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Domain.Entities
{
    public class Cliente
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
        public DateTime? DataHoraAlteracao { get; set; }
    }
}
