using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CsvXmlParser
{
   public class XmlParser : Parser
    {
      
        public override List<Item> DeserializeCodeToItemList(string xml)
        {
            List<Item> items = new List<Item>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Item>), new XmlRootAttribute("ItemList"));
            using (StringReader reader = new StringReader(xml))
            {
                if (serializer.Deserialize(reader) is List<Item> itemList)
                {
                    items = itemList;
                }
            }

            return items;
        }
        public override void SerializeItemsToCode(string filePath, List<Item> items)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Item>), new XmlRootAttribute("ItemList"));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, items);
            }
        }
    }
}