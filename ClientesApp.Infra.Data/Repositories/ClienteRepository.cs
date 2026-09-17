using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Infra.Data.Repositories
{
    internal class ClienteRepository : IClienteRepository
    {
        //Mapeamento da entidade para o banco de dados
        private readonly IMongoCollection<Cliente> _collection;

        //Método construtor
        public ClienteRepository(string connectionString, string databaseName)
        {
            ConfigurarMapeamento();

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(databaseName);

            _collection = database.GetCollection<Cliente>("clientes");
        }

        private static void ConfigurarMapeamento()
        {
            if (!BsonClassMap.IsClassMapRegistered(
                    typeof(Cliente)))
            {
                BsonClassMap.RegisterClassMap<Cliente>(
                    classMap =>
                    {
                        classMap.AutoMap();

                        classMap.MapIdMember(
                            cliente => cliente.Id);
                    });
            }
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _collection.InsertOneAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c.Id, cliente.Id);
            await _collection.ReplaceOneAsync(filtro, cliente);
        }

        public async Task DeleteAsync(string id)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            await _collection.DeleteOneAsync(filtro);
        }

        public async Task<Cliente?> GetByIdAsync(string id)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            return await _collection.Find(filtro).FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _collection.Find(Builders<Cliente>.Filter.Empty)
                .SortBy(c => c.Nome)
                .ToListAsync();
        }

        public async Task<bool> ExisteEmailAsync(string email, string? idIgnorar = null)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c.Email, email);

            if (!string.IsNullOrWhiteSpace(idIgnorar))
            {
                filtro &= Builders<Cliente>.Filter.Ne(c => c.Id, idIgnorar);
            }

            return await _collection
                .Find(filtro)
                .AnyAsync();
        }
    }
}
