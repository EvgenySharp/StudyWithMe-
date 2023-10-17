using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace BusinessLayer.Implementations
{
    public class TestHAP
    {
        public FacultyHAP? Faculty { get; init; }
        public DepartmentHAP? Department { get; init; }
        public SubjectHAP Subject { get; init; }
        public ICollection<QuestionHAP> Questions { get; init; } = new List<QuestionHAP>();
        private HtmlDocument htmlDoc { get; init; }
        public bool ContainsNavigationElements { get; init; }

        public TestHAP(HtmlDocument HtmlDoc)
        {
            htmlDoc = HtmlDoc;
            var navigationElements = GetNavigationElements();
            // if navigationElements contains not 8 elements than navigationElements don't have information about Faculty, Department, Subject.
            if (navigationElements.Count() == 8)
            {
                ContainsNavigationElements = true;
                Faculty = new FacultyHAP(navigationElements);
                Department = new DepartmentHAP(navigationElements, Faculty);
                Subject = new SubjectHAP(navigationElements, Department, GetSecondSubjectName());
            }
            else
            {
                ContainsNavigationElements = false; 
                Faculty = new FacultyHAP();
                Department = new DepartmentHAP();
                Subject = new SubjectHAP(navigationElements, Department, GetSecondSubjectName());
            }
            HtmlNodeCollection questionsNodes = GetQuestionsNodes();
            for (int i = 0; i < questionsNodes.Count - 1; i++)
            {
                var questionNodes = questionsNodes[i];
                var question = new QuestionHAP(questionNodes);                
                Questions.Add(question);
            }
        }

        private IEnumerable<string> GetNavigationElements()
        {
            var htmlNode = GetNavigationNode();
            return htmlNode.ChildNodes
                .Where(nod => nod.Name == "li")
                .Select(liNod => liNod.InnerText)
                .Select(litext => Regex.Replace(litext, @"([\n\t])(\s+)", ""));
        }

        private HtmlNode GetNavigationNode()
        {
            int indexOfFirstEle = 0;
            return htmlDoc.DocumentNode
                .SelectNodes("//html/" +
                                "/body/" +
                                    "/div" +
                                        "/div" +
                                            "/header" +
                                                "/div" +
                                                    "/div" +
                                                        "/div" +
                                                            "/div" +
                                                                "/div" +
                                                                    "/nav" +
                                                                        "/ol")[indexOfFirstEle];
        }

        private string GetSecondSubjectName()
        {
            int indexOfFirstEle = 0;
            return htmlDoc.DocumentNode
                .SelectNodes("//html/" +
                                "/body/" +
                                    "/div" +
                                        "/div" +
                                            "/header" +
                                                "/div" +
                                                    "/div" +
                                                        "/div" +
                                                            "/div" +
                                                                "/div" +
                                                                    "/div")[indexOfFirstEle].InnerText;
        }

        private HtmlNodeCollection GetQuestionsNodes()
        {
            return htmlDoc.DocumentNode
                .SelectNodes("//html/" +
                                "/body/" +
                                    "/div" +
                                        "/div" +
                                            "/div" +
                                                "/div" +
                                                    "/section" +
                                                        "/div" +
                                                            "/form" +
                                                                "/div" +
                                                                    "/div");
        }
    }
}
