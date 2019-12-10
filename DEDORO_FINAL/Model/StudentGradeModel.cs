using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEDORO_FINAL
{
    public class StudentGradeModel
    {
        public int id { get; set; }
        public string sname { get; set; }
        public string subj { get; set; }
        public double prelim { get; set; }
        public double midterm { get; set; }
        public double finals { get; set; }
        public double ave { get; set; }
        public string remarks { get; set; }
    }
}
