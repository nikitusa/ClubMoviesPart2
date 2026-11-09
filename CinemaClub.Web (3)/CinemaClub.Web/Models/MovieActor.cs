namespace CinemaClub.Web.Models
{
    public class MovieActor
    {

        public int Movie_id { get; set; }
        public int Actor_id { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
        
    }
}
