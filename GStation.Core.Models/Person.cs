namespace GStation.Core.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string PaternalSurname { get; set; }
        public string MaternalSurname { get; set; }
        public string PhoneNumber { get; set; }
        public ApplicationUser User { get; set; }
    }
}
