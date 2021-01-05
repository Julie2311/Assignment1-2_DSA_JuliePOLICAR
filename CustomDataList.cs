using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;



namespace Assignment1_DSA_JuliePOLICAR
{
    internal class CustomDataList
    {
        //instance variables
        private Student student;
        private int length;
        private string first;
        private string last;
        internal LinkedList<Student> list;

        //Constructor
        public CustomDataList(LinkedList<Student> list)
        {

            this.list = list;
        }

        // Properties
        public int Length
        {
            get { return length; }
            set
            {
                length = list.Count;
            }
        }

        public string First
        {
            get { return first; }
            set
            {

                first = value;
            }
        }

        public LinkedList<Student> List
        {
            get { return list; }
            set
            {
                list = value;
            }
        }

        public Student Studennt
        {
            get { return student; }
            set
            {
                student = value;
            }
        }

        // Methods
        public void PopulateWithSampleData()
        {

            Console.WriteLine("Enter the student's firstname :");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter the student's lastname :");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter the student's average score :");
            float avscore = float.Parse(Console.ReadLine());
            string studentnb = GenerateStudentNb();

            Student student = new Student(fname, lname, studentnb, avscore);
            list.AddLast(student);

        }

        public void Add(Student element)
        {
            list.AddLast(element);

            Console.WriteLine($"the student {element.FN()} has been added");
            foreach (Student std in list)
            {
                Console.WriteLine(std.StudentId());
            }
        }

        public Student GetElement(int ind) //I used an array because it's easier to manipulate with index
        {
            Student[] array = new Student[list.Count];
            list.CopyTo(array, 0);
            Student std = array[ind];
            return array[ind];
        }

        public void RemoveItem(int ind)
        {
            Student[] array = new Student[list.Count];
            list.CopyTo(array, 0);
            Student std = array[ind];
            list.Remove(std);

            Console.WriteLine($"The student {std.FN()} has been removed !");
        }

        public void RemoveFirst()
        {
            Student stdtodelete = list.First.Value;
            list.RemoveFirst();
            Console.WriteLine("The first student has been removed from the list !");
        }

        public void RemoveLast()
        {
            Student stdtodelete = list.Last.Value;
            list.RemoveLast();
            Console.WriteLine("The last student has been removed from the list !");
        }

        public void DisplayList()
        {
            foreach (Student std in list)
            {
                Console.WriteLine(std.StudentId());
            }
        }

        public void Sort(int sortDirection, int sortField)
        {
            switch (sortField)
            {
                case 4:
                    //initialization
                    float[] avscorearray = new float[list.Count];
                    int i = 0;
                    foreach (Student student in list) //program logic
                    {
                        avscorearray[i] = student.AvScore;
                        i++;
                    }

                    for (i = 0; i < avscorearray.Length; i++)//sorting in ascending way
                    {
                        float minVal = avscorearray[i];
                        for (int j = i; j < avscorearray.Length; j++)
                        {
                            if (avscorearray[j] < minVal)
                            {

                                float var = minVal;
                                minVal = avscorearray[j];
                                avscorearray[j] = var;
                            }

                            avscorearray[i] = minVal;
                        }
                    }

                    if (sortDirection == 2) //sorting in descending way
                    {
                        for (i = 0; i < avscorearray.Length / 2; i++)
                        {

                            float var = avscorearray[i];
                            avscorearray[i] = avscorearray[avscorearray.Length - 1 - i];
                            avscorearray[avscorearray.Length - 1 - i] = var;
                        }
                    }

                    LinkedList<Student> sortedList = new LinkedList<Student>();//we create a new list to fill with the students sorted
                    i = 0;
                    while (i < avscorearray.Length)
                    {
                        foreach (Student student in list)
                            if (student.AvScore == avscorearray[i])
                                sortedList.AddLast(student);
                        i++;
                    }

                    list = sortedList;//we replace the old list by the new
                    break;

                default: //Every other fields are string so I am calling the method CopyListInArray

                    string[] array = CopyListInArray(sortField);


                    Array.Sort(array); //sort the string in ascending way

                    if (sortDirection == 2)//sort the string in descending way
                    {
                        for (i = 0; i < array.Length / 2; i++)
                        {

                            string var = array[i];
                            array[i] = array[array.Length - 1 - i];
                            array[array.Length - 1 - i] = var;
                        }
                    }

                    LinkedList<Student> newList = new LinkedList<Student>();//We fill the new list
                    int a = 0;
                    switch (sortField)
                    {
                        case 1:
                            foreach (Student student in list)
                                if (student.FName == array[a])
                                {
                                    newList.AddLast(student);
                                }
                            break;
                        case 2:
                            foreach (Student student in list)
                                if (student.Lname == array[a])
                                {
                                    newList.AddLast(student);
                                }
                            break;
                        case 3:
                            foreach (Student student in list)
                                if (student.StudentNumber == array[a])
                                {
                                    newList.AddLast(student);
                                }
                            break;
                    }
                    list = newList;

                    break;
            }
        }

        public Student GetMaxElement()
        {
            Student[] array = new Student[list.Count];
            list.CopyTo(array, 0);

            Student maxavscore = array[0];
            if (array.Length > 1)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (maxavscore.AvScore < array[i].AvScore)
                        maxavscore = array[i];
                }
            }
            return maxavscore;
        }

        public Student GetMinElement()
        {
            Student[] array = new Student[list.Count];
            list.CopyTo(array, 0);

            Student minavscore = array[0];
            if (array.Length > 1)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (minavscore.AvScore < array[i].AvScore)
                        minavscore = array[i];
                }
            }
            return minavscore;
        }
        public string[] CopyListInArray(int sortfield)
        {   //initialization
            string[] arraytosort = new string[list.Count];
            int i = 0;
            switch (sortfield)//program logic
            {
                case 1:
                    foreach (Student std in list)
                    {
                        arraytosort[i] = student.FName;
                        i++;
                    }
                    return arraytosort;

                case 2:
                    foreach (Student std in list)
                    {
                        arraytosort[i] = student.Lname;
                        i++;
                    }
                    return arraytosort;

                case 3: // 
                    foreach (Student std in list)
                    {
                        arraytosort[i] = student.StudentNumber;
                        i++;
                    }
                    return arraytosort;
                //output
                default:
                    return null;
            }

        }



        public string GenerateStudentNb()
        {
            //initialization
            Random r = new Random();

            String b = "abcdefghijklmnopqrstuvwxyz";

            int length = 6;

            String random = "";
            //program logic
            for (int i = 0; i < length; i++)
            {
                int a = r.Next(26);
                random = random + b.ElementAt(a);
            }
            //output
            return random;
        }
    }
}
