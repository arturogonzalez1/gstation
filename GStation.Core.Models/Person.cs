namespace GStation.Core.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PaternalSurname { get; set; }
        public string MaternalSurname { get; set; }
        public string PhoneNumber { get; set; }
        public ApplicationUser User { get; set; }
    }

    public static class PersonExtensions
    {
        public static string GetCompleteName(this Person person)
        {
            var completeNameList = new List<string>
            { 
                person.Name, 
                person.PaternalSurname, 
                person.MaternalSurname 
            };

            var completeName = string.Join(" ", completeNameList.Where(item => !string.IsNullOrEmpty(item)));

            return completeName;
        }
    }
}
