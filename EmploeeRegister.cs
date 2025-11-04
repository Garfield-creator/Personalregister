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
            Console.WriteLine("[3] Avsluta\n");
            string choice_input = Console.ReadLine()!;
            if (choice_input != null && int.TryParse(choice_input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Namn på den nya personalen? Skriv 'avbryt' för att avbryta.");
                        string name = Console.ReadLine() ?? "";
                        if (string.Equals(name, "avbryt"))
                        {
                            Console.WriteLine("Avbryter!\n");
                            break;
                        }
                        else if (name == "")
                        {
                            goto case 1;
                        }
                        WageInput:
                        Console.WriteLine("Lön till den nya personalen? Skriv 'avbryt' för att avbryta.");
                        string wage_input = Console.ReadLine() ?? "";
                        int wage;
                        if (string.Equals(wage_input, "avbryt"))
                        {
                            Console.WriteLine("Avbryter!\n");
                            break;
                        }
                        else if (wage_input == "")
                        {
                            Console.WriteLine("Lön är obligatorisk!\n");
                            goto WageInput;
                        }
                        else if (!int.TryParse(wage_input, out wage))
                        {
                            Console.WriteLine("Lön måste vara i hela kronor!\n");
                            goto WageInput;
                        }
                        registry.Add(new Employee(name, wage));
                        Console.WriteLine("");
                        break;
                    case 2:
                        registry = [.. registry.OrderBy(s => s.Name)];
                        Console.WriteLine("");
                        Console.WriteLine("Register:");
                        foreach (var emplyee in registry)
                        {
                            Console.WriteLine(emplyee);
                        }
                        Console.WriteLine("");
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
            Console.WriteLine("=========================");
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