using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPol.Models
{
    internal class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coefficient { get; set; }
        public List<Product> Products { get; set;} = [];
    }
}
