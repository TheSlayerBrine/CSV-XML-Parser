using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public class CSVParser : Parser
    {            
        public string[] SplitCsvStringToLines(string csv)
        {
            
            using (StringReader reader = new StringReader(csv))
            {
                List<string> linesList = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    linesList.Add(line);
                }
                var val = linesList.ToArray();
                return val;
            }
            
        }
        public override List<Item> DeserializeCodeToItemList(string csv)
        {
            var newList = new List<Item>();

            string[] csvLines = SplitCsvStringToLines(csv);

            for(int i = 1; i < csvLines.Length; i++)
            {              
                int convId;
                double convPrice;
                string[] rowData = csvLines[i].Split(',');
                try
                {
                     convId = 1 * Convert.ToInt32(rowData[0]);
                }
                catch (System.FormatException) 
                {
                     convId = -1;
                }
                try
                {
                    convPrice = 1 * Convert.ToDouble(rowData[2]);
                }
                catch (System.Exception )
                {
                    convPrice = -1;
                }
                if(convId >0 && convPrice >=0)
                {
                    var newItem = new Item
                    {
                        Id = convId,
                        Price = convPrice,
                        Name = rowData[1],

                    };
                    newList.Add(newItem);
                }
            }
            return newList;          
        }

        public override void SerializeItemsToCode(string filePath, List<Item> items)
        {
            if(items == null || items.Count == 0)
            {
                throw new ArgumentException("The list of items is empty.");
            }
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("Id,Name,Price"); //header
            foreach(var item in items)
            {
                csvContent.AppendLine($"{item.Id},{item.Name},{item.Price}");
            }
            File.WriteAllText(filePath, csvContent.ToString());
        }
    }
}
