using BusinessLayer.AuxiliaryClasses;
using BusinessLayer.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class QuestionHAP : QuestionHtmlNodes
    {
        private string? _questionText;
        public override string? QuestionText
        {
            get { return _questionText; }
            init
            {
                var questionСontentNodes = QuestionСontentNode;
                if (questionСontentNodes != null)
                {
                    var questionText =
                    from contentChildNode in questionСontentNodes.ChildNodes
                    from cntChlAttribute in contentChildNode.Attributes
                    where cntChlAttribute.Value == "formulation clearfix"
                    from formulationChildNoden in contentChildNode.ChildNodes
                    from frmChildAttributen in formulationChildNoden.Attributes
                    where frmChildAttributen.Value == "qtext"
                    select formulationChildNoden.InnerText;
                    _questionText = questionText.First();
                }

            }
        }

        private double _numberofpoints;
        public override double NumberOfPoints
        {
            get { return _numberofpoints; }
            init
            {
                if (_questionTitle != null)
                {
                    int scoreIndex = 2;
                    string score = _questionTitle[scoreIndex];
                    Regex regex = new Regex(@"\d+,\d+");
                    MatchCollection matches = regex.Matches(score);
                    int actScoreIdex = 0;
                    int maxScoreIdex = 1;
                    double actualScore = double.Parse(matches[actScoreIdex].Value);
                    // TODO
                    double maximumScore = double.Parse(matches[maxScoreIdex].Value);
                    _numberofpoints = actualScore;
                }
            }
        }

        private bool _isRight;
        public override bool IsRight
        {
            get { return _isRight; }
            init
            {
                if (_questionTitle != null)
                {
                    int statusIndex = 1;
                    string status = _questionTitle[statusIndex];
                    if (status == "Выполнен")
                        if (NumberOfPoints > 0.00d)
                            _isRight = true;
                        else if (status == "Верно")
                            _isRight = true;
                        else if (status == "Неверно")
                            _isRight = false;
                }
            }
        }

        private ICollection<AnswerHtmlNodes>? _answerOptions;
        public override ICollection<AnswerHtmlNodes>? AnswerOptions
        {
            get { return _answerOptions; }
            init
            {
                var answer = new AnswerHAP(this);
                _answerOptions = answer.GetAnswerList();
            }
        }
        // TODO
        private bool _multipleAnswerOptions;
        public override bool MultipleAnswerOptions { get; init; }

        private readonly string[]? _questionTitle;
        public QuestionHAP(HtmlNode questionNodes) : base(questionNodes)
        {
            QuestionText = default;
            if (QuestionInfoNode != null) 
            { 
                _questionTitle = QuestionInfoNode.ChildNodes
                    .Select(s => s.InnerText)
                    .ToArray();
            }

            NumberOfPoints = default;
            IsRight = default;
            AnswerOptions = default;
        }
    }
}
