

namespace SecondProject.Models
{
    public class GroupsWorkers
    {
        
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        
        public int GroupId { get; set; }
        public Group Group { get; set; }
}
}
