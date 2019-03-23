using NUnit.Framework;
using System;
using FileComparison;
using System.Json;
using System.Collections.Generic;
using FileComparison.Interfaces;

namespace FileComparison.Test
{
    [TestFixture()]
    public class JsonReaderTests
    {
        private const string TEST_FILE = "../../Helpers/dummy.txt";

        private IJsonReader _reader;
        private JsonObject _expectedResult;

        [SetUp()]
        public void SetUp() {
            _expectedResult = new JsonObject(new KeyValuePair<string, JsonValue>("Foo", "Bar"));
            _reader = new JsonReader();
        }

        [Test()]
        public void LoadFile_WhenItReceivesAFilePath_ItReturnsTheFileContents()
        {
            // Act
            var result = _reader.LoadFile(TEST_FILE);

            // Assert
            Assert.That(result.ToString(), Is.EqualTo(_expectedResult.ToString()));
        }

        [Test()]
        public void GetArray_WhenItReceivesValidJson_ItReturnsAJsonArray()
        {
            // Arrange
            var jsonObj = JsonValue.Parse("{ \"Foo\": [ \"Bar\", \"Baz\" ] }") as JsonObject;

            // Act
            var result = _reader.GetArray(jsonObj["Foo"].ToString());

            // Assert
            Assert.That(result, Is.InstanceOf(typeof(JsonArray)));
            Assert.That(result.ToString().Contains("Bar"));
        }

        [Test()]
        public void GetJObject_WhenItReceivesValidJson_ItReturnsAJsonObject() {
            // Arrange
            var jsonString = "{\"Foo\": \"Bar\"}";

            // Act
            var result = _reader.GetJObject(jsonString);

            // Assert
            Assert.That(result.ToString(), Is.EqualTo(_expectedResult.ToString()));
        }
    } 
}