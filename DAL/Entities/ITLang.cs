using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ITLang : IITLang
    {
        public int idIT { get; set; }
        public string ITLabel { get; set; }
    }
}
