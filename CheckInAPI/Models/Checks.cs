using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInAPI.Models
{
    public class Checks
    {
        public int ID { get; set; }
        public string ClassRoom { get; set; }
        public string Session { get; set; }
        public string Description { get; set; }
        public string TeacherSession { get; set; }

    }
}
