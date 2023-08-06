using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Console = Colorful.Console;
namespace CsvXmlParser
{
    public class UI
    {
        public string MainMenu;

        public void  ShowMainMenu()
        {
            Console.WriteLine("Save");
;            Console.WriteLine("ShowCart");
            Console.WriteLine("Quit");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


        }
        public void RunningUI()
        {
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();
                switch (input)
                {/*
                    case "Save":
                    case "save":
                    //EmptyCart
                    case "Quit":
                    case "quit":
                    //Quit Console
                    case "Items":
                    case "items":
                    //Show Items in stock
                    case "EditPrice":
                    case "editprice":
                    //ConsoleWrite " write the id of item" and get another input
                    case "EditName":
                    case "editname":
                    //ConsoleWrite " write the id of item" and get another input
                    case "SellNewItem":
                    case "sellnewitem":
                    //SellItem method
                    case "BuyItem":
                    case "buyitem":
                    //ConsoleWrite " write the id of item" and get another input
                    case "Cart":
                    case "cart":
                    //Show items in cart
                    case ""
*/

                }
            }
        }
        

    }
}
