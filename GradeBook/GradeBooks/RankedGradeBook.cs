using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires at least 5 students to work");
            }

            int rankingGroup = (int)Math.Ceiling((decimal)(Students.Count / 5));
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            
            if (grades[rankingGroup - 1] <= averageGrade)
            {
                return 'A';
            }

            if (grades[(rankingGroup * 2) - 1] <= averageGrade)
            {
                return 'B';
            }

            if (grades[(rankingGroup * 3) - 1] <= averageGrade)
            {
                return 'C';
            }

            if (grades[(rankingGroup * 4) - 1] <= averageGrade)
            {
                return 'D';
            }


            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in " +
                    "order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in " +
                    "order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            
        }
        
    }

}
