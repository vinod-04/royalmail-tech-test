using System.Collections.Generic;

namespace people.api.Models
{
    public class People
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }

        public List<PersonSkill> PersonSkills { get; set; }
    }
}
