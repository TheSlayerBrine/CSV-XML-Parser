
using CsvXmlParser.Repositories;
using System.Xml.Linq;


namespace CsvXmlParser
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test Parsare
             var Parse = new CSVParser();
                string path = @"C:\Users\cgame\source\repos\NewRepo2\CSV XML Parser\faithful.csv";      
                var str = Parse.ReadCsvFileToString(path);
                Parse.ParseCsvToItemsList(str);

            /*   Parse.OutputTest();//output test for the parsing*/

            //Test repository
            var repo = new CsvRepository();
            repo.BuyItemFromStock(1);
            repo.BuyItemFromStock(2);
            repo.BuyItemFromStock(3);
            var item1 = new Item { Name = "ionescu antonio", Price = 1 };
            var item2 = new Item { Name = "paul paulica", Price = 2 };
            var item3 = new Item { Name = "ionescu alexandra", Price = 3};
            repo.SellItem(item1);
            repo.SellItem(item2);
            repo.SellItem(item3);
         /*   Parse.OutputTest();//output test for the repo*/

            // Test Shopping Cart
            var cart = new ShoppingCart();
            cart.AddToCart(5);
            cart.AddToCart(6);
            cart.ShowCart();
            Console.WriteLine("pauza");
               cart.EmptyCart();
            cart.AddToCart(7);
           /* cart.ShowCart();//Output test for the cart*/



        }
    }
}