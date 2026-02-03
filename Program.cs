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
        
        static void Main(string[] args)
        {
            
            string[] clients = { "Andriy", "Yaroslav", "Oleksandr", "Ihor", "Yuriy" };

            while (true)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Show clients list");
                Console.WriteLine("2. Add new client");
                Console.WriteLine("3. Exit");
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
                    AddCustomer(ref clients, name);
                    Console.WriteLine("Client successfully added!");
                }
                Console.WriteLine();
                if(choice == "3")
                {
                    break;
                }
                
            }
        }
    }
}
