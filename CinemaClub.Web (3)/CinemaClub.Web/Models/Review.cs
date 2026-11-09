namespace CinemaClub.Web.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int? Score { get; set; }
        public string Text { get; set; }
        public DateOnly Date { get; set; }
        public long? Movie_id { get; set; }
        public virtual Movie Movie { get; set; }
        public long? Member_id { get; set; }
        public virtual Member Member { get; set; }
    }
}
