// See https://aka.ms/new-console-template for more information
using P235OperatorOverloading;

Console.WriteLine("Hello, World!");

int a = 1; int b = 2;
//a + b;

Student student1 = new Student();
student1.Age = 66;
Student student2 = new Student();
student2.Age = 56;
double c = student1 / student1;

double d = student2 / student2;
Console.WriteLine(c != d);
Console.WriteLine(c);
 //int age = student1 + student2;
//Console.WriteLine(age);