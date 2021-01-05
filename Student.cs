using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment1_DSA_JuliePOLICAR
{
    internal class Student
    {
        //instance variables
        internal string firstname;
        internal string lastname;
        internal string studentnb;
        internal float avscore;


        //Constructor
        public Student(string firstname, string lastname, string studentnb, float avscore)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.studentnb = studentnb;
            this.avscore = avscore;

        }

        // Properties
        public string FName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name is empty !");
                }
            }
        }

        public string Lname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name is empty !");
                }
            }
        }

        public string StudentNumber
        {
            get { return studentnb; }
            set
            {
                studentnb = value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student number is empty !");
                }
            }
        }

        public float AvScore
        {
            get { return avscore; }
            set { avscore = value; }
        }

        // Methods
        public string StudentId()
        {
            return $"Student : {firstname} {lastname} " +
                $"Student number : {studentnb} " +
                $"Average score : {avscore}";
        }

        public string FN() //To create the full name with the variables firstname and lastname
        {
            string fullname = firstname + " " + lastname; // Initialization + program logic
            return fullname;
        }


    }
}
