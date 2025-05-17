using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPol.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public int Article {  get; set; }
        public decimal MinPrice { get; set; }
    }
}
