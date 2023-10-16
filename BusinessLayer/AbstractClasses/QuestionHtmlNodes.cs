using BusinessLayer.Interfaces;
using HtmlAgilityPack;

namespace BusinessLayer.AuxiliaryClasses
{
    public abstract class QuestionHtmlNodes
    {
        private HtmlNode? _questionInfoNode;
        public virtual HtmlNode? QuestionInfoNode
        {
            get { return _questionInfoNode; }
            init
            {
                if (_questionNodes != null) 
                { 
                    var questionInfoNodes =
                    from ChildNode in _questionNodes.ChildNodes
                    from Attribute in ChildNode.Attributes
                    where Attribute.Value == "info"
                    select ChildNode;
                    _questionInfoNode = questionInfoNodes.First();
                }
            }
        }

        private HtmlNode? _questionСontentNode;
        public virtual HtmlNode? QuestionСontentNode
        {
            get { return _questionСontentNode; }
            init
            {
                if (_questionNodes != null)
                {
                    var questionСontentNodes =
                    from ChildNode in _questionNodes.ChildNodes
                    from Attribute in ChildNode.Attributes
                    where Attribute.Value == "content"
                    select ChildNode;
                    _questionСontentNode = questionСontentNodes.First();
                }
            }
        }

        public virtual string? QuestionModifier { get; init; }
        public abstract string? QuestionText { get; init; }
        public abstract double NumberOfPoints { get; init; }
        public abstract bool IsRight { get; init; }
        public abstract ICollection<AnswerHtmlNodes> AnswerOptions { get; init; }
        public abstract bool MultipleAnswerOptions { get; init; }

        private readonly HtmlNode? _questionNodes;
        public QuestionHtmlNodes(HtmlNode questionNodes)
        {
            _questionNodes = questionNodes;
            QuestionInfoNode = default;
            QuestionСontentNode = default;
            QuestionModifier = questionNodes.Attributes[1].Value;            
        }
    }
}
