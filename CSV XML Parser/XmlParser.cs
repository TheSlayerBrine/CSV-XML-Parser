using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CsvXmlParser
{
   public class XmlParser
    {
        public void ParseXmlToItemList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("example.xml");
            var ListOfItems = new List<Item>();
            foreach(XmlNode node in doc.DocumentElement) 
            {
                string name = node["Name"].Value;
                int id = int.Parse(node["Id"].Value);
                double price = double.Parse(node["Price"].Value);
                ListOfItems.Add(new Item {Name =  name, Id =  id, Price = price });
            }
            Stock.SetStock(ListOfItems);
        }
        public void OutputXmlTest()
        {
            Stock.
        }
    }
}
