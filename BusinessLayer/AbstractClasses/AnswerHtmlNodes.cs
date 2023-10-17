using DataLayer.Enums;
using HtmlAgilityPack;

namespace BusinessLayer.AuxiliaryClasses
{
    public abstract class AnswerHtmlNodes
    {
        private IEnumerable<HtmlNode>? _answersNodes;
        public IEnumerable<HtmlNode>? AnswersNodes
        {
            get { return _answersNodes; }
            init
            {
                if (_questionСontentNode != null)
                {
                    _answersNodes = _questionСontentNode.ChildNodes
                    .Where(s => s.Attributes[0].Value == "formulation clearfix")
                    .Select(s => s.ChildNodes
                    .Where(s => s.Attributes[0].Value.StartsWith("ablock"))).First()
                    .Select(s => s.ChildNodes
                    .Where(s => (s.Attributes[0].Value.EndsWith("answer")))).First()
                    .First().ChildNodes.Where(s => s.Name != "#text").ToList();
                }
            }
        }

        public abstract string? AnswerText { get; init; }
        public abstract AnswerStatus AnswerStatus { get; init; }
        public abstract QuestionHtmlNodes Question { get; init; }

        private readonly HtmlNode? _questionСontentNode;
        public AnswerHtmlNodes(HtmlNode questionСontentNode)
        {
            _questionСontentNode = questionСontentNode;
            AnswersNodes = default;
        }

        public AnswerHtmlNodes() { }
    }
}
