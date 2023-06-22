using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.PresentationLayer
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; }
        public int ItemsCount { get { return Items.Count; } }
        public bool IsExitWanted { get; set; }

        public Menu()
        {
            IsExitWanted = false;
            Items = new();
        }

        public void PrintMenu(string title)
        {
            Console.WriteLine($"{title}\n");
            foreach (MenuItem menuItem in Items)
            {
                Console.WriteLine(menuItem);
            }
        }

        public void ExecuteSelectedItem(int itemIndex)
        {
            Items[itemIndex].ExecuteSelectedAction();
        }

    }
}
