using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class JobAdvertisement
    {
        public int Id { get; set; }
        [Required][Column("Advertisement Name")][Display(Name ="Advertisement Name")]
        public string AdvertisementName { get; set; }
        [Required]
        public string Explanation { get; set; }
        public virtual List<CategoryJobAdvertisement> CategoryJobAdvertisements { get; set; }
        public virtual List<SkillJobAdvertisement> SkillJobAdvertisements { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }




    }
}