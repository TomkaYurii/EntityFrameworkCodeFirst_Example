using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetEF.Enteties
{
    public class Ticket
    {
        public int Id { get; set; }


        public int ExecutorId { get; set; }
        public AspNetUser? Executor { get; set; }


        public int ProjectId { get; set; }
        public Project? Project { get; set; }

    }
}
