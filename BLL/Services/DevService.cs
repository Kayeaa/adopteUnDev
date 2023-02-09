using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper;
using BLL.Entities;
using Common.Repositories;

namespace BLL.Services
{
    public class DevService : IDeveloperRepository<Developer, int>

    {
        private readonly IDeveloperRepository<DAL.Entities.Developer, int> _repository;

        public DevService(IDeveloperRepository<DAL.Entities.Developer, int> DevRepository)
        {
            _repository = DevRepository;
        }

        public IEnumerable<Developer> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Developer Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Developer entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Update(int id, Developer entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }
    }
}
