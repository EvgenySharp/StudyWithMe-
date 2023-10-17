namespace DataLayer.Entityes
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public double NumberOfPoints { get; set; }
        public bool IsRight { get; set; }
        public ICollection<Answer>? Answers { get; set; }
        public bool MultipleAnswerOptions { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
