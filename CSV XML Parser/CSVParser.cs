using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public class CSVParser
    {
       public string RawCSV;
        public string[] csvLines;
        public List<Item> items;
    
 
        
        public void SetRawCSV (string path) {
        RawCSV= System.IO.File.ReadAllText (path);
        csvLines= System.IO.File.ReadAllLines(path);
        }
        public void SplitData()
        {
            var newList = new List<Item>();
            for(int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');
                int convId = Convert.ToInt32(rowData[0]);
                double convName = Convert.ToDouble(rowData[1]);
                var newItem = new Item
                {
                    Id = convId,
                    Price = rowData[1],
                    Name = convName,

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
                Console.Write(items[i].Price);
                Console.Write(items[i].Name);
                Console.WriteLine();
            }

        }
    }
}
