using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using FileComparison;
using System.Json;

namespace FileComparison.Test
{
    [TestFixture()]
    public class ComparerTests
    {
        private JsonObject _jsonObject1;
        private JsonObject _jsonObject2;

        private Comparer _comparer;

        [SetUp()]
        public void Setup() {
            _jsonObject1 = new JsonObject()
            {
                { "Foo", "apple" },
                { "Bar", "banana" },
                { "Baz", "pear" }
            };

            _jsonObject2 = new JsonObject() {
                { "Foo", "apple" },
                { "Bar", "banana" },
                { "Baz", "peach" }
            };

            _comparer = new Comparer();
        }

        [Test]
        [Ignore("Refactoring Method")]
        public void BuildDifferenceOutput_WhenItReceivesTwoStringArrays_ItBuildsAStringOfTheDifferences()
        {
            var result = "";
            // Act
            // var result = _comparer.BuildDifferenceOutput(_list1, _list2);

            // Assert
            Assert.That(result.Contains("pear"));
            Assert.That(result.Contains("peach"));

            Assert.That(!result.Contains("apple"));
            Assert.That(!result.Contains("banana"));
        }

        [Test]
        public void CompareItemLengths_WhenItReceivesTwoIntegers_ItReturnsThenWhenTheyDiffer() {
            // Arrange
            var expectedResult = "3, 5";

            // Act
            var result = _comparer.CompareItemLengths(3, 5);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CompareStrings_WhenItReceivesTwoStrings_ItReturnsThemWhenTheyDiffer() {
            // Arrange
            var expectedResult = "pear, peach";

            // Act
            var result = _comparer.CompareStrings("pear", "peach");
            var result2 = _comparer.CompareStrings("banana", "banana");

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result2, Is.Empty);
        }

        private string[] ValueToString(JsonValue[] array)
        {
            var stringArray = new string[array.Length];
            array.CopyTo(stringArray, 0);
            return stringArray;
        }

    }
}
