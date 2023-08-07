using CsvXmlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class XmlParserTest
    {
        [Theory]
        [InlineData(@"C:\Users\cgame\source\repos\NewRepo2\CSV XML Parser\example.xml")]
        public void Get_ItemsList_From_FilePath(string xmlFilePath)
        {
            // Arrange
            var parser = new XmlParser();
            string xmlString = parser.ReadFileToString(xmlFilePath);

            // Act
            List<Item> itemList = parser.DeserializeCodeToItemList(xmlString);

            // Assert
            Assert.NotNull(itemList);
            Assert.Equal(4, itemList.Count);
        }

        [Theory]
        [InlineData(@"C:\Users\cgame\source\repos\NewRepo2\Tests\testxml.xml")]
        public void Add_ItemsList_ToFile(string xmlFilePath)
        {
            // Arrange
            var parser = new XmlParser();
            var itemList = new List<Item>
            {
                new Item { Id = 1, Name = "abc", Price = 98.0 },
                new Item { Id = 2, Name = "def", Price = 97.0 },
                new Item { Id = 3, Name = "ghi", Price = 96.0 },
                new Item { Id = 4, Name = "jkl", Price = 95.0 }
            };

            // Act
            parser.SerializeItemsToCode(xmlFilePath, itemList);

            // Assert
            Assert.True(File.Exists(xmlFilePath));
        }
    }
}

