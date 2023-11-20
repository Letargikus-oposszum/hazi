﻿using hazi;

Console.WriteLine("nem");

var filecontent = File.ReadLines("student.csv");

var student_list = new List<Student>();
var student_grades = new List<float>();
var student_names = new List<string>();
var student_class = new List<string>();


foreach (var line in filecontent.Skip(1))
{
    var student = new Student();
    var data = line.Split(',');
    student.Name = data[0];
    student.Class = data[1];
    student.grade = Convert.ToInt32(data[2]);
    student_list.Add(student);
    student_grades.Add(student.grade);
}

foreach (var student in student_list)
{
    if (student_names.Contains(student.Name))
    {
        continue;
    }
    student_names.Add(student.Name);
}
foreach (var names in student_names)
{
    Console.WriteLine($"Diákok nevei: {names}");
}

foreach (var student in student_list)
{
    if (student_class.Contains(student.Class))
    {
        continue;
    }
    student_names.Add(student.Class);
}
foreach (var classname in student_class)
{
    Console.WriteLine($"Tantárgyak: {classname}");
}
foreach (var student in student_list)
{
    if (student_grades.Contains(student.grade))
    {
        continue;
    }
    student_grades.Add(student.grade);
}
foreach (var grade in student_grades)
{
    Console.WriteLine($"Jegyek: {grade}");
}

float average = student_grades.Sum() / student_grades.Count();
Console.WriteLine("---------------------------");
Console.WriteLine($"Grades' average: {average}");
Console.WriteLine("---------------------------");

foreach (var student in student_list)
{
    float studentTotalGrade = student_grades.Where(grade => grade == student.grade).Sum();
    Console.WriteLine($"{student.Name}, Total Grade: {studentTotalGrade}");
}

// Tantárgyanként összegzés
foreach (var classname in student_class)
{
    float classTotalGrade = student_list.Where(student => student.Class == classname).Sum(student => student.grade);
    Console.WriteLine($"Class: {classname}, Total Grade: {classTotalGrade}");
}