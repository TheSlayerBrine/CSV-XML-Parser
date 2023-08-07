using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public abstract class Parser : IParser
    {
        public string ReadFileToString(string path)
        {
            var RawCSV = System.IO.File.ReadAllText(path);
            return RawCSV;
        }
        public abstract void SerializeItemsToCode(string filePath, List<Item> items);
        public abstract List<Item> DeserializeCodeToItemList(string codeString);
        public void OutputTest(List<Item> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                Console.Write(itemList[i].Id);
                Console.Write(",");
                Console.Write(itemList[i].Name);
                Console.Write(",");
                Console.Write(itemList[i].Price);
                Console.WriteLine();
            }

        }
    }
}
