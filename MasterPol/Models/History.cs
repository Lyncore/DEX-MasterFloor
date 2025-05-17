using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPol.Models
{
    internal class History
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
