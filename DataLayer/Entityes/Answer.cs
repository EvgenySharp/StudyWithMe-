using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }
        public bool? IsRight { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
