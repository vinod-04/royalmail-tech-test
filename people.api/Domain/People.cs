using System.Collections.Generic;

namespace people.api.Domain
{
    public partial class People
    {
        public People()
        {
            PersonSkills = new HashSet<PersonSkills>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<PersonSkills> PersonSkills { get; set; }
    }
}
