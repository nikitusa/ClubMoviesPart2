namespace CinemaClub.Web.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Director_id { get; set; }
        public Director? Director { get; set; } = null!;
        public Actor? Actor { get; set; } = null;
        public ICollection<Review> Reviews { get; set; }
        public List<MovieActor> MovieActors { get; set; }
    }
}
