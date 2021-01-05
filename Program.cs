using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Assignment1_DSA_JuliePOLICAR
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to the DSA assignment menu of Julie, first we need to fill the list !");
            LinkedList<Student> list = new LinkedList<Student>();
            CustomDataList studentlist = new CustomDataList(list);

            int choice;
            int ind;

            while (true)
            {   //initializatio
                choice = -1;
                ind = -1;

                Console.WriteLine("Menu:\n\t" +
                    "1. Populate the list with sample data\n\t" +
                    "2. Add a student to the list\n\t" +
                    "3. Search a student and its information by its index in the list\n\t" +
                    "4. Remove an element with its index\n\t" +
                    "5. Remove the first element in the list\n\t" +
                    "6. Remove the last element in the list\n\t" +
                    "7. Display all elements in the list\n\t" +
                    "8. Sort all the elements in the list by field direction you\n\t" +
                    "9. Search the student with the best score and display its information\n\t" +
                    "10. Search the element with the lowest score and display its information\n\t");

                string choiceinstrg = Console.ReadLine();
                //program logic
                if (int.TryParse(choiceinstrg, out int result) && int.Parse(choiceinstrg) > 0 && int.Parse(choiceinstrg) < 12)
                    choice = result;
                else
                    throw new ArgumentOutOfRangeException("Please enter a number between 1-12 !");

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("How many students do you want to enter ? ");
                        int d = int.Parse(Console.ReadLine());//We make a loop for
                        for (int i = 0; i < d; i++)
                        {

                            studentlist.PopulateWithSampleData();//We call the method to fill the list

                        }
                        Console.WriteLine("Here are the students entered in the list : ");
                        foreach (Student stdt in list)//we display the students entered in the list
                        {

                            Console.WriteLine(stdt.StudentId());
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("How many students do you want to enter ? ");
                        int f = int.Parse(Console.ReadLine());//We make a loop for
                        for (int i = 0; i < f; i++)
                        {
                            Console.WriteLine("Enter the student's firstname :");
                            string fname = Console.ReadLine();
                            Console.WriteLine("Enter the student's lastname :");
                            string lname = Console.ReadLine();
                            Console.WriteLine("Enter the student's average score :");
                            float avscore = float.Parse(Console.ReadLine());
                            Student element = new Student(fname, lname, "hhhhhh", avscore);//We create a new student element
                            studentlist.Add(element);//We add the student in the list by calling the method
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        while (true)
                        {
                            Console.WriteLine($"Please enter a number (0 to {studentlist.List.Count - 1}) to acced to a student's info ");
                            string indexstrg = Console.ReadLine();
                            // Check if the index is in the list
                            if (int.TryParse(indexstrg, out result) && int.Parse(indexstrg) >= 0 && int.Parse(indexstrg) < studentlist.List.Count)
                            {
                                ind = result;
                                break;
                            }
                            else throw new ArgumentOutOfRangeException($"Please enter a number between 1-{studentlist.List.Count - 1} !");
                        }
                        Student studentinfo = studentlist.GetElement(ind);//we call the method to find the student searched

                        Console.WriteLine(studentinfo.StudentId());//we call the method to display the student searched
                        Console.ReadKey();
                        break;

                    case 4:
                        while (true)
                        {
                            Console.WriteLine($"Please enter a number (0 to {studentlist.List.Count - 1}) to acced to a student's info ");
                            string indexstrg = Console.ReadLine();

                            if (int.TryParse(indexstrg, out result) && int.Parse(indexstrg) >= 0 && int.Parse(indexstrg) < studentlist.List.Count)
                            {
                                ind = result;
                                break;
                            }
                            else throw new ArgumentOutOfRangeException($"Please enter a number between 1-{studentlist.List.Count - 1} !");
                        }

                        studentlist.RemoveItem(ind);//we call the method to delete the student searched by the index
                        Console.WriteLine("Here are the students in the list : ");
                        foreach (Student stdt in list)//we display the others students
                        {

                            Console.WriteLine(stdt.StudentId());
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        studentlist.RemoveFirst();
                        Console.WriteLine("Here are the students in the list : ");
                        foreach (Student stdt in list)
                        {

                            Console.WriteLine(stdt.StudentId());
                        }
                        Console.ReadKey();
                        break;

                    case 6:
                        studentlist.RemoveLast();
                        Console.WriteLine("Here are the students in the list : ");
                        foreach (Student stdt in list)
                        {

                            Console.WriteLine(stdt.StudentId());
                        }
                        Console.ReadKey();
                        break;

                    case 7:
                        studentlist.DisplayList();
                        Console.ReadKey();
                        break;

                    case 8:
                        int sortField = -1; int sortDirection = -1;

                        // Choice of field the user want to sort
                        while (true)
                        {
                            Console.WriteLine($"Please choose which field you want to sort:\n\t" +
                                $"1. Firstname\n\t" +
                                $"2. Lastname\n\t" +
                                $"3. Student number\n\t" +
                                $"4. Average score\n\t");
                            string fieldstrg = Console.ReadLine();

                            if (int.TryParse(fieldstrg, out result) && int.Parse(fieldstrg) > 0 && int.Parse(fieldstrg) < 5)
                            {
                                sortField = result;
                                break;
                            }
                            else throw new ArgumentOutOfRangeException("Please enter a number between 1-4 !");
                        }

                        // Choice of direction of the sort (ascending or descending)
                        while (true)
                        {

                            Console.WriteLine($"Please choose in which direction you want to sort :\n\t" +
                                $"1. Ascending sort\n\t" +
                                $"2. Descending sort\n\t");
                            string sortDirectionString = Console.ReadLine();

                            if (int.TryParse(sortDirectionString, out result) && int.Parse(sortDirectionString) > 0 && int.Parse(sortDirectionString) < 3)
                            {
                                sortDirection = result;
                                break;
                            }
                            else throw new ArgumentOutOfRangeException("Please enter a number between 1-2 !");
                        }

                        // we sort the list
                        studentlist.Sort(sortDirection, sortField);
                        //we display the list
                        studentlist.DisplayList();

                        Console.ReadKey();
                        break;

                    case 9:
                        Student beststudent = studentlist.GetMaxElement();//we call the method to get the student with the best score
                        Console.WriteLine($"{beststudent.FN()} has the best score!");

                        Console.ReadKey();
                        break;

                    case 10:
                        Student worststudent = studentlist.GetMinElement();//we call the method to get the student with the best score
                        Console.WriteLine($"{worststudent.FN()} has the best score!");

                        Console.ReadKey();
                        break;
                }
            }

        }

    }
}
