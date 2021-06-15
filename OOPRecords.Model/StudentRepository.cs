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
        private DatabaseContext Context;

        public StudentRepository(DatabaseContext context)
        {
            Context = context;
        }

        public void Add(Student s)
        {
            Context.Students.Add(s);
            Context.SaveChanges();
        }

        public IEnumerable<Student> AllStudents()
        {
            return Context.Students;
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

        private const string fileName = @"\\ran\qe2root\QE2StudentDocs\Cohort_2008\08thomasgiddins\Documents\A Level Computer Science\OOP Records\OOPRecords.ConsoleUI\StudentsFile.json";
        
    }
}
