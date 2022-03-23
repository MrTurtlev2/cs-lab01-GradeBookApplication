using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{

        public class RankedGradeBook : BaseGradeBook
        {

            public RankedGradeBook(string name) : base(name)
            {
                Type = GradeBookType.Ranked;

            }

            public override char GetLetterGrade(double averageGrade)
            {
                if (Students.Count < 5) {
                    throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
                }

                var topOfClass = (int)Math.Ceiling(Students.Count * 0.20);


                var studentsGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();



                if (studentsGrades[topOfClass - 1] <= averageGrade)
                {
                    return 'A';
                }
                else if (studentsGrades[(topOfClass * 2) - 1] <= averageGrade)
                {
                    return 'B';
                }
                else if (studentsGrades[(topOfClass * 3) - 1] <= averageGrade)
                {
                    return 'C';
                }
                else if (studentsGrades[(topOfClass * 4) - 1] <= averageGrade)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }
            }

            public override void CalculateStatistics()
            {
                if (Students.Count < 5)
                {
                    Console.WriteLine("Ranked grading requires at least 5 students.");

                   
                } else
            {
                base.CalculateStatistics();

            }

        }

            public override void CalculateStudentStatistics(string name)
            {
                if (Students.Count < 5)
                {
                    Console.WriteLine("Ranked grading requires at least 5 students.");

                   
                } else {

                base.CalculateStudentStatistics(name);

                }

        }
        }
    
}
   

