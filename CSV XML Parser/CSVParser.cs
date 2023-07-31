using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public class CSVParser : ICSVParser
    {      
        public List<Item> items;  
        
        public string ReadCsvFileToString (string path)
        {
            var RawCSV = System.IO.File.ReadAllText(path);
            return RawCSV;
        }
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
        public void ParseCsvToItemsList(string csv)
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
               
                var newItem = new Item
                {
                      Id = convId,
                    Price = convPrice,
                    Name = rowData[1],

                };
                newList.Add(newItem);
           
            }
            items = newList;          
        }
        public void OutputTest()
        {
            for(int i =0; i< items.Count;i++ )
            {
                Console.Write(items[i].Id );
                Console.Write (",");              
                Console.Write(items[i].Name);
                Console.Write(",");
                Console.Write(items[i].Price);
                Console.WriteLine();
            }

        }
    }
}
