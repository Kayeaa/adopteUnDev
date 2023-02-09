using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using Common.Repositories;
using Mapper;

namespace BLL.Services
{
    public class ITLangService : IRepository<ITLang, int>
    {
        private readonly IITLangRepository<DAL.Entities.ITLang, int> _repository;

        public ITLangService(IITLangRepository<DAL.Entities.ITLang, int> ITLangRepository)
        {
            _repository = ITLangRepository;
        }

        public IEnumerable<ITLang> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public ITLang Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(ITLang entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Update(int id, ITLang entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }
    }
}
