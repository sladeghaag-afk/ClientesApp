using ClientesApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<ClienteResponse> AddAsync(ClienteRequest request);
        Task<ClienteResponse> UpdateAsync(string id, ClienteRequest request);
        Task DeleteAsync(string id);
        Task<ClienteResponse> GetByIdAsync(string id);
        Task<List<ClienteResponse>> GetAllAsync();
    }
}
