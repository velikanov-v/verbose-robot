using System.Collections.Generic;

namespace SecondProject.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }       
        
        public List<Group> Groups { get; set; }
    }
}
