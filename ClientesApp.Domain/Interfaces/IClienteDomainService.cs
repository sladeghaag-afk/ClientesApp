
using ClientesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Domain.Interfaces
{
    public interface IClienteDomainService
    {
        Task<Cliente> CadastrarAsync(Cliente cliente);
        Task<Cliente> AtualizarAsync(string id, Cliente cliente);
        Task ExcluirAsync(string id);
        Task<Cliente> ConsultarPorIdAsync(string id);
        Task<List<Cliente>> ConsultarAsync();
    }
}

