using MongoDB.Bson;
using MongoDB.Driver;
using ProjetoD1.Interfaces.Repository;
using ProjetoD1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoD1.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MongoContext _context;

        public ClienteRepository(MongoContext context)
        {
            _context = context;
              
        }
        //-- ToDo - Fazer melhorias de TASK/Async/await nos métodos
        public async Task<ClienteModel> Create(ClienteModel cliente)
        {            
            cliente.Nome = cliente.Nome.ToUpper();
            await _context.ClienteDB.InsertOneAsync(cliente);
            return cliente;
        }

        public async Task<IEnumerable<ClienteModel>> GetAll()
        {
            var clientes = await _context.ClienteDB.Find(cliente => true).ToListAsync();
            return clientes;
        }

        public async Task<IEnumerable<ClienteModel>> GetByName(string name)
        {
            var cliente = await _context.ClienteDB
                .Find(cliente => cliente.Nome.Contains(name.ToUpper()))
                .ToListAsync();

            return cliente;
        }

        public async Task<ClienteModel> GetById(string id)
        {            
            var cliente = await _context.ClienteDB
                .Find(cliente => cliente.Id.Equals(ObjectId.Parse(id)))
                .FirstOrDefaultAsync();

            return cliente;
            
        }
        public async Task Update(ClienteModel cliente)
        {
            cliente.Nome = cliente.Nome.ToUpper();            
            
            var filter = Builders<ClienteModel>.Filter.Where(c => c.Id.Equals(ObjectId.Parse(cliente.Id)));
            await _context.ClienteDB.ReplaceOneAsync(filter, cliente);
        }

    }
}
