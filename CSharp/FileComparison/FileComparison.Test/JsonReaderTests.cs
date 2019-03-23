using NUnit.Framework;
using System;
using FileComparison;
using System.Json;
using System.Collections.Generic;

namespace FileComparison.Test
{
    [TestFixture()]
    public class JsonReaderTests
    {
        private const string TEST_FILE = "../../Helpers/dummy.txt";

        private JsonReader _reader;

        [SetUp()]
        public void SetUp() {
            _reader = new JsonReader();
        }

        [Test()]
        public void LoadFile_WhenItReceivesAFilePath_ItReturnsTheFileContents()
        {
            // Arrange
            var expectedResult = new JsonObject(new KeyValuePair<string, JsonValue>("Foo", "Bar"));

            // Act
            var result = _reader.LoadFile(TEST_FILE);

            // Assert
            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test()]
        public void GetArray_WhenItReceivesValidJson_ItReturnsAJsonArray()
        {
            // Arrange
            var jsonObj = JsonValue.Parse("{ \"Foo\": [ \"Bar\", \"Baz\" ] }") as JsonObject;

            // Act
            var result = _reader.GetArray(jsonObj["Foo"].ToString());
            Console.WriteLine(result.ToString());

            // Assert
            Assert.That(result, Is.InstanceOf(typeof(JsonArray)));
            Assert.That(result.ToString().Contains("Bar"));
        }
    } 
}