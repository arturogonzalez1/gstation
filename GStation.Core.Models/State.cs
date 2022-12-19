namespace GStation.Core.Models
{
    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
