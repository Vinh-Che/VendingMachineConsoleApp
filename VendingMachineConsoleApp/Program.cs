using VendingMachineConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        VendingMachine vm = new VendingMachine();
        bool running = true;

        Console.WriteLine("Vending Machine is ready!");
        while (running)
        {
            Console.Write("> ");
            string command = Console.ReadLine();
            string[] parts = command.Split(' ');

            switch (parts[0].ToLower())
            {
                case "list":
                    vm.ListProducts();
                    break;
                case "insert":
                    if (parts.Length > 1 && int.TryParse(parts[1], out int amount))
                    {
                        vm.InsertMoney(amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount");
                    }
                    break;
                case "recall":
                    vm.RecallMoney();
                    break;
                case "order":
                    if (parts.Length > 1)
                    {
                        vm.OrderProduct(command.Substring(6)); // Remove "order " from command
                    }
                    else
                    {
                        Console.WriteLine("Please specify a product to order");
                    }
                    break;
                case "exit":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }
}
