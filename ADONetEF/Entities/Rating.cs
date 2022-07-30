namespace ADONetEF.Enteties
{
    public class Rating
    {
        public int Id { get; set; }


        public int ToId { get; set; }
        public AspNetUser? To { get; set; }


        public int FromId { get; set; }
        public AspNetUser? From { get; set; }


    }
}
