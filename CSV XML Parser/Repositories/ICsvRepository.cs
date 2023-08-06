using CsvXmlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser.Repositories
{
    public interface ICsvRepository
    {
      
        public void SellItem(Item newItem);//Create new Item
        public void ShowListOfExistingItems();//Read list of Items (For ui)
        public void EditPriceOfSpecificItem(int itemId, double newPrice);//Update price of item
        public void EditNameOfSpecificItem(int itemId, string newName);//Update name of Item
        public void BuyItemFromStock(int itemId);//Delete from list
        



    }
}
