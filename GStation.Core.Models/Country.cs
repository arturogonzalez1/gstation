namespace GStation.Core.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public ICollection<State> States { get; set; }
    }
}
