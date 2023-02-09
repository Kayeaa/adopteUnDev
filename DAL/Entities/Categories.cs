using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Categories : ICategories
    {
        public int idCategory { get; set; }
        public string CategLabel { get; set; }
    }
}
