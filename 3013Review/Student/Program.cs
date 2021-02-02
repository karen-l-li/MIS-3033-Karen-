//@Author Karen Li
using System;
using System.Collections.Generic;
using System.IO;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("studentdataRandom100Rows.csv");

            List<Student> students = new List<Student>();
            //foreach (var line in lines)
            //{
            //    Console.WriteLine(line);
            //}

            for (int i = 1; i < lines.Length; i++)
            {
                //    0        1    2    3
                //8203029752,Conni,Odo,Purple
                string line = lines[i];
                var pieces = line.Split(',');
                int id = Convert.ToInt64(pieces[0]);

                Student currentStudent = new Student(Convert.ToInt64(pieces[0]), pieces[1], pieces[2], pieces[3]);
                students.Add(currentStudent);
            }
            
            private static void PrintStudentWithFavoriteColor(string color)
            {
                Console.WriteLine(color);
            }


            Console.ReadKey();
        }
    }
}
