using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInAPI.Models
{
    public class CheckInRecord
    {
        public int ID { get; set; }
        public string StudentSession { get; set; }
        public string CheckInSession { get; set; }
        public string CheckTime { get; set; }
    }
}
