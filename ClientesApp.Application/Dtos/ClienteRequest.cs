using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Application.Dtos
{
    public class ClienteRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
