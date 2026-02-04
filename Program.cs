using System.Data;
using System.Security.Cryptography;

namespace word_out
{
    internal class Program
    {
        static void AddCustomer(ref string[] clientArr,string clientName)
        {
            string[] newClientArr = new string[clientArr.Length + 1];
            newClientArr[newClientArr.Length - 1] = clientName;
            for(int i =0;i < clientArr.Length; i++)
            {
                newClientArr[i] = clientArr[i];
            }
            clientArr = newClientArr;            
        }
        static void ShowAll(string[] clientArr)
        {
            Console.WriteLine("------ Current client list ------");
            for (int i = 0; i < clientArr.Length; i++)
                Console.WriteLine($"Client {i + 1}: {clientArr[i]}");
            Console.WriteLine("---------------------------------\n");           
        }
        static int SearchCustomer(string[]clientArr, string name)
        {
            for(int i = 0; i < clientArr.Length; i++)
            {
                if(clientArr[i] == name)
                {
                    return i;
                }
            }
            return -1;
        }
        static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            foreach(char c in name)
            {
                if (!char.IsLetter(c) && c != ' ') return false;
            }

            return true;
        }
        
        static void Main(string[] args)
        {
            
            string[] clients = { "Andriy", "Yaroslav", "Oleksandr", "Ihor", "Yuriy" };

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Greeting!\n");
            Console.WriteLine(DateTime.Now + "\n");

            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine("MENU".PadRight(25));
                Console.WriteLine("1. Show clients list".PadRight(25));
                Console.WriteLine("2. Add new client".PadRight(25));
                Console.WriteLine("3. Customer search".PadRight(25));
                Console.WriteLine("4. Exit".PadRight(25));
                Console.ResetColor();
                Console.Write("Choice number: ");

                string choice = Console.ReadLine();

                if(choice == "1")
                {
                    ShowAll(clients);
                }
                Console.WriteLine();
                if(choice == "2")
                {
                    Console.Write("2.Enter customer name: ");
                    string name = Console.ReadLine();
                    if (IsValidName(name))
                    {
                        AddCustomer(ref clients, name);
                        Console.WriteLine("Client successfully added!");
                    }
                    else
                    {
                        Console.WriteLine("Error: Use only letters!");
                    }
                    Console.WriteLine();
                }

                if(choice == "3")
                {
                    Console.WriteLine("Enter a name to search for index");
                    Console.WriteLine();
                    string name = Console.ReadLine();

                    if (IsValidName(name))
                    {
                        int indexOfName = SearchCustomer(clients, name);
                        Console.WriteLine($"The name {name} is under the index: {indexOfName}");
                    }
                                      
                    Console.WriteLine();  
                }
                
                if(choice == "4")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                
            }
        }
    }
}
