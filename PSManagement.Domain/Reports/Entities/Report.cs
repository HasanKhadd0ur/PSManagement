using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Reports.Entities
{
    public class Report :BaseEntity
    {
        public String ReportName { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
    public class Section : BaseEntity
    {
        public String SectionName { get; set; }
        public Report Report { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
    public class Question : BaseEntity
    {
        public String QuestionName { get; set; }
        public ICollection<Section> Sections { get; set; }

    }
    public class Answer : BaseEntity
    {
        public Question Question { get; set; }
        public String AnswerValue { get; set; }


    }

    public class ReportResult : BaseEntity
    {
        public Report Report { get; set; }
        public ICollection<Answer> Answers { get; set; }

    }


}
