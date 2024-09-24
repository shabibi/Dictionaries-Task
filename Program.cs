using System.Security.Cryptography.X509Certificates;

namespace DictionariesTask
{
    internal class Program
    {
        static Dictionary<string, HashSet<string>> Courses = new Dictionary<string, HashSet<string>>(3);
 
        static List<(string studentName , string course)> waitlist = new List<(string, string)>();
        static void Main(string[] args)
        {
            InitializeStartupData();
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
                Console.WriteLine(" 9.Exit\n");
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
                        RemoveStudentFromCourse();
                        break;
                    case 5:
                        DisplayAllStudentsInCourse();
                        break;
                    case 6:
                        DisplayAllCoursesAndTheirStudents();
                        break;
                    case 7:
                        FindCoursesWithCommonStudents(); 
                        break;
                    case 8:
                        WithdrawStudentFromAllCourses();
                        break;
                    case 9:
                        return;
                        break;
                    default:
                        Console.WriteLine("Invalid Input..");
                        break;
                }
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("\nPress 1 if you want to Display Main Menu..");
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

        //Remove a student from the course.
        static void RemoveStudentFromCourse()
        {
            bool flag = false;
            string student;
            do
            {
                Console.Clear();
                Console.WriteLine("\t****************Remove a student from a course****************\n");
                Console.WriteLine("\nEnter Course Code ");
                Console.WriteLine("\n************************************************");
                foreach (var courseCode in Courses.Keys)
                {
                    Console.WriteLine(courseCode.ToString());
                }
                Console.WriteLine("************************************************\n");
                string Course_code = Console.ReadLine().ToUpper();
                
               
                if (Courses.ContainsKey(Course_code))
                {
                    Console.WriteLine("List of Students Enrolled in " + Course_code);
                    foreach (string stud in Courses[Course_code])
                        Console.WriteLine(stud.ToString());
                    Console.WriteLine("************************************************\n");
                    Console.WriteLine("Enter Student Name ");
                    student = Console.ReadLine();
                    if (Courses[Course_code].Contains(student))
                    {
                        Courses[Course_code].Remove(student);
                        Console.WriteLine(student + " Removed Successfully");
                        for(int i = 0; i<waitlist.Count;i++)
                        {
                            if(Course_code == waitlist[i].course)
                            {
                                Courses[Course_code].Add(waitlist[i].studentName);
                                Console.WriteLine(waitlist[i].studentName + " Added from waiting list to " + Course_code.ToUpper());
                                return;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("This Student is not Enrolled in this course");
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

            } while (flag==true);
            
        }

        //Display a list of all students enrolled in a specific course.
        static void DisplayAllStudentsInCourse()
        {
            Console.Clear();
            Console.WriteLine("\t****************Display all courses and their students****************\n");
            Console.WriteLine("\nEnter Course Code ");
            Console.WriteLine("\n************************************************");
            foreach (var courseCode in Courses.Keys)
            {
                Console.WriteLine(courseCode.ToString());
            }
            Console.WriteLine("************************************************\n");
            string Course_code = Console.ReadLine().ToUpper();
            if (Courses.ContainsKey(Course_code))
            {
                if (Courses[Course_code].Count() > 0)
                {
                    Console.WriteLine("\n************************************************");
                    Console.WriteLine("List of Students Enrolled in This Couse ");
                   
                    foreach (string stud in Courses[Course_code])
                        Console.WriteLine(stud.ToString());
                    Console.WriteLine("************************************************\n");
                  
                }
                else
                {
                    Console.WriteLine("This Course has no Students");
                }
            }
            else
                Console.WriteLine("This Course dose not exist..");
        }
        //Print a list of all courses along with the students enrolled in each course.
        static void DisplayAllCoursesAndTheirStudents()
        {
            Console.Clear();
            Console.WriteLine("\t****************Display all students in a course****************\n");
            Console.WriteLine("\n************************************************");
            foreach (var courseCode in Courses.Keys)
            {
                Console.WriteLine("Corse Code: "+ courseCode.ToString());
                Console.WriteLine("************************************************");
                Console.WriteLine("List of Students Enrolled in "+courseCode.ToString());
                foreach (string student in Courses[courseCode])
                    Console.WriteLine(student.ToString());
                Console.WriteLine("************************************************\n");
            }
    }

        //Given two course codes, find the students who are enrolled in both courses
        static void FindCoursesWithCommonStudents()
        {
            Console.Clear();
            Console.WriteLine("\t****************Find courses with common students****************\n");
            Console.WriteLine("\nEnter two Courses Code ");
            Console.WriteLine("\n************************************************");
            foreach (var courseCode in Courses.Keys)
            {
                Console.WriteLine(courseCode.ToString());
            }
            Console.WriteLine("************************************************\n");
            string course1 = Console.ReadLine().ToUpper();
            string course2 = Console.ReadLine().ToUpper();

            if (Courses.Keys.Contains(course1) && Courses.Keys.Contains(course2))
            {
                HashSet<string> course1Students = Courses[course1];
                HashSet<string> course2Students = Courses[course2];
                HashSet<string> commenStudents = new HashSet<string>(course1Students);
                commenStudents.IntersectWith(course2Students);
                if (commenStudents.Count > 0)
                {
                    Console.WriteLine("Studens Enrolled in " + course1 + " and " + course2);
                    foreach (var student in commenStudents)
                    {
                        Console.WriteLine(student.ToString());
                    }
                }
                else
                    Console.WriteLine("No Student has enrolled in this courses");
            }
            else
            {
                Console.WriteLine("This Course dose not exist..");
            }
            
        }

        static void WithdrawStudentFromAllCourses()
        {
            Console.Clear();
            Console.WriteLine("\t****************Withdraw a Student from All Courses****************\n");
            Console.WriteLine("\nEnter Student Nmae ");
            string student = Console.ReadLine();
            foreach (var course in Courses)
            {
                if (course.Value.Contains(student))
                {
                    course.Value.Remove(student);
                }
            }

            Console.WriteLine(student +" Removed from all courses");

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

        static void InitializeStartupData()
        {
            // Example data: Courses and their enrolled students (cross-over students)
            Courses["CS101"] = new HashSet<string> { "Alice", "Bob", "Charlie" };   // CS101 has Alice, Bob, Charlie
            Courses["MATH202"] = new HashSet<string> { "David", "Eva", "Bob" };     // MATH202 has David, Eva, and Bob (cross-over with CS101)
            Courses["ENG303"] = new HashSet<string> { "Frank", "Grace", "Charlie" };// ENG303 has Frank, Grace, and Charlie (cross-over with CS101)
            Courses["BIO404"] = new HashSet<string> { "Ivy", "Jack", "David" };     // BIO404 has Ivy, Jack, and David (cross-over with MATH202)
                                                                                    // Set course capacities (varying)
         
                                             // Waitlist for courses (students waiting to enroll in full courses)
            waitlist.Add(("Helen", "CS101"));   // Helen waiting for CS101
            waitlist.Add(("Jack", "ENG303"));   // Jack waiting for ENG303
            waitlist.Add(("Alice", "BIO404"));  // Alice waiting for BIO404
            waitlist.Add(("Eva", "ENG303"));    // Eva waiting for ENG303
            Console.WriteLine("Startup data initialized.");
        }
    }
}
