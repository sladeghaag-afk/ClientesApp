using ClientesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(string id);
        Task<Cliente?> GetByIdAsync(string id);
        Task<List<Cliente>> GetAllAsync();
        Task<bool> ExisteEmailAsync(string email, string? idIgnorar = null);
    }
}
