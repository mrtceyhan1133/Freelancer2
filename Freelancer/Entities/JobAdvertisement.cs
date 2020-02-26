using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class JobAdvertisement
    {
        public int Id { get; set; }
        public string AdvertisementName { get; set; }
        public string Explanation { get; set; }
        public virtual List<CategoryJobAdvertisement> CategoryJobAdvertisements { get; set; }
        public virtual List<SkillJobAdvertisement> SkillJobAdvertisements { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }




    }
}