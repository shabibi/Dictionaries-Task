﻿using System.Security.Cryptography.X509Certificates;

namespace DictionariesTask
{
    internal class Program
    {
        static Dictionary<string, HashSet<string>> Courses = new Dictionary<string, HashSet<string>>(3);
        //static HashSet<string> studentsName = new HashSet<string>();
        static List<(string, string)> waitlist = new List<(string, string)>();
        static void Main(string[] args)
        {
            bool flge = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t****************Course Enrollment System****************");
                Console.WriteLine("---------------------------------------------------------------\n");
                Console.WriteLine("Enter the number of your choice \n");
                Console.WriteLine(" 1.Add a new course\n");
                Console.WriteLine(" 2.Remove Course\n");
                Console.WriteLine(" 3.Enroll a student in a course\n");
                Console.WriteLine(" 4.Remove a student from a course\n");
                Console.WriteLine(" 5.Display all students in a course\n");
                Console.WriteLine(" 6.Display all courses and their students\n");
                Console.WriteLine(" 7.Find courses with common students\n");
                Console.WriteLine(" 8.Withdraw a Student from All Courses\n");
                int choice = handelIntError(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewCourse();
                        break;

                    case 2:
                        RemoveCourse();
                        break;

                    case 3:
                        EnrollStudentCourse();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;

                    default:
                        Console.WriteLine("Invalid Input..");
                        break;
                }
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("\nPress 1 if you want to Continue..");
                string cont = Console.ReadLine();
                if (cont != "1")
                {
                    Console.WriteLine("******************Thank You******************");
                    flge = false;
                }
                else
                    flge = true;

            } while (flge == true);

        }

        //Add a new course: Add a course code to the dictionary if it doesn't exist already.
        static void AddNewCourse()
        {
            Console.Clear();
            Console.WriteLine("\t****************Add New Course****************\n");
            bool flag = false;
            do
            {
                Console.WriteLine("Enter Course Code ");
                string courseCode = Console.ReadLine().ToUpper();

                if (!Courses.ContainsKey(courseCode.ToUpper()))
                {
                    Courses[courseCode] = new HashSet<string>();
                    Console.WriteLine("\n" + courseCode.ToUpper() + " Added");
                    Console.WriteLine("------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\nThis Course Code is exists");
                    Console.WriteLine("------------------------------------------------");
                }
                Console.WriteLine("\nEnter 1 if you want to Add Another Course ");
                string cont = Console.ReadLine();
                if (cont != "1")
                {
                    Console.WriteLine("\n******************Thank You******************");
                    flag = false;
                }
                else
                    flag = true;

            } while (flag == true);

        }
        //Remove Course : remove a course from list if it not having enrolled students
        static void RemoveCourse()
        {
            bool flag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t****************Remove Course****************\n");
                Console.WriteLine("\nEnter Course Code ");
                Console.WriteLine("\n************************************************");
                foreach (string course_Code in Courses.Keys)
                {

                    Console.WriteLine(course_Code.ToUpper());
                }
                Console.WriteLine("************************************************\n");
                string courseCode = Console.ReadLine().ToUpper();
                if (Courses.ContainsKey(courseCode))
                {
                    if (Courses[courseCode].Count != 0)
                    {
                        Console.WriteLine("\nThis Course having enrolled students.. ");
                    }
                    else
                    {
                        Courses.Remove(courseCode);
                        Console.WriteLine("\n" + courseCode.ToUpper() + " Removed");
                    }
                }
                else
                {
                    Console.WriteLine("This Course dose not exist..");
                }
                   
                Console.WriteLine("\nEnter 1 if you want to Remove Another Course ");
                string cont = Console.ReadLine();
                if (cont != "1")
                {
                    Console.WriteLine("\n******************Thank You******************");
                    flag = false;
                }
                else
                    flag = true;

            } while (flag == true);
            
        }

        //Enroll a student in a course: Given a student's name and course code, enroll the student in that course
        static void EnrollStudentCourse()
        {
            
            string student, course_Code;
            bool flag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t****************Enroll a student in a course****************\n");
                Console.WriteLine("\nEnter Course Code ");
                Console.WriteLine("\n************************************************");
                foreach (string courseCode in Courses.Keys)
                {

                    Console.WriteLine(courseCode.ToUpper());
                }
                Console.WriteLine("************************************************\n");
                course_Code = Console.ReadLine().ToUpper();
                if (Courses.ContainsKey(course_Code))
                {
                    if (Courses[course_Code].Count < 3)
                    {
                        Console.WriteLine("Enter Student Name ");
                        student = Console.ReadLine().ToLower();
                        if (!Courses[course_Code].Contains(student))
                        {
                            Courses[course_Code].Add(student);
                            Console.WriteLine(student + " Added Successfully");
                        }
                        else
                        {
                            Console.WriteLine("This Student is Enrolled in this course");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThis Course is Full..\nAdding to Waiting List..");
                        Console.WriteLine("\nEnter Student Name ");
                        student = Console.ReadLine().ToLower();
                        if (!Courses[course_Code].Contains(student))
                        {
                            waitlist.Add((course_Code, student));
                            Console.WriteLine(student + " Added to Waiting List Successfully");
                        }
                        else
                        {
                            Console.WriteLine("This Student is Enrolled in this course");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This Course dose not exist..");
                }

                Console.WriteLine("\nEnter 1 if you want to Add Another Student ");
                    string cont = Console.ReadLine();
                    if (cont != "1")
                    {
                        Console.WriteLine("\n******************Thank You******************");
                        flag = false;
                    }
                    else
                        flag = true;
            } while (flag == true);

        }


        static int handelIntError(string input)
        {
            int num;
            bool flag = true;
            do
            {
                if (int.TryParse(input, out num))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("re-enter input");
                    input = Console.ReadLine();
                    flag = true;
                }
            } while (flag == true);
            return num;
        }
    }
}
