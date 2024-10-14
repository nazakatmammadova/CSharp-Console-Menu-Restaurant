using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal static class Menu
    {
        public static List<MenuItem> menuItems { get; set; } = new List<MenuItem>();
        static Menu()
        {
            menuItems = new List<MenuItem>
                {
                  new MenuItem { Name = "Toyuq kababi", Price = 7, Description = "Toyuq" },
                  new MenuItem { Name = "Mix Pizza", Price = 22, Description = "Toyuq, gobelek, zeytun, pomidor , sous " },
                  new MenuItem { Name = "Lule kabab", Price = 12, Description = "Et" },
                  new MenuItem { Name = "Sezar salati", Price = 13, Description = "toyuq, cherry pomidor, kahi, yumurta" }
                };

        }
        public static void addItem(MenuItem item)
        {
            Console.ResetColor();
            if (!menuItems.Contains(item))
            {
                menuItems.Add(item);
            }
            else
            {
                Console.WriteLine("Menuda artiq var!!!");
            }
        }
        public static void removeItem(MenuItem item)
        {
            Console.ResetColor();
            if (menuItems.Contains(item))
            {
                menuItems.Remove(item);
            }
            else
            {
                Console.WriteLine("Bu mehsul menuda yoxdur");
            }
        }
        public static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Menu siyahisina baxin:".ToUpper());
            for (int i=0; i<menuItems.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{i+1}. {menuItems[i].Name} -------------------------- {menuItems[i].Price} azn");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Terkibi: {menuItems[i].Description}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
        public static MenuItem FindMenuItem(int id)
        {
            return menuItems[id - 1];
        }
    }
}


       

