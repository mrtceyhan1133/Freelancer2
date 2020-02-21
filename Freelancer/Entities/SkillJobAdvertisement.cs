namespace Freelancer.Entities
{
    public class SkillJobAdvertisement
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int JobAdvertisementId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual JobAdvertisement JobAdvertisement { get; set; }
        
    }
}