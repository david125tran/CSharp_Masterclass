using System.Xml.Linq;

namespace Section19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            OddNumbers(numbers);
        }

        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd Numbers: ");
            // Linq Statement
            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;
            Console.WriteLine(oddNumbers);

            foreach (int number in oddNumbers)
            {
                Console.WriteLine(number);
            }

            // Create UniversityManager Object
            UniversityManager um = new UniversityManager();

            // Linq
            um.MaleStudents();
            um.FemaleStudents();
            um.SortStudentsByAge();
            um.AllStudentsFromNCSU();

            Console.WriteLine("\nGive a university id");
            int input = Convert.ToInt32(Console.ReadLine());
            um.AllStudentsFromThatUni(input);

            um.StudentAndUniversityNameCollection();

            // Linq with Integers
            int[] someInts = { 30, 5, 222, 1, 23, 94, 884 };
            IEnumerable<int> sortedInts = from i in someInts orderby i select i;
            IEnumerable<int> reverseInts = sortedInts.Reverse();
            IEnumerable<int> reverseIntegers = from i in someInts orderby i descending select i;

            Console.WriteLine("\nIntegers in reverse order:");
            foreach (int i in reverseInts)
            {
                Console.WriteLine(i);
            }

            // Student structure as XML. 
            string studentsXML =
                        @"<Students>
                            <Student>
                                <Name>Toni</Name>
                                <Age>21</Age>
                                <University>Yale</University>
                                <Semester>6</Semester>
                            </Student>
                            <Student>
                                <Name>Carla</Name>
                                <Age>17</Age>
                                <University>Yale</University>
                                <Semester>1</Semester>
                            </Student>
                            <Student>
                                <Name>Leyla</Name>
                                <Age>19</Age>
                                <University>Beijing Tech</University>
                                <Semester>3</Semester>
                            </Student>
                            <Student>
                                <Name>Frank</Name>
                                <Age>25</Age>
                                <University>Beijing Tech</University>
                                <Semester>10</Semester>
                            </Student>
                        </Students>";

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               Semester = student.Element("Semester").Value
                           };
            Console.WriteLine("\nLinq with XML: ");
            foreach (var student in students)
            {
                Console.WriteLine("Student {0} with age {1} from University {2} is in his/her {3} Semester", student.Name, student.Age, student.University, student.Semester);
            }

            var sortedStudents = from student in students
                                 orderby student.Age
                                 select student;

            foreach (var student in sortedStudents)
            {
                Console.WriteLine("Student {0} with age {1} from University {2}", student.Name, student.Age, student.University);
            }

            Console.ReadKey();
        }
    }
    // By convention, you should create a new class in the solution explorer.  Not in the same context.
    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;
        // Constructor
        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            // Add Universities
            universities.Add(new University { Id = 1, Name = "NCSU" });
            universities.Add(new University { Id = 2, Name = "UNC" });
            // Add Students
            students.Add(new Student { Id = 1, Name = "Hannah", Gender = "Female", Age = 17, UniversityId = 1});
            students.Add(new Student { Id = 2, Name = "Marley", Gender = "Female", Age = 21, UniversityId = 2 });
            students.Add(new Student { Id = 3, Name = "Tyrone", Gender = "Male", Age = 17, UniversityId = 1 });
            students.Add(new Student { Id = 4, Name = "Ralph", Gender = "Male", Age = 19, UniversityId = 1 });
            students.Add(new Student { Id = 5, Name = "Roxy", Gender = "Female", Age = 21, UniversityId = 2 });

        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;
            Console.WriteLine("\nMale - Students: ");
            foreach(Student student in maleStudents)
            {
                student.Print();
            }

        }
        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "Female" select student;
            Console.WriteLine("\nFemale - Students: ");
            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }
        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("\nSorted Students: ");
            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }
        public void AllStudentsFromNCSU()
        {
            IEnumerable<Student> ncsuStudents = from student in students
                                                join university in universities
                                                on student.UniversityId equals university.Id
                                                select student;
            Console.WriteLine("\nNCSU Students: ");
            foreach (Student student in ncsuStudents)
            {
                student.Print();
            }
        }
        public void AllStudentsFromThatUni(int inputId)
        {
            IEnumerable<Student> myStudents = from student in students
                                              join university in universities
                                              on student.UniversityId equals university.Id
                                              where student.UniversityId == inputId
                                              select student;
            Console.WriteLine("\nStudents from {0}: ", inputId);
            foreach (Student student in myStudents)
            {
                student.Print();
            }
        }
        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join university in universities
                                on student.UniversityId equals university.Id
                                orderby student.Name
                                // Create a new object for each variable 
                                select new { StudentName = student.Name, UniversityName = university.Name };
            Console.WriteLine("\nNew Collection: ");
            foreach (var col in newCollection)
            {
                Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
            }
        }
    }

    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("University {0} with ID {1}", Name, Id);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key
        public int UniversityId {  get; set; }
        public void Print()
        {
            Console.WriteLine("Student {0} with ID {1}, Gender {2}, and Age {3} from the University with ID {4}", 
                Name, Id, Gender, Age, UniversityId);
        }
    }
}
