using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;

namespace VHODNO
{
    class Program
    {
        static List<Employee> employees = new List<Employee>();
        static Employee employee = new Employee();

        static void Main(string[] args)
        {
            using (SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer())
            {                
                using (StreamReader sr = new StreamReader(@"C:\Users\AleksMilev\source\repos\VHODNO\VHODNO\Users.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] token = line.Split().ToArray();                                              
                        employee.FirstName = token[0];
                        employee.MiddleName = token[1];
                        employee.LastName = token[2];
                        employee.Address = token[3];
                        employee.WorkNumber = int.Parse(token[4]);
                        employee.Salary = double.Parse(token[5]);

                        employees.Add(employee);
                    }
                }

                Console.WriteLine("Welcome! I am Penka.");
            VurniSa:
                Console.Write("Who are you? (Admin/User-WorkNum) ");
                synth.Speak("Welcome. I am Penka. Who are you");
                string[] user = Console.ReadLine().Split('-').ToArray();
                Console.WriteLine();
                Console.Clear();


                if (user[0] == "User")
                {
                    User();
                    
                }
                else if (user[0] == "Admin" && user[1] == "69")
                {
                    Admin();
                }
                else
                {
                    Console.WriteLine("Non existent user. Please try again.");
                    synth.Speak("Non existent user. Plaese try again");
                    Console.WriteLine();
                    Console.Clear();
                    goto VurniSa;
                }





            }
        }
        static void User()
        {
            using (SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer())
            {
                Console.WriteLine("Available commands: ");
                Console.WriteLine("1. View");
                Console.WriteLine("2. Sort");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("What would you like to do ? ");
                synth.Speak("What would you like to do");
                int command = int.Parse(Console.ReadLine());
                Console.WriteLine();

                while (command != 3)
                {
                    if (command == 1)
                    {
                        ViewUser();
                    }
                    else if (command == 2)
                    {
                        Console.WriteLine("1. First Name");
                        Console.WriteLine("2. Last Name");
                        Console.WriteLine("3. Address");
                        Console.WriteLine("4. Salary");
                    ifIsNot:
                        Console.Write("Sort by ");
                        synth.Speak("Sort by");
                        int option = int.Parse(Console.ReadLine());

                        if (option == 1)
                        {
                            employees = employees.OrderBy(f => f.FirstName).ToList();
                        }
                        else if (option == 2)
                        {
                            employees = employees.OrderBy(l => l.LastName).ToList();
                        }
                        else if (option == 3)
                        {
                            employees = employees.OrderBy(a => a.Address).ToList();
                        }
                        else if (option == 4)
                        {
                            employees = employees.OrderBy(s => s.Salary).ToList();
                        }
                        else
                        {
                            Console.WriteLine("Wrong option. Please try again.");
                            synth.Speak("Wrong option. Please try again");
                            goto ifIsNot;
                        }
                        File.WriteAllText("Users.txt", String.Empty);
                        using (StreamWriter sw = new StreamWriter("Users.txt"))
                        {
                            for (int i = 0; i < employees.Count; i++)
                            {
                                Employee current = employees[i];
                                sw.WriteLine($"{current.FirstName} {current.MiddleName} {current.LastName} {current.Address} {current.WorkNumber} {current.Salary}");
                            }
                        }
                    }
                }
            }    
        }
        static void Admin()
        {
            using (SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer())
            {               
                Console.WriteLine("Available commands: ");
                    Console.WriteLine("1. Add");
                    Console.WriteLine("2. Remove");
                    Console.WriteLine("3. View");
                    Console.WriteLine("4. Sort");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine();
                    Console.Write("What would you like to do ? ");
                    synth.Speak("What would you like to do");
                    int command = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    while (command != 5)
                    {
                        if (command == 1)
                        {
                            Add();
                        }
                        else if (command == 2)
                        {
                            Remove();
                        }
                        else if (command == 3)
                        {
                            ViewAdmin();
                        }
                        else if (command == 4)
                        {
                            Console.WriteLine("1. First Name");
                            Console.WriteLine("2. Last Name");
                            Console.WriteLine("3. Address");
                            Console.WriteLine("4. Salary");
                    ifIsNot:
                            Console.Write("Sort by ");
                            synth.Speak("Sort by");
                            int option = int.Parse(Console.ReadLine());

                            if (option == 1)
                            {
                                employees = employees.OrderBy(f => f.FirstName).ToList();
                            }
                            else if (option == 2)
                            {
                                employees = employees.OrderBy(l => l.LastName).ToList();
                            }
                            else if (option == 3)
                            {
                                employees = employees.OrderBy(a => a.Address).ToList();
                            }
                            else if (option == 4)
                            {
                                employees = employees.OrderBy(s => s.Salary).ToList();
                            }
                            else
                            {
                                Console.WriteLine("Wrong option. Please try again.");
                                synth.Speak("Wrong option. Please try again");
                                goto ifIsNot;
                            }
                            File.WriteAllText("Users.txt", String.Empty);
                            using (StreamWriter sw = new StreamWriter("Users.txt"))
                            {
                                for (int i = 0; i < employees.Count; i++)
                                {
                                    Employee current = employees[i];
                                    sw.WriteLine($"{current.FirstName} {current.MiddleName} {current.LastName} {current.Address} {current.WorkNumber} {current.Salary}");
                                }
                            }
                        }
                        else if (command == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong command. Please try again. ");
                            synth.Speak("Wrong command. Please try again");
                            goto ifIsNot2;
                        }
                ifIsNot2:
                        Console.WriteLine();
                        Console.WriteLine("Available commands: ");
                        Console.WriteLine("1. Add users");
                        Console.WriteLine("2. Remove users");
                        Console.WriteLine("3. View users");
                        Console.WriteLine("4. Sort users");
                        Console.WriteLine("5. Exit");
                        Console.WriteLine();
                        Console.Write("What would you like to do next? ");
                        synth.Speak("What would you like to do next");
                        command = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }
                
               
            }
        }
        static void Add()
        {
            using (SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer())
            {
                Console.Write("How many users would you like to add? ");
                synth.Speak("How many users would you like to add"); 
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();
                for (int i = 1; i <= n; i++)
                {
                    Employee employee = new Employee();
                    Console.WriteLine($"Please enter information about your {i} employee (Name MiddleName LastName Address WorkNumber Salary)");
                    synth.Speak("Please enter information");
                    string[] employeeReader = Console.ReadLine().Split(' ').ToArray();
                    Console.WriteLine();

                    employee.FirstName = employeeReader[0];
                    employee.MiddleName = employeeReader[1];
                    employee.LastName = employeeReader[2];
                    employee.Address = employeeReader[3];
                    employee.WorkNumber = int.Parse(employeeReader[4]);
                    employee.Salary = double.Parse(employeeReader[5]);

                    employees.Add(employee);

                    using (StreamWriter users = new StreamWriter(@"C:\Users\AleksMilev\source\repos\VHODNO\VHODNO\Users.txt", true))
                    {
                        users.WriteLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName} {employee.Address} {employee.WorkNumber} {employee.Salary}");
                    }
                }

                Console.WriteLine("Users successfully added!");
                synth.Speak("Users successfully added");
                Console.WriteLine();
            }
        }
        static void Remove()
        {
            using (SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer())
            {
                Console.WriteLine("Current Users: ");
                synth.Speak("Current Users");
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.PrintEmployeeAdmin());
                }
                Console.WriteLine();

