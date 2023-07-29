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
            for(int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');
                var newItem = new Item
                {
                    Id = rowData[1],
                    Price = rowData[2],
                    Name = rowData[3],

                };
                items.Add(newItem);
            }
        }
        public void OutputTest()
        {
            for(int i =1; i< items.Count;i++ )
            {
                Console.WriteLine(items[i] );
            }

        }
    }
}
