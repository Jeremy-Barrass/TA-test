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
        private JsonValue[] _valuesArray1;
        private JsonObject _jsonObject2;
        private JsonValue[] _valuesArray2;

        private Comparer _comparer;

        [SetUp()]
        public void Setup() {
            _jsonObject1 = new JsonObject()
            {
                { "Foo", "apple" },
                { "Bar", "banana" },
                { "Baz", "pear" }
            };
            _valuesArray1 = ValueToString(_jsonObject1.Values);

            _jsonObject2 = new JsonObject() {
                { "Foo", "apple" },
                { "Bar", "banana" },
                { "Baz", "peach" }
            };

            _comparer = new Comparer();
        }

        [Test()]
        public void BuildDifferenceOutput_WhenItReceivesTwoStringArrays_ItBuildsAStringOfTheDifferences()
        {
            // Act
            var result = _comparer.BuildDifferenceOutput(_list1, _list2);

            // Assert
            Assert.That(result.Contains("pear"));
            Assert.That(result.Contains("peach"));

            Assert.That(!result.Contains("apple"));
            Assert.That(!result.Contains("banana"));
        }

        [Test()]
        public void CompareItemLengths_WhenItReceivesTwoIntegers_ItReturnsThenWhenTheyDiffer() {
            // Arrange
            var expectedResult = "3, 5";

            // Act
            var result = _comparer.ComapareItemLengths(3, 5);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test()]
        public void CompareValues_WhenItReceivesTwoLists_ItReturnsThemWhenTheyDiffer() {
            // Arrange
            var expectedResult = "pear, peach";
            var valuesOne = new JsonValue[_jsonObject1.Values.Count];
            _jsonObject1.Values.CopyTo(valuesOne, 0);
            var valuesTwo = new JsonValue[_jsonObject2.Values.Count];
            _jsonObject2.Values.CopyTo(valuesTwo, 0);

            // Act
            var result = _comparer.CompareValues(valuesOne, valuesTwo);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private string[] ValueToString(JsonValue[] array)
        {
            var stringArray = new string[array.Length];
            array.CopyTo(stringArray, 0);
            return stringArray;
        }

    }
}
