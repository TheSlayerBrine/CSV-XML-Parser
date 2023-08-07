using CsvXmlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ShoppingCartTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2, new int[] {}, new int[] { 1, 3 })]
        public void TestCheckOutSuccess(int[] initialStockIds, int itemIdToAdd, int[] expectedCartIds, int[] expectedStockIds)
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); 
            }
            Stock.SetStock(initialStock);

            // Act
            shoppingCart.AddToCart(itemIdToAdd);
            shoppingCart.Checkout();

            // Assert
            List<int> expectedCartItemIds = new List<int>(expectedCartIds);
            List<int> actualCartItemIds = shoppingCart.ShoppingCartItems.Select(item => item.Id).ToList();
            Assert.Equal(expectedCartItemIds, actualCartItemIds);

            List<int> expectedStockItemIds = new List<int>(expectedStockIds);
            List<int> actualStockItemIds = Stock.GetStock().Select(item => item.Id).ToList();
            Assert.Equal(expectedStockItemIds, actualStockItemIds);
        }
        [Theory]     
        [InlineData(new int[] { 1, 2, 3 }, 4, new int[] { }, new int[] { 1, 2, 3 })] 
        public void TestAddToCartThrowError(int[] initialStockIds, int itemIdToAdd, int[] expectedCartIds, int[] expectedStockIds)
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            List<Item> initialStock = new List<Item>();
            foreach (var id in initialStockIds)
            {
                initialStock.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 });
            }
            Stock.SetStock(initialStock);

            // Act
         /*   shoppingCart.AddToCart(itemIdToAdd);*/

            // Assert
            Assert.Throws<System.ArgumentException>(() => shoppingCart.AddToCart(itemIdToAdd));
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2, new int[] { 1, 3 })]
        public void TestRemoveFromCartSuccess(int[] initialCartIds, int itemIdToRemove, int[] expectedCartIds)
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            List<Item> initialCart = new List<Item>();
            foreach (var id in initialCartIds)
            {
                initialCart.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); 
            }
            shoppingCart.ShoppingCartItems = initialCart;

            // Act
            shoppingCart.RemoveFromCart(itemIdToRemove);

            // Assert
            List<int> expectedCartItemIds = new List<int>(expectedCartIds);
            List<int> actualCartItemIds = shoppingCart.ShoppingCartItems.Select(item => item.Id).ToList();
            Assert.Equal(expectedCartItemIds, actualCartItemIds);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3 })] // Item not in cart
        public void TestRemoveFromCartThrowError(int[] initialCartIds, int itemIdToRemove, int[] expectedCartIds)
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            List<Item> initialCart = new List<Item>();
            foreach (var id in initialCartIds)
            {
                initialCart.Add(new Item { Id = id, Name = $"Item {id}", Price = 9.99 }); 
            }
            shoppingCart.ShoppingCartItems = initialCart;

            // Act
            /*  shoppingCart.RemoveFromCart(itemIdToRemove);*/

            // Assert
            Assert.Throws<System.ArgumentException>(() => shoppingCart.RemoveFromCart(itemIdToRemove));
        }
        [Fact]
        public void TestEmptyCart()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var initialCart = new List<Item>
            {
                new Item { Id = 1, Name = "Item 1", Price = 9.99 },
                new Item { Id = 2, Name = "Item 2", Price = 20.0 },
                new Item { Id = 3, Name = "Item 3", Price = 15.0 }
            };
            shoppingCart.ShoppingCartItems = initialCart;

            // Act
            shoppingCart.EmptyCart();

            // Assert
            Assert.Empty(shoppingCart.ShoppingCartItems);
        }

       /* [Fact]
        public void TestCheckout()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var initialCart = new List<Item>
            {
                new Item { Id = 1, Name = "Item 1", Price = 9.99 },
                new Item { Id = 2, Name = "Item 2", Price = 20.0 },
                new Item { Id = 3, Name = "Item 3", Price = 15.0 }
            };
            Stock.SetStock(initialCart);
            shoppingCart.ShoppingCartItems = initialCart;

            // Act
            shoppingCart.Checkout();

            // Assert
            Assert.Empty(shoppingCart.ShoppingCartItems);
            Assert.Empty(Stock.GetStock());
        }*/
    }
}
