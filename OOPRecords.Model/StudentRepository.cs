using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace OOPRecords.Model
{
    public class StudentRepository
    {
        private List<Student> Students = new List<Student>();

        public StudentRepository()
        {
            var initializer = new Initializer();
            initializer.Seed(this);
        }

        public void Add(Student s)
        {
            Students.Add(s);
        }
        public IEnumerable<Student> AllStudents()
        {
            return Students;
        }
        public IEnumerable<Student> FindStudentByLastName(string lastName)
        {
            return from s in AllStudents()
                   where s.LastName.ToUpper().Contains(lastName.ToUpper())
                   select s;
        }
        public Student NewStudent(string firstName, string lastName, DateTime dob)
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = dob;
            Add(s);
            return s;
        }
    }
}
//private const string fileName = @"C:\Users\thoma\Documents\Computer Science ALevel\OOPRecords\OOPRecords.ConsoleUI\StudentsFile.json";
        //private const string fileName = @"\\ran\qe2root\QE2StudentDocs\Cohort_2008\08thomasgiddins\Documents\A Level Computer Science\OOP Records\OOPRecords.ConsoleUI\StudentsFile.json";
        

    
}
