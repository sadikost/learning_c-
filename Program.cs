using System;
using System.Data;
using System.Security.Cryptography;

namespace word_out
{
    internal class Program
    {
        static string filePath = "clients_db.txt";
        static void ShowAll(List<string> clients)
        {
            Console.WriteLine("------ Current client list ------");
            for (int i = 0; i < clients.Count; i++)
                Console.WriteLine($"Client {i + 1}: {clients[i]}");
            Console.WriteLine("---------------------------------\n");           
        }
        
        static void AddCustomer(List<string> clients,string clientName)
        {
            clients.Add(clientName);           
        }
        
        static int SearchCustomer(List<string> clients, string clientName)
        {
            return clients.IndexOf(clientName);
        }
        static bool IsValidName(string clientName)
        {
            if (string.IsNullOrWhiteSpace(clientName)) return false;

            foreach(char c in clientName)
            {
                if (!char.IsLetter(c) && c != ' ') return false;
            }

            return true;
        }
        static void SaveData(List<string> clients)
        {
            File.WriteAllLines(filePath, clients.ToArray());
            Console.WriteLine("[System]: Data saved succesfully.\n");
        }
        static List<string> LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] fileData = File.ReadAllLines(filePath);
                return new List<string>(fileData);
            }
            return new List<string>();
        }

        static void Main(string[] args)
        {
            
            List<string> clients = LoadData();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Greeting!\n");
            Console.WriteLine(DateTime.Now + "\n");

            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("MENU".PadRight(25));
                Console.WriteLine("1. Show clients list".PadRight(25));
                Console.WriteLine("2. Add new client".PadRight(25));
                Console.WriteLine("3. Customer search".PadRight(25));
                Console.Write(    "4. Exit".PadRight(25));
                Console.ResetColor();
                Console.WriteLine();

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
                        AddCustomer(clients, name);
                        SaveData(clients);
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
