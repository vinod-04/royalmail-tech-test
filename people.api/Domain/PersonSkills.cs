using System;
using System.Collections.Generic;

namespace people.api.Domain
{
    public partial class PersonSkills
    {
        public int PersonId { get; set; }
        public int SkillId { get; set; }

        public virtual People Person { get; set; }
        public virtual Skills Skill { get; set; }
    }
}
