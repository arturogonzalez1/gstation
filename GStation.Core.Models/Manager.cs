using GStation.Core.Models.Enums;

namespace GStation.Core.Models
{
    public class Manager
    {
        public Guid Id { get; set; 
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Team> Vehicles { get; set; }
    }
}


