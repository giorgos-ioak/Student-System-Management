using static Program;

internal class Program {
  private static void Main(string[] args) {
    bool open = true;
    List<Student> students = new List<Student>();

    while (open) {
      Console.WriteLine("1. Add Student");
      Console.WriteLine("2. Assign Grade");
      Console.WriteLine("3. Calculate average");
      Console.WriteLine("4. View student records");
      Console.WriteLine("5. Exit");

      int choice = int.Parse(Console.ReadLine());

      switch (choice) {
        case 1:
          Student.AddStudent(students);
          break;
        case 2:
          Student.AddGrade(students);
          break;
        case 3:
          Student.CalculateAverage(students);
          break;
        case 4:
          Student.DisplayStudent(students);
          break;
        case 5:
          Student.ExitApp(ref open);
          break;
        default:
          Console.WriteLine("Wrong input.");
          break;
      }
    }

    Console.ReadKey();
  }

  public class Student {
    int ID;
    string Name;

    // Dictionary List for storing Key/Value pairs (subject,grade). 
    Dictionary<string, double> Grades; 

    // CLASS CONSTRUCTOR
    public Student(string name, int id) {
      Name = name;
      ID = id;
      Grades = new Dictionary<string, double>();
    }


    // CLASS METHODS
    public static void AddStudent(List<Student> students) {
      Console.WriteLine("Enter the student's Name");
      string name = Console.ReadLine();

      Console.WriteLine("Enter the student's ID");
      int id = int.Parse(Console.ReadLine());
      
      for(int i=0; i < students.Count; i++) {
        if (students[i].ID == id) {
          Console.WriteLine("Student already exists");
          return;
        }
      }

      Student newStudent = new Student(name, id);
      students.Add(newStudent);

      Console.WriteLine($"Student {name} with ID of {id} has been created.");
    }

    public static void AddGrade(List<Student> students) {
      Console.WriteLine("Enter the student's ID");
      int id = int.Parse(Console.ReadLine());

      Student student = null;

      for (int i = 0; i < students.Count; i++) {
        if (students[i].ID == id) {
          student = students[i];
          break;
        }
      }


      if (student != null) {
        Console.WriteLine("Enter the student's subject");
        string subject = Console.ReadLine();

        Console.WriteLine("Enter the subject's grade");
        double grade = double.Parse(Console.ReadLine());

        student.Grades[subject] = grade;
        Console.WriteLine("Grade assigned successfully.");
      } else {
        Console.WriteLine("Student not found.");
      }

    }

    public static void CalculateAverage(List<Student> students) {
      Console.WriteLine("Enter the student's ID");
      int id = int.Parse(Console.ReadLine());

      double sum = 0;

      Student student = null;

      for (int i = 0; i < students.Count; i++) {
        if (students[i].ID == id) {
          student = students[i];
          break;
        }
      }

      if (student != null) { 
        foreach(var grade in student.Grades.Values) {
          sum += grade;
        }

        Console.WriteLine($"This student has an average of {sum / student.Grades.Count}");
      } else {
        Console.WriteLine("Student does not exist.");
      }
    }

    public static void DisplayStudent(List<Student> students) {
      if(students.Count > 0) {
        for(int i=0; i < students.Count; i++) {
          Console.WriteLine($"Student {students[i].Name} with ID of {students[i].ID}");


          if(students[i].Grades.Count > 0) {
            foreach (var grade in students[i].Grades) {
              Console.WriteLine($"{grade.Key}: {grade.Value}");
            }
          } else {
            Console.WriteLine("Student has no grades.");
          }
          
        }
      } else {
        Console.WriteLine("There are no students listed.");
      }
    }

    public static void ExitApp(ref bool open) {
      open = false;

      Console.WriteLine("Exited the App.");
    }
  }
}