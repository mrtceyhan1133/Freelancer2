using Freelancer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelancer.Models.ViewModels
{
    public class JobAdvertisementViewModel
    {
        public List<JobAdvertisement> JobAdvertisements { get; set; }
        public string AdvertisementName { get; set; }
        public string Explanation { get; set; }
        public string EmployerName { get; set; }
        public string EmployerUserName { get; set; }
        public string Category { get; set; }
    }
}