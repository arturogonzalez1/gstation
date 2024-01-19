using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public string FullName {  
            get 
            {
                var completeNameList = new List<string>
                {
                    Name,
                    PaternalSurname,
                    MaternalSurname
                };

                return string.Join(" ", completeNameList.Where(item => !string.IsNullOrEmpty(item)));
            } 
        }
    }
}
