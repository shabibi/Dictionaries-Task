namespace DictionariesTask
{
    internal class Program
    {
        static Dictionary<string, HashSet<string>> Courses = new Dictionary<string, HashSet<string>>(10);
        static List<(string,string)> waitlist = new List<(string,string)> ();
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
                        break;

                    case 3:
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
                if(cont != "1")
                {
                    Console.WriteLine("******************Thank You******************");
                    flge = false;
                }
                else
                    flge = true;

            } while (flge== true);

        }

        static void AddNewCourse()
        {
            Console.Clear();
            Console.WriteLine("\t****************Add New Course****************\n");
            bool flag =false;
            do
            {
                Console.WriteLine("Enter Course Code ");
                string courseCode = Console.ReadLine().ToLower();

                if (!Courses.ContainsKey(courseCode.ToLower()))
                {
                    Courses[courseCode] = new HashSet<string>();
                    Console.WriteLine("\n"+courseCode.ToUpper()+ " Added");
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

            } while (flag ==true);
         
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
