namespace CinemaClub.Web.Models
{
    public class Member
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
