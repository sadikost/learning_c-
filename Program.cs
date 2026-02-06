using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;

namespace word_out
{
    internal class Program
    {
        static string filePath = "clients_db.txt";
        static void ShowAll(List<string> clients, bool sortByAlphabet = false, bool fromShortToLong = false)            
        {
            List<string> listToPrint = clients;

            if (sortByAlphabet)
            {
                listToPrint = new List<string>(clients);
                listToPrint.Sort();
            }
            else if (fromShortToLong)
            {
                listToPrint = new List<string>(clients);
                listToPrint.Sort((x, y) => x.Length.CompareTo(y.Length));
            }
            
            Console.WriteLine("------ Current client list ------");
            for (int i = 0; i < listToPrint.Count; i++)
                Console.WriteLine($"Client {i + 1}: {listToPrint[i]}");
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
                Console.WriteLine("MENU");
                Console.WriteLine("1. Show clients list");
                Console.WriteLine("1.1. Show list of clients alphabetically");
                Console.WriteLine("1.2. Show list of clients from short to long");
                Console.WriteLine("2. Add new client");
                Console.WriteLine("3. Customer search");
                Console.WriteLine("4. Delete the entire list");
                Console.WriteLine("5. Remove customer");
                Console.WriteLine("6. Exit");
                Console.WriteLine();

                Console.Write("Choice number: ");
                string choice = Console.ReadLine();

                if(choice == "1")
                {
                    ShowAll(clients);
                }
                Console.WriteLine();

                if (choice == "1.1")
                {
                    ShowAll(clients, sortByAlphabet: true);
                }
                Console.WriteLine();

                if (choice == "1.2")
                {
                    ShowAll(clients, fromShortToLong: true);
                }
                Console.WriteLine();

                if (choice == "2")
                {
                    Console.Write("Enter customer name: ");
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
                    Console.WriteLine("Delete the entire database? (yes/no)");
                    string option = Console.ReadLine();

                    if(option == "yes")
                    {
                        clients.Clear();
                        SaveData(clients);
                        Console.WriteLine("[System]: The database has been cleared.\n");
                    }
                    if(option == "no")                   
                        continue;                   
                }
                if (choice == "5")
                {
                    Console.WriteLine("Enter a client number to remove: ");
                    int indexToDelete = int.Parse(Console.ReadLine()) - 1;

                    if (indexToDelete >= 0 && indexToDelete < clients.Count)
                    {
                        clients.RemoveAt(indexToDelete);
                        SaveData(clients);
                        Console.WriteLine("Сlient successfully deleted.\n");
                    }
                    else Console.WriteLine("Error: client with that name does not exist.\n");
                }
                
                if(choice == "6")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                
            }
        }
    }
}
