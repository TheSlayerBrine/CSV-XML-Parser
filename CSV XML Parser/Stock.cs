using CsvXmlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public class Stock
    {
        public static List<Item> Items;
        public static void SetStock(List<Item> itemList)
        {
            Items = itemList;
        }
        public static List<Item> GetStock() {  return Items; }
        public static void AddToStock(Item item) { Items.Add(item); }
        public static void RemoveFromStock(Item item) { Items.Remove(item); }
    }
}
