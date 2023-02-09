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
    public class CategoryService : ICategoryRepository<Categories, int>
    {
        private readonly ICategoryRepository<DAL.Entities.Categories, int> _repository;

        public CategoryService(ICategoryRepository<DAL.Entities.Categories, int> CategRepository)
        {
            _repository = CategRepository;
        }

        public IEnumerable<Categories> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Categories Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Categories entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Update(int id, Categories entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }
    }
}
