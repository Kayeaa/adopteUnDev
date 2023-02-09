using BLL.Entities;
using Common.Repositories;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClientService : IClientRepository <Client, int>
    {

        private readonly IClientRepository<DAL.Entities.Client, int > _repository;

        public ClientService(IClientRepository<DAL.Entities.Client,int>ClientRepository)
        {
            _repository = ClientRepository;
        }

        public IEnumerable<Client> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Client Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Client entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Update(int id, Client entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }

        public int? CheckPassword(string CliLogin, string CliPassword)
        {
            return _repository.CheckPassword(CliLogin, CliPassword);
        }
    }
}
