using System.Security.Cryptography.X509Certificates;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n------ Restoran Sistemine Xoş Gelmişsiniz ------".ToUpper());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Menyuya Yemek Elave Et");
                Console.WriteLine("2. Menyunu Göster");
                Console.WriteLine("3. Sifariş Yarat");
                Console.WriteLine("4. Sifarişleri Göster");
                Console.WriteLine("5. Çıxış");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Bir seçim edin (1-5): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        Menu.DisplayMenu();
                        break;
                    case "3":
                        CreateOrderItem();
                        break;
                    case "4":
                        Restaurant.DisplayOrders();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim, yeniden cehd edin.");
                        break;
                }
            }
        }
        public static void CreateMenuItem()
        {
            MenuItem newMenuItem= new MenuItem();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Yeni menyu yemeyinin adını daxil edin: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            newMenuItem.Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Yeni menyu yemeyinin qiymetini daxil edin: ");
            bool validPrice = false; 
            while (!validPrice)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    newMenuItem.Price = float.Parse(Console.ReadLine());
                    validPrice = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zehmet olmasa, doğru bir eded daxil edin.".ToUpper());
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Yeni menyu yemeyinin tesvirini daxil edin: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            newMenuItem.Description = Console.ReadLine();
            Menu.addItem(newMenuItem);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{newMenuItem.Name} menyuya elave olundu.".ToUpper());
        }
        public static void CreateOrderItem()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Müşterinin adını daxil edin: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Müşterinin soyadını daxil edin: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string surname = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Müşterinin telefon nömresini daxil edin: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string phone = Console.ReadLine();
            Customer customer = new Customer(name, surname, phone);
            Order newOrder = new Order(customer);
            bool running = true;
            while (running)
            {
                Menu.DisplayMenu();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Sifarişe elave etmek üçün menyu ID-sini daxil edin (ve ya 'bitdi' yazın): ".ToUpper());
                Console.ForegroundColor = ConsoleColor.Blue;
                string itemChoice = Console.ReadLine();
                if (itemChoice.ToLower() == "bitdi")
                {
                    running = false;
                }
                else
                {
                    int itemId = int.Parse(itemChoice);
                    try
                    {
                        MenuItem choiceMenu = Menu.FindMenuItem(itemId);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"Neçe eded {choiceMenu.Name} elave etmek isteyirsiniz: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int say = int.Parse(Console.ReadLine());
                        OrderItem orderItem = new OrderItem(choiceMenu, say);
                        newOrder.AddOrder(orderItem);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yanlis ID daxil etdiniz.".ToUpper());
                    }
                   
                }
            }
            Restaurant.TakeOrder(newOrder);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{customer.Name} {customer.Surname} üçün sifariş yaradıldı.");
        }

    }
}
