using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProject.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public int GroupNumber { get; set; }
        public string Teacher { get; set; }  
        public ICollection<Student> Students { get; set; }
    }
}