                Console.Write("How many users would you like to remove? ");
                synth.Speak("How many users would you like to remove"); 
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();

                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"Please enter information about the {i} employee you would like to fire.");
                    synth.Speak("Please enter information");
                    string employeeToFire = Console.ReadLine();

                    string[] readText = File.ReadAllLines(@"C:\Users\AleksMilev\source\repos\VHODNO\VHODNO\Users.txt");
                    File.WriteAllText(@"C:\Users\AleksMilev\source\repos\VHODNO\VHODNO\Users.txt", String.Empty);

                    using (StreamWriter sw = new StreamWriter(@"C:\Users\AleksMilev\source\repos\VHODNO\VHODNO\Users.txt", true))
                    {
                        foreach (var line in readText)
                        {
                            if (!line.Equals(employeeToFire))
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                }

                employees.Clear();
                using (StreamReader sr = new StreamReader(@"C:\Users\AleksMilev\source\repos\VHODNO\VHODNO\Users.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] token = line.Split().ToArray();
                        Employee employee = new Employee();
                        employee.FirstName = token[0];
                        employee.MiddleName = token[1];
                        employee.LastName = token[2];
                        employee.Address = token[3];
                        employee.WorkNumber = int.Parse(token[4]);
                        employee.Salary = double.Parse(token[5]);

                        employees.Add(employee);
                    }
                }
            }

        }
        static void ViewAdmin()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.PrintEmployeeAdmin());
            }
        }
        static void ViewUser()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.PrintEmployeeStandard());
            }
        }

    }
}