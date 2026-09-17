using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> CadastrarAsync(Cliente cliente)
        {
            Validar(cliente);

            var email = cliente.Email.Trim().ToLower();

            var emailExiste = await _clienteRepository.ExisteEmailAsync(email);

            if (emailExiste)
                throw new ApplicationException("O email informado já está cadastrado.");

            cliente.Id = Guid.NewGuid().ToString();
            cliente.Nome = cliente.Nome.Trim();
            cliente.Email = email;
            cliente.DataHoraCadastro = DateTime.UtcNow;
            cliente.DataHoraAlteracao = null;

            await _clienteRepository.AddAsync(cliente);

            return cliente;
        }

        public async Task<Cliente> AtualizarAsync(string id, Cliente cliente)
        {
            var clienteAtual = await _clienteRepository.GetByIdAsync(id);

            if (clienteAtual == null)
                throw new ApplicationException("Cliente não encontrado.");

            Validar(cliente);

            var email = cliente.Email.Trim().ToLower();

            /*
             * Verifica se existe outro cliente
             * usando o mesmo email.
             *
             * O idIgnorar faz com que o próprio
             * cliente não seja considerado.
             */
            var emailExiste = await _clienteRepository.ExisteEmailAsync(email, id);

            if (emailExiste)
                throw new ApplicationException("O email informado já pertence a outro cliente.");

            clienteAtual.Nome = cliente.Nome.Trim();
            clienteAtual.Email = email;
            clienteAtual.DataHoraAlteracao = DateTime.UtcNow;

            await _clienteRepository.UpdateAsync(clienteAtual);

            return clienteAtual;
        }

        public async Task ExcluirAsync(
            string id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado.");

            await _clienteRepository.DeleteAsync(id);
        }

        public async Task<Cliente> ConsultarPorIdAsync(string id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado.");

            return cliente;
        }

        public async Task<List<Cliente>> ConsultarAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        private static void Validar(Cliente cliente)
        {
            if (cliente == null)
                throw new ApplicationException("Cliente não informado.");

            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                throw new ApplicationException("Informe o nome do cliente.");
            }

            if (cliente.Nome.Trim().Length < 3)
            {
                throw new ApplicationException("O nome deve possuir pelo menos 3 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Email))
            {
                throw new ApplicationException("Informe o email do cliente.");
            }

            if (!cliente.Email.Contains("@"))
            {
                throw new ApplicationException("Informe um email válido.");
            }
        }

        public Task<Cliente> Cadastrar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Atualizar(string id, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ConsultarPorId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> Consultar()
        {
            throw new NotImplementedException();
        }
    }
}
