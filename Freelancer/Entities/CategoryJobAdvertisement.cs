using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelancer.Entities
{
    public class CategoryJobAdvertisement
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int JobAdvertisementId { get; set; }
        public virtual Category Category { get; set; }
        public virtual JobAdvertisement JobAdvertisement { get; set; }

    }
}