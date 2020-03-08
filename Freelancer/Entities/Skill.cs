using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<SkillJobAdvertisement> SkillJobAdvertisements { get; set; }
        public virtual List<WorkerSkill> WorkerSkills { get; set; }

    }
}