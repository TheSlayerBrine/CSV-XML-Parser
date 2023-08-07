
using CsvXmlParser.Repositories;
using System.Xml.Linq;


namespace CsvXmlParser
{
    class Program
    {
        static void Main(string[] args)
        {

            #region CsvParser and Repo
             var Parse = new CSVParser();
                 string path = @"C:\Users\cgame\source\repos\NewRepo2\CSV XML Parser\faithful.csv";      
                 var str = Parse.ReadFileToString(path);
                 Stock.SetStock(Parse.DeserializeCodeToItemList(str));

              /*Parse.OutputTest(Stock.GetStock());*///output test for the parsing
             var repo = new Repository();
             repo.BuyItemFromStock(1);
             repo.BuyItemFromStock(2);
             repo.BuyItemFromStock(3);
             var item1 = new Item { Name = "ionescu antonio", Price = 1 };
             var item2 = new Item { Name = "paul paulica", Price = 2 };
             var item3 = new Item { Name = "ionescu alexandra", Price = 3};
             repo.SellItem(item1);
             repo.SellItem(item2);
             repo.SellItem(item3);
             Parse.SerializeItemsToCode( "C:\\Users\\cgame\\source\\repos\\NewRepo2\\CSV XML Parser\\new.csv",Stock.GetStock());
               Parse.OutputTest(Stock.GetStock());//output test for the repo
            #endregion
            #region XmlParser and Repo
           /* var xmlParse = new XmlParser();
            string path = @"C:\Users\cgame\source\repos\NewRepo2\CSV XML Parser\example.xml";
            var str = xmlParse.ReadFileToString(path);
            Stock.SetStock(xmlParse.DeserializeCodeToItemList(str));
            var repo = new Repository();
            repo.BuyItemFromStock(3);
            repo.BuyItemFromStock(4);
            var item1 = new Item { Name = "ionescu antonio", Price = 1 };
            var item2 = new Item { Name = "paul paulica", Price = 2 };
            var item3 = new Item { Name = "ionescu alexandra", Price = 3 };
            repo.SellItem(item1);
            repo.SellItem(item2);
            repo.SellItem(item3);
            xmlParse.SerializeItemsToCode("C:\\Users\\cgame\\source\\repos\\NewRepo2\\CSV XML Parser\\new.xml", Stock.GetStock());*/
            #endregion
            #region ShoppingCart
            /* var cart = new ShoppingCart();
             cart.AddToCart(5);
             cart.AddToCart(6);
             cart.ShowCart();
             Console.WriteLine("pauza");
                cart.EmptyCart();
             cart.AddToCart(7);
             cart.ShowCart();*/
            #endregion



        }
    }
}