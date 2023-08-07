using CsvXmlParser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Repositories
{
    public class Repository : IRepository
    {
        public void BuyItemFromStock(int itemId)
        {
            var itemToRemove = Stock.GetStock().FirstOrDefault(item => item.Id == itemId);

            if (itemToRemove != null)
            {
                Stock.GetStock().Remove(itemToRemove);
            }
            else
            {
                throw new ArgumentException($"Item with Id {itemId} is not in stock");
            }
        }
        public void EditItem(Item item)
        {            
        }
        public void EditPriceOfSpecificItem(int itemId, double newPrice) 
        {
            var editableItem = Stock.GetStock().FirstOrDefault(item => item.Id == itemId);

            if (editableItem != null)
            {
                int indexOfItem = Stock.GetStock().FindIndex(item => item.Id == itemId);

                Stock.GetStock()[indexOfItem].Price = newPrice;
            }
            else
            {
                throw new ArgumentException($"Item with Id {itemId} is not in stock");
            }
            
        }
        public void EditNameOfSpecificItem(int itemId, string newName) 
        {
            var editableItem = Stock.GetStock().FirstOrDefault(item => item.Id == itemId);

            if (editableItem != null)
            {
                int indexOfItem = Stock.GetStock().FindIndex(item => item.Id == itemId);

                Stock.GetStock()[indexOfItem].Name = newName;
            }
            else
            {
                throw new ArgumentException($"Item with Id {itemId} is not in stock");
            }
        }

        public void SellItem(Item newItem)
        {
            Stock.existingCount++;
            newItem.Id= Stock.existingCount;
           Stock.GetStock().Add(newItem);
        }

        public void ShowListOfExistingItems()
        {
            throw new NotImplementedException();
        }
    }
}
