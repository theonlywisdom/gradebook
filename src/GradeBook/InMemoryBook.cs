using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        private List<double> grades;

        public const string CATEGORY = "Science";

        //public string Name { get; set; }

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }



        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid value {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);

            }

            //// prevent first q from beig passed to program 
            //if (grades.Count != 0)
            //{
            //    result.Average /= grades.Count;
            //}

            //else
            //{
            //    throw new ArgumentException();
            //}
            ////end of prevent q

            

            return result;
        }

    }
}
