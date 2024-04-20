using System;
using System.Collections.Generic;



//Abstraction: Person class is an abstract class with common properties and an abstract method DisplayInformation(),
//which each subclass must implement.
abstract class Person
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(int id, string name, int age)
    {
        ID = id;
        Name = name;
        Age = age;
    }

    public abstract void DisplayInformation();
}

// Concrete class Student
class Student : Person
{
    public List<string> CoursesEnrolled { get; set; }

    public Student(int studentID, string name, int age)
        : base(studentID, name, age)
    {
        CoursesEnrolled = new List<string>();
    }

    public void EnrollCourse(string course)
    {
        CoursesEnrolled.Add(course);
    }

    public void DropCourse(string course)
    {
        CoursesEnrolled.Remove(course);
    }

    public override void DisplayInformation()
    {
        Console.WriteLine($"Student ID: {ID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine("Courses Enrolled:");
        foreach (var course in CoursesEnrolled)
        {
            Console.WriteLine($"- {course}");
        }
    }
}

// Concrete class Instructor
class Instructor : Person
{
    public List<Class> ClassesTaught { get; set; }

    public Instructor(int instructorID, string name, int age)
        : base(instructorID, name, age)
    {
        ClassesTaught = new List<Class>();
    }

    public void AddClass(Class classObj)
    {
        ClassesTaught.Add(classObj);
    }

    public void RemoveClass(Class classObj)
    {
        ClassesTaught.Remove(classObj);
    }

    public override void DisplayInformation()
    {
        Console.WriteLine($"Instructor ID: {ID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine("Classes Taught:");
        foreach (var classObj in ClassesTaught)
        {
            Console.WriteLine($"- {classObj.Name} (ID: {classObj.ClassID})");
        }
    }
}
// Class Class
class Class
{
    public int ClassID { get; }
    public string Name { get; set; }
    public string Instructor { get; set; }
    public string Department { get; set; }
    public Course Course { get; set; }
    public List<Student> Students { get; } = new List<Student>();

    public Class(int classID, string name, string instructor, string department, Course course)
    {
        ClassID = classID;
        Name = name;
        Instructor = instructor;
        Department = department;
        Course = course;
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Class ID: {ClassID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Instructor: {Instructor}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Course: {Course.CourseID} - {Course.Name}");
        Console.WriteLine("Students:");
        foreach (var student in Students)
        {
            Console.WriteLine($"{student.ID}: {student.Name}");
        }
    }
}
// Department Class
class Department
{
    // Attributes
    public int DepartmentID { get; set; }
    public string Name { get; set; }
    public List<Class> ClassesOffered { get; set; }

    // Constructor
    public Department(int departmentID, string name)
    {
        DepartmentID = departmentID;
        Name = name;
        ClassesOffered = new List<Class>();
    }

    // Methods
    public void AddClass(Class classObj)
    {
        ClassesOffered.Add(classObj);
    }

    public void RemoveClass(Class classObj)
    {
        ClassesOffered.Remove(classObj);
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Department ID: {DepartmentID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Classes Offered:");
        foreach (var classObj in ClassesOffered)
        {
            Console.WriteLine($"- {classObj.Name} (ID: {classObj.ClassID})");
        }
    }
}


class Course
{
    public int CourseID { get; }
    public string Name { get; set; }
    public Department Department { get; set; }

    public Course(int courseID, string name, Department department)
    {
        CourseID = courseID;
        Name = name;
        Department = department;
    }
}
//Demonstration of Part 1 for testing purposes.
class Program
{
    static void Main(string[] args)
    {

        // Polymorphism: Using the abstract class Person, we create a list of people (List<Person>) and add Student
        // and Instructor objects to it. We then demonstrate polymorphism by calling the
        // DisplayInformation() method on each object in the list, where the method behaves differently depending on the object's class.



        List<Person> people = new List<Person>();

        // Create instances of Student and Instructor
        Student alice = new Student(1, "Alice", 20);
        Student bob = new Student(2, "Bob", 21);
        Instructor john = new Instructor(3, "John", 45);

        // Add them to the people list
        people.Add(alice);
        people.Add(bob);
        people.Add(john);

        // Display information for each person in the list
        foreach (var person in people)
        {
            person.DisplayInformation();
            Console.WriteLine();
        }

        // Example usage
        Department csDepartment = new Department(1, "Computer Science");
        Course cs101 = new Course(101, "Introduction to Computer Science", csDepartment);
        Class cs101Class = new Class(1, "CS101", "John Doe", "Computer Science", cs101);
        

        cs101Class.AddStudent(alice);
        cs101Class.AddStudent(bob);

        csDepartment.AddClass(cs101Class);

        csDepartment.DisplayInformation();
        Console.WriteLine();
        cs101Class.DisplayInformation();
        Console.WriteLine();
        alice.DisplayInformation();
        Console.WriteLine();
        bob.DisplayInformation();
    }
}

