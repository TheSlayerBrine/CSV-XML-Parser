using com.sun.org.apache.xml.@internal.security;
using CsvXmlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public class ShoppingCart
    {
        public List<Item> ShoppingCartItems;      
        public ShoppingCart() {  ShoppingCartItems = new List<Item>();}

        public void AddToCart(int itemId)
        {
            int itemIndex = Stock.GetStock().FindIndex(i => i.Id == itemId);
            if (itemIndex != -1)
            {
                var itemToAdd = Stock.GetStock()[itemIndex];
                ShoppingCartItems.Add(itemToAdd);
                Stock.RemoveFromStock(itemToAdd);
            }
            else
            throw new ArgumentException($"Element with id {itemId} is not in stock");
        }
        public void RemoveFromCart(int itemId) 
        {
            var itemToRemove = Stock.GetStock().FirstOrDefault(item => item.Id == itemId);
            if (itemToRemove.Id != -1)
            ShoppingCartItems.Remove(itemToRemove);
            else throw new ArgumentException($"Item with Id {itemId} is not in cart");

        }
        public void EmptyCart() 
        {
           ShoppingCartItems = new List<Item>();
        }
        public void ShowCart()
        {
            foreach (var item in ShoppingCartItems)
            { Console.Write(item.Id); Console.Write(item.Name); Console.Write(item.Price); 
                Console.WriteLine();
            }
        }
        public void Checkout()
        {
            
            foreach(var item in ShoppingCartItems)
            {
                Stock.GetStock().Remove(item);
            }
            EmptyCart();
        }
    }
}
