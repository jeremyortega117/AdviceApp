namespace AdviceLib.Models
{
    public class Questions1
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public int? Account_ID { get; set; }
        public int Upvotes { get; set; }
        public int Visited { get; set; }
    }
}