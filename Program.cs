using System;
using System.Collections.Generic;

namespace StudentManagementSystem;

// Part 1 Basic System Design
class Student
{
    // Attributes
    public int StudentID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> CoursesEnrolled { get; set; }

    // Constructor
    public Student(int studentID, string name, int age)
    {
        StudentID = studentID;
        Name = name;
        Age = age;
        CoursesEnrolled = new List<string>();
    }

    // Methods
    public void EnrollCourse(string course)
    {
        CoursesEnrolled.Add(course);
    }

    public void DropCourse(string course)
    {
        CoursesEnrolled.Remove(course);
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Student ID: {StudentID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine("Courses Enrolled:");
        foreach (var course in CoursesEnrolled)
        {
            Console.WriteLine($"- {course}");
        }
    }
}

// Class Class
class Class
{
    // Attributes
    public int ClassID { get; set; }
    public string Name { get; set; }
    public string Instructor { get; set; }
    public string Department { get; set; }
    public string Course { get; set; }
    public List<Student> Students { get; set; }

    // Constructor
    public Class(int classID, string name, string instructor, string department, string course)
    {
        ClassID = classID;
        Name = name;
        Instructor = instructor;
        Department = department;
        Course = course;
        Students = new List<Student>();
    }

    // Methods
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
        Console.WriteLine($"Course: {Course}");
        Console.WriteLine("Students:");
        foreach (var student in Students)
        {
            Console.WriteLine($"- {student.Name} (ID: {student.StudentID})");
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

// Instructor Class
class Instructor
{
    // Attributes
    public int InstructorID { get; set; }
    public string Name { get; set; }
    public List<Class> ClassesTaught { get; set; }

    // Constructor
    public Instructor(int instructorID, string name)
    {
        InstructorID = instructorID;
        Name = name;
        ClassesTaught = new List<Class>();
    }

    // Methods
    public void AddClass(Class classObj)
    {
        ClassesTaught.Add(classObj);
    }

    public void RemoveClass(Class classObj)
    {
        ClassesTaught.Remove(classObj);
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Instructor ID: {InstructorID}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Classes Taught:");
        foreach (var classObj in ClassesTaught)
        {
            Console.WriteLine($"- {classObj.Name} (ID: {classObj.ClassID})");
        }
    }
}
