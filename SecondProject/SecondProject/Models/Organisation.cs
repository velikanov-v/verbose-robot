using System.Collections.Generic;

namespace SecondProject.Models
{
    public class Organisation
    {
        public int OrganisationId { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }

        public List<Worker> Workers { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
