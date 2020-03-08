using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        [Required][StringLength(30)]
        public string Name { get; set; }
        [Required][StringLength(30)]
        public string Surname { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required][StringLength(20)]
        public string UserName { get; set; }
        public double? Rating { get; set; } = null;
        [Required]
        public string Email { get; set; }
        public virtual List<WorkerSkill> WorkerSkills { get; set; }
        


    }
}