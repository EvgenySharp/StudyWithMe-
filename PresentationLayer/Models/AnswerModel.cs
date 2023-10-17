using BusinessLayer.AuxiliaryClasses;
using DataLayer.Enums;

namespace PresentationLayer.Models
{
    public class AnswerModel
    {
        public string AnswerText { get; init; }
        public AnswerStatus AnswerStatus { get; init; }
        public QuestionModel Question { get; init; }
        public AnswerModel(AnswerHtmlNodes answerNodes, QuestionModel question)
        {
            Question = question;
            AnswerText = answerNodes.AnswerText;
            AnswerStatus = answerNodes.AnswerStatus;
        }

        public override string ToString()
        {
            var s = AnswerStatus is AnswerStatus.NoData ? "no data" : AnswerStatus.ToString();
            return $"{AnswerText}  {s}";
        }
    }
}
