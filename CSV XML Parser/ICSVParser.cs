using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvXmlParser
{
    public interface ICSVParser
    {
        public string ReadCsvFileToString(string path);
        public string[] SplitCsvStringToLines(string csv);
        public void ParseCsvToItemsList(string csv);

    }
}
