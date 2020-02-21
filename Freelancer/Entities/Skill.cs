using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<SkillJobAdvertisement> SkillJobAdvertisement { get; set; }
        public virtual List<UserSkill> UserSkill { get; set; }

    }
}