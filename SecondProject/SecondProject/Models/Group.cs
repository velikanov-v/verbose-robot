using System.Collections.Generic;

namespace SecondProject.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }             
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }  
        public Course Course { get; set; }
        public List<GroupsWorkers> GroupWorkers { get; set; }
    }
}
