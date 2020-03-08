using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class Employer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required][Column("User Name")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual List<JobAdvertisement> JobAdvertisements { get; set; }
    }
}