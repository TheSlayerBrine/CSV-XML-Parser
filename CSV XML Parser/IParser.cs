using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public interface IParser
    {
        public string ReadFileToString(string path);
        public abstract  void SerializeItemsToCode(string filePath, List<Item> items);
        public abstract List<Item> DeserializeCodeToItemList(string codeString);
        public void OutputTest (List<Item> itemsList);
    }
}
