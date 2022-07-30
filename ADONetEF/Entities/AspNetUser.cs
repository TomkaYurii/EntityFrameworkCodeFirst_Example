using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetEF.Enteties
{
    public class AspNetUser
    {
        public int Id { get; set; }

        //n-n
        public List<Team>? Teams { get; set; }

        //1-n
        public List<Team>? Teamsnavigation { get; set; }





        public List<Ticket>? Tickets { get; set; }

        


        public List<Rating> RatingsToMe { get; set; }
       
        public List<Rating> RatingsFromMe { get; set; }
    }
}
