using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPol.Models
{
    internal class Partner
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public string DirectorMail { get; set; }
        public string DirectorPhone { get; set; }
        public string Address { get; set; }
        public long INN { get; set; }
        public string Avatar { get; set; }
        public int Rating { get; set; }
        public List<History> History { get; set; } = [];
    }
}
