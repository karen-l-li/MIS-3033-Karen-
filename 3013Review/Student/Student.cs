using System;
using System.Collections.Generic;
using System.Text;

namespace Student
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteColor { get; set; }

        //Default/Empty Constructor
        public Student()
        {
            ID = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            FavoriteColor = string.Empty;
        }
        //Overloaded Constructor
        public Student(Int64 id, string first, string last, string color)
        {
            ID = id;
            FirstName = first;
            LastName = last;
            FavoriteColor = color;

        }

        public Student (Int64 id)
        {
            ID = id;
            FirstName = string.Empty;
            LastName = string.Empty;
            FavoriteColor = string.Empty;
        }

        public string CreateFullName()
        {
            // return LastName + ", " + FirstName
            return $"{LastName}, {FirstName}";
        }

    }
}
