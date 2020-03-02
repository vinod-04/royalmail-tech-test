namespace people.api.Models
{
    public class PersonSkill
    {
        public int PersonId { get; set; }
        public int SkillId { get; set; }

        public People Person { get; set; }
        public Skill Skill { get; set; }
    }
}
