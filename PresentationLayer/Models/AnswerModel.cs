using BusinessLayer.AuxiliaryClasses;

namespace PresentationLayer.Models
{
    public class AnswerModel
    {
        public string AnswerText { get; init; }
        public bool? IsRight { get; init; }
        public QuestionModel Question { get; init; }
        public AnswerModel(AnswerHtmlNodes answerNodes, QuestionModel question) 
        {
            Question = question;
            AnswerText = answerNodes.AnswerText;
            IsRight = answerNodes.IsRight;
        }

        public override string ToString()
        {
            var s = IsRight is null ? "no data" : IsRight.ToString();
            return $"{AnswerText}  {s}";
        }
    }
}
