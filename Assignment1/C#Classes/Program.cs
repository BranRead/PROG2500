// See https://aka.ms/new-console-template for more information
using C_Classes;
using System.Collections;

ArrayList arrayList = new ArrayList();
arrayList.Add(new Programmer("Brandon", "Read", "SomePlace, NS", 75000, 10));
arrayList.Add(new Manager("Betty", "Matheson", "SomePlace, NS", 300000, 4));
arrayList.Add(new Client("George", "Cove", "SomePlace, NS", true, 10000));

foreach (Person person in arrayList)
{
    if (person.GetType() == typeof(Programmer) || person.GetType() == typeof(Manager))
    {
        Employee employee = (Employee)person;
        employee.ComputePayCheck();
        employee.ComputePayRaise();
    }
    if (person.GetType() == typeof(Programmer)) {
        Programmer programmer = (Programmer)person;
        programmer.Work();
    }
}

Console.WriteLine(arrayList[1].ComputePayCheck());