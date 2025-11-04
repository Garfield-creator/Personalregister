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
            Console.WriteLine("[2] Ta bort personal");
            Console.WriteLine("[3] Skriv ut register");
            Console.WriteLine("[0] Avsluta\n");
            string choice_input = Console.ReadLine()!;
            Console.WriteLine("");
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
                        Console.WriteLine("Vem vill du ta bort?");
                        for (int i = 0; i < registry.Count; i++)
                        {
                            Console.WriteLine("[" + (i+1) + "]" + " " + registry[i].Name);
                        }
                        Console.WriteLine("[0] Avbryt");
                        string remove_input = Console.ReadLine() ?? "";
                        int remove;
                        if(!int.TryParse(remove_input, out remove))
                        {
                            Console.WriteLine("Ej giltit val. Försök igen.\n");
                            goto case 2;
                        }
                        if(remove == 0)
                        {
                            Console.WriteLine("Avbryter!\n");
                            break;
                        }
                        else if (remove < 0 || remove > registry.Count)
                        {
                            Console.WriteLine("[0] Ej giltit val. Försök igen.\n");
                            goto case 2;
                        }
                        else
                        {
                            Console.WriteLine(registry[remove - 1].Name + " har tagits bort!\n");
                            registry.RemoveAt(remove - 1);
                            break;
                        }
                    case 3:
                        registry = [.. registry.OrderBy(s => s.Name)];
                        Console.WriteLine("Register:");
                        Console.WriteLine("Namn".PadRight(30) + " Lön");
                        Console.WriteLine("------------------------------");
                        foreach (var emplyee in registry)
                        {
                            Console.WriteLine(emplyee.Name.PadRight(30) + " " + emplyee.Wage);
                        }
                        Console.WriteLine("");
                        break;
                    case 0:
                        Console.WriteLine("Tack för att du använde personalregistret!\n");
                        exit = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ej giltit val. Försök igen.\n");
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
}