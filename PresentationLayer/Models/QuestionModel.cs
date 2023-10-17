using BusinessLayer.AuxiliaryClasses;

namespace PresentationLayer.Models
{
    public class QuestionModel
    {
        public string QuestionText { get; init; }
        public double NumberOfPoints { get; init; }
        public bool IsRight { get; init; }
        public ICollection<AnswerModel> Answers { get; init; }
        public bool MultipleAnswerOptions { get; init; }

        public QuestionModel(QuestionHtmlNodes questionNodes) 
        {
            QuestionText = questionNodes.QuestionText;
            NumberOfPoints = questionNodes.NumberOfPoints;
            IsRight = questionNodes.IsRight;
            Answers = questionNodes.AnswerOptions.Select(answerNode => new AnswerModel(answerNode, this)).ToList();
            MultipleAnswerOptions = questionNodes.MultipleAnswerOptions;
        }

        public override string ToString()
        {
            return $"{QuestionText} {NumberOfPoints}";
        }
    }
}
