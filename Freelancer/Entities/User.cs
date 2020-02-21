using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public double Rating { get; set; }
        public virtual List<UserSkill> UserSkills { get; set; }
        public virtual List<JobAdvertisement> JobAdvertisements { get; set; }


    }
}