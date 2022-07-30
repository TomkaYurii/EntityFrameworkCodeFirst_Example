using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetEF.Enteties
{
    public class Project
    {
        public int Id { get; set; }


        public List<Ticket> Tickets { get; set; }


        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
