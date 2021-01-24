using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInAPI.Models
{
    public class Records
    {
        public int ID { get; set; }
        public string StudentSession { get; set; }
        public string CheckInSession { get; set; }
        public string CheckTime { get; set; }
        public string Name { get; set; }
        public string Session { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string RegistTime { get; set; }
    }
}
