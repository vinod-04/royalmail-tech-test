using System;
using System.Collections.Generic;

namespace people.api.Domain
{
    public partial class Skills
    {
        public Skills()
        {
            PersonSkills = new HashSet<PersonSkills>();
        }

        public int SkillId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<PersonSkills> PersonSkills { get; set; }
    }
}
