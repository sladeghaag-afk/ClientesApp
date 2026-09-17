using ClientesApp.Application.Dtos;
using ClientesApp.Application.Interfaces;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteDomainService _clienteDomainService;

        public ClienteAppService(IClienteDomainService clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }

        public async Task<ClienteResponse> AddAsync(
            ClienteRequest request)
        {
            var cliente = new Cliente
            {
                Nome = request.Nome,
                Email = request.Email
            };

            var resultado =
                await _clienteDomainService
                    .CadastrarAsync(cliente);

            return Mapear(resultado);
        }

        public async Task<ClienteResponse> UpdateAsync(
            string id,
            ClienteRequest request)
        {
            var cliente = new Cliente
            {
                Nome = request.Nome,
                Email = request.Email
            };

            var resultado =
                await _clienteDomainService
                    .AtualizarAsync(
                        id,
                        cliente);

            return Mapear(resultado);
        }

        public async Task DeleteAsync(
            string id)
        {
            await _clienteDomainService
                .ExcluirAsync(id);
        }

        public async Task<ClienteResponse> GetByIdAsync(
            string id)
        {
            var cliente =
                await _clienteDomainService
                    .ConsultarPorIdAsync(id);

            return Mapear(cliente);
        }

        public async Task<List<ClienteResponse>> GetAllAsync()
        {
            var clientes =
                await _clienteDomainService
                    .ConsultarAsync();

            return clientes
                .Select(cliente => Mapear(cliente))
                .ToList();
        }

        private static ClienteResponse Mapear(
            Cliente cliente)
        {
            return new ClienteResponse
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                DataHoraCadastro =
                    cliente.DataHoraCadastro,
                DataHoraAlteracao =
                    cliente.DataHoraAlteracao
            };
        }
    }
}
