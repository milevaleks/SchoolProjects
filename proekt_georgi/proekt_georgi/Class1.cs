Console.WriteLine("Current Users: ");
foreach (var employee in employees)
{
    Console.WriteLine(employee.PrintEmployeeAdmin());
}
Console.WriteLine();

Console.Write("How many users would you like to remove? ");
int n = int.Parse(Console.ReadLine());
Console.WriteLine();

for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"Please enter information about the {i} employee you would like to fire.");
    string employeeToFire = Console.ReadLine();

    string[] readText = File.ReadAllLines("Users.txt");
    File.WriteAllText("Users.txt", String.Empty);

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