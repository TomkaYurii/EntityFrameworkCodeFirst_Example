using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetEF.Enteties
{
    public class Team
    {
        public int Id { get; set; }


        public int? LeaderId { get; set; }
        public AspNetUser? Leader { get; set; }


        public List<AspNetUser>? Members { get; set; }


        public List<Project>? Projects { get; set; }
    }
}
