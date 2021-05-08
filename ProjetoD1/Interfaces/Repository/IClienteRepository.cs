using ProjetoD1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoD1.Interfaces.Repository
{
    public interface IClienteRepository
    {
        public Task<IEnumerable<ClienteModel>> GetAll();
        public Task<ClienteModel> Create(ClienteModel cliente);
        public Task<IEnumerable<ClienteModel>> GetByName(string name);
        public Task<ClienteModel> GetById(string id);
        public Task Update(ClienteModel cliente);

    }
}
