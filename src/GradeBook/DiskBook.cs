using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class DiskBook : Book, IBook
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (double.TryParse(line, out double number))
                    {
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }

            return result;
        }


        //public string Name => throw new NotImplementedException();

        //public event GradeAddedDelegate GradeAdded;


        //public Statistics GetStatistics()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
