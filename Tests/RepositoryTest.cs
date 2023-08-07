using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CsvXmlParser.Repositories;
using CsvXmlParser;

namespace Tests
{
    public class RepositoryTest
    {

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2,new int[]  { 1, 3 })]   
        public void BuyItemTestSuccess(int[] initialStockIds, int idOfBoughtItem, int[] expectedStockIds)
        {
            //Arrange
            var repo = new Repository();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); //Set a default price
            }
            Stock.SetStock(initialStock);

            Item itemToBuy = new Item { Id = idOfBoughtItem, Name = $"Item {idOfBoughtItem}", Price = 9.99 };

            //Act
            repo.BuyItemFromStock(itemToBuy.Id);

            //Assert
            List<Item> expectedStock = new List<Item>();
            foreach (var id in expectedStockIds)
            {
                expectedStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 });
            }
            Assert.False(Stock.GetStock().Any(i => i.Id == 2));
            Assert.True(Stock.GetStock().Count == expectedStock.Count);
        }
        [Theory]
        [InlineData(new int[] { 4, 5, 6 }, 7, new int[] { 4, 5, 6 })] //Item not in stock, stock should remain unchanged
        public void BuyItemThrowErrorTest(int[] initialStockIds, int idOfBoughtItem, int[] expectedStockIds)
        {
            //Arrange
            var repo = new Repository();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); //Set a default price
            }
            Stock.SetStock(initialStock);

            Item itemToBuy = new Item { Id = idOfBoughtItem, Name = $"Item {idOfBoughtItem}", Price = 9.99 };

            //Act
           /* repo.BuyItemFromStock(itemToBuy.Id);*/

            //Assert
          
            Assert.Throws<System.ArgumentException> (() => repo.BuyItemFromStock(itemToBuy.Id));
        }
            [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 5, 6 }, 7, new int[] { 5, 6, 3 })]
        public void TestSellItem(int[] initialStockIds, int newItemId, int[] expectedStockIds)
        {
            //Arrange
            var repository = new Repository();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); 
            }
            Stock.SetStock(initialStock);

            //Create the item to sell
            Item newItem = new Item { Id = newItemId, Name = $"Item {newItemId}", Price = 9.99 };

            //Act
            repository.SellItem(newItem);

            //Assert
            List<Item> expectedStock = new List<Item>();
            foreach (var id in expectedStockIds)
            {
                expectedStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 });
            }
            var lastId = Stock.GetStock().Last().Id;
            Assert.True(expectedStock.Count == Stock.GetStock().Count && Stock.GetStock().Count == lastId  );
           
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2, "New Name", new string[] { "Item 1", "New Name", "Item 3" })]
        public void TestEditNameOfSpecificItemSuccess(int[] initialStockIds, int itemIdToEdit, string newName, string[] expectedNames)
        {
            //Arrange
            var repository = new Repository();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); 
            }
            Stock.SetStock(initialStock);

            //Act
            repository.EditNameOfSpecificItem(itemIdToEdit, newName);

            //Assert
            List<string> expectedStockNames = new List<string>(expectedNames);
            List<string> actualStockNames = Stock.GetStock().Select(item => item.Name).ToList();
            Assert.Equal(expectedStockNames, actualStockNames);
        }
        [Theory]
        [InlineData(new int[] { 4, 5, 6 }, 7, "New Item", new string[] { "Item 4", "Item 5", "Item 6" })] //Item not in stock, stock should remain unchanged
        public void TestEditNameOfSpecificItemExceptionThrow(int[] initialStockIds, int itemIdToEdit, string newName, string[] expectedNames)
        {
            //Arrange
            var repository = new Repository();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 });
            }
            Stock.SetStock(initialStock);

            //Act
/*            repository.EditNameOfSpecificItem(itemIdToEdit, newName);*/

            //Assert
            
            Assert.Throws<System.ArgumentException>(() => repository.EditNameOfSpecificItem(itemIdToEdit, newName));
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2, 15.5, new double[] { 9.99, 15.5, 9.99 })]
        public void TestEditPriceSuccess(int[] initialStockIds, int itemIdToEdit, double newPrice, double[] expectedPrices)
        {
            //Arrange
            var repository = new Repository();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); 
            }
            Stock.SetStock(initialStock);

            //Act
            repository.EditPriceOfSpecificItem(itemIdToEdit, newPrice);

            //Assert
            List<double> expectedStockPrices = new List<double>(expectedPrices);
            List<double> actualStockPrices = Stock.GetStock().Select(item => item.Price).ToList();
            Assert.Equal(expectedStockPrices, actualStockPrices);
        }
        [Theory]
        [InlineData(new int[] { 4, 5, 6 }, 7, 20.0, new double[] { 9.99, 9.99, 9.99 })] //Item not in stock, stock should remain unchanged
        public void TestEditPriceThrowError(int[] initialStockIds, int itemIdToEdit, double newPrice, double[] expectedPrices)
        {
            //Arrange
            var repository = new Repository();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 });
            }
            Stock.SetStock(initialStock);

            //Act
         /*   repository.EditPriceOfSpecificItem(itemIdToEdit, newPrice);*/

            //Assert
            Assert.Throws<System.ArgumentException>(() => repository.EditPriceOfSpecificItem(itemIdToEdit, newPrice));
        }
    }
}



