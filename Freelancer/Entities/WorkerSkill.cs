namespace Freelancer.Entities
{
    public class WorkerSkill
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual Worker Worker { get; set; }
    }
}