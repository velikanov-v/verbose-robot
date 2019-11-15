using System.Collections.Generic;

namespace SecondProject.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }      
        public List<GroupsWorkers> GroupWorkers { get; set; }
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        
        
    }
}
