using System.Collections.Generic;

namespace SecondProject.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public List<Organisation> Organisations { get; set; }
        public List<Group> Groups { get; set; }

    }
}