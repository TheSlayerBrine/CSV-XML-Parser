using CsvXmlParser;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{


    public class CSVParserTests
    {
        [Theory]
        [InlineData("id,name,price\n1,Item 1,10.5\n2,Item 2,20.0\n3,Item 3,15.75")]
        [InlineData("id,name,price\n4,Item 4,30.0\n5,Item 5,25.5")]
        public void TestValidCsvParsing(string csv)
        {
            //Arrange
            var parser = new CSVParser();

            //Act
            parser.ParseCsvToItemsList(csv);

            //Assert
            Assert.NotNull(parser.items);
            Assert.Equal(csv.Trim().Split('\n').Length - 1, parser.items.Count);//Assert count based on the number of rows in the CSV

        }

        [Theory]
        [InlineData("id,name,price\n1,Item 1,10.5\n2,Item 2\n3,Item 3,15.75")] //Missing price for the second item
        [InlineData("id,name,price\n6,Item 6,abc\n7,Item 7,xyz\n8,Item 8,20.0")] //Invalid price format for the first item
        public void TestInvalidCsvParsing(string csv)
        {
            //Arrange
            var parser = new CSVParser();

            //Act
            parser.ParseCsvToItemsList(csv);

            //Assert
            Assert.NotNull(parser.items);
            Assert.Equal(csv.Trim().Split('\n').Length - 1, parser.items.Count); //Assert count based on the number of rows in the CSV
            Assert.NotEqual(1, parser.items[1].Id); //ID should not be 1 due to conversion error
            Assert.NotEqual("Item 1", parser.items[1].Name); //Name should not be "Item 1" due to the missing price
            Assert.Equal(-1, parser.items[1].Price); //Price should be set to -1 due to conversion error 

        }

        [Fact]
        public void TestGetCsvLines()
        {
            //Arrange
            var parser = new CSVParser();
            string csv = "id,name,price\n1,Item 1,10.5\n2,Item 2,20.0\n3,Item 3,15.75";

            //Act
            string[] csvLines = parser.SplitCsvStringToLines(csv);

            //Assert
            Assert.NotNull(csvLines);
            Assert.Equal(4, csvLines.Length);
            Assert.Equal("1,Item 1,10.5", csvLines[1]);
            Assert.Equal("2,Item 2,20.0", csvLines[2]);
            Assert.Equal("3,Item 3,15.75", csvLines[3]);
        }

        [Fact]
        public void TestReadCsvFileToString()
        {
            //Arrange
            var parser = new CSVParser();
            string path = @"C:\\Users\\cgame\\source\\repos\\NewRepo2\\Tests\\test.csv"; //Provide a valid file path )

            //Act
            string csv = parser.ReadCsvFileToString(path);

            //Assert
            Assert.NotNull(csv);

        }

    }
}
    
