using BusinessLayer.AuxiliaryClasses;
using HtmlAgilityPack;

namespace BusinessLayer.Implementations
{
    public class AnswerHAP : AnswerHtmlNodes
    {
        public override string? AnswerText { get; init; }
        public override bool? IsRight { get; init; }
        public override QuestionHtmlNodes Question { get; init; }

        private readonly string? _questionModifier;
        private readonly IEnumerable<HtmlNode>? _answersNodes;
        private readonly double _numberofpoints;

        public AnswerHAP(QuestionHtmlNodes question) : base(question.QuestionСontentNode)
        {
            Question = question;
            _answersNodes = AnswersNodes;
            _questionModifier = question.QuestionModifier;
            _numberofpoints = question.NumberOfPoints;
        }

        public AnswerHAP(string answerText, bool? isRight, QuestionHtmlNodes question) : base()
        {
            Question = question;
            AnswerText = answerText;
            IsRight = isRight;
        }

        public override string ToString()
        {
            if (IsRight == null) return $"{AnswerText} нет данных";
            return $"{AnswerText} {Convert.ToBoolean(IsRight)}";
        }

        public List<AnswerHtmlNodes> GetAnswerList()
        {
            List<AnswerHtmlNodes> Answers = new List<AnswerHtmlNodes>();
            if (_questionModifier != null && _answersNodes != null)
            {
                string[] words = _questionModifier.Split(' ');
                string questionResult = words[words.Length - 1];
                foreach (var answer in _answersNodes)
                {
                    string answerResult = string.Empty;
                    string answerText = string.Empty;
                    bool? isRight;
                    bool isWrong;
                    if (_questionModifier.StartsWith("que multichoice deferredfeedback"))
                    {
                        int answerResIndex = 0;
                        answerResult = answer.Attributes[answerResIndex].Value.Split(" ")[0];
                        answerText = answer.InnerText;
                    }
                    else if (_questionModifier.StartsWith("que shortanswer deferredfeedback"))
                    {
                        answerResult = GetAnswerResultForShortAnswer(answer);
                        answerText = GetAnswerTextForShortAnswer(answer);
                    }
                    isRight = answerResult == "correct";
                    isWrong = answerResult == "incorrect";
                    if (questionResult == "complete")
                    {
                        if (IsChosenAnswer(answer))
                        {
                            if (_numberofpoints > 0.00d)
                            {
                                isRight = true;
                            }
                            else
                            {
                                isWrong = true;
                            } 
                        }

                    }
                    if (isWrong == false && isRight == false)
                    {
                        isRight = null;
                    }
                    Answers.Add(new AnswerHAP(answerText, isRight, Question));
                }
            }
            
            return Answers;
        }

        private string GetAnswerTextForShortAnswer(HtmlNode answer)
        {
            var enumAnswerText =
                from answerChildNode in answer.ChildNodes
                from answChlAttribute in answerChildNode.Attributes
                where answChlAttribute.Name == "value"
                select answChlAttribute.Value;
            return enumAnswerText.First();
        }

        private string GetAnswerResultForShortAnswer(HtmlNode answer)
        {
            var enumAnswerResult =
                from answerChildNode in answer.ChildNodes
                from cntChlAttribute in answerChildNode.Attributes
                where cntChlAttribute.Name == "class"
                select cntChlAttribute.Value;
            return enumAnswerResult.First().Split(' ').Last();
        }

        private bool IsChosenAnswer(HtmlNode answer)
        {
            var result = false;
            var chosenAnswerNode =
                from answerChildNode in answer.ChildNodes
                from chlAttribute in answerChildNode.Attributes
                where chlAttribute.Name == "checked" && chlAttribute.Value == "checked"
                select answer;
            if (chosenAnswerNode.Any())
                result = true;
            return result;
        }
    }
}
