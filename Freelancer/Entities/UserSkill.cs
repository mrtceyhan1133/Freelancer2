﻿namespace Freelancer.Entities
{
    public class UserSkill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual User User { get; set; }
    }
}