using System;
using System.Collections.Generic;

class EmployeeRegister
{
    static void Main()
    {
        Console.WriteLine("PERSONALREGISTER");
        bool exit = false;
        List<Employee> registry = [];
        while (!exit)
        {
            Console.WriteLine("Meny:");
            Console.WriteLine("[1] Ny personal");
            Console.WriteLine("[2] Skriv ut register");
            Console.WriteLine("[3] Avsluta");
            string choice_input = Console.ReadLine();
            if (choice_input != null && int.TryParse(choice_input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Namn på den nya personalen? Skriv 'avbryt' för att avbryta.");
                        string name = Console.ReadLine();
                        if (string.Equals(name, "avbryt"))
                        {
                            break;
                        }
                        else if (name == null)
                        {
                            break;
                        }
                        Console.WriteLine("Lön till den nya personalen? Skriv 'avbryt' för att avbryta.");
                        string wage_input = Console.ReadLine();
                        int wage;
                        if (string.Equals(wage_input, "avbryt"))
                        {
                            break;
                        }
                        else if (wage_input == null)
                        {
                            break;
                        }
                        else if (!int.TryParse(wage_input, out wage))
                        {
                            break;
                        }
                        registry.Add(new Employee(name, wage));
                        foreach (var emplyee in registry)
                        {
                            Console.WriteLine(emplyee);
                        }
                        break;
                    case 2:
                        registry = [.. registry.OrderBy(s => s.Name)];
                        foreach(var emplyee in registry)
                        {
                            Console.WriteLine(emplyee);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Tack för att du använde personalregistret!");
                        exit = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ej giltit val. Försök igen.");
            }
        }
    }
}


class Employee
{
    public string Name { get; set; }

    public int Wage { get; set; }

    public Employee(string name, int wage)
    {
        Name = name;
        Wage = wage;
        Console.WriteLine(name + " tillagd!");
    }

    public override string ToString()
    {
        return (Name + " " + Wage).ToString();
    }
}