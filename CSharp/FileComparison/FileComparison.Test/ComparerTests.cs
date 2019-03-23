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
        private JsonObject _list1;
        private JsonObject _list2;

        private Comparer _comparer;

        [SetUp()]
        public void Setup() {
            _list1 = new JsonObject()
            {
                { "Foo", "apple" },
                { "Bar", "banana" },
                { "Baz", "pear" }
            };

            _list2 = new JsonObject() {
                { "Foo", "apple" },
                { "Bar", "banana" },
                { "Baz", "peach" }
            };

            _comparer = new Comparer();
        }

        [Test()]
        public void BuildDifferenceOutput_WhenItReceivesTwoArrays_ItBuildsAStringOfTheDifferences()
        {
            // Act
            var result = _comparer.BuildDifferenceOutput(_list1, _list2);
            Console.WriteLine(result);

            // Assert
            Assert.That(result.Contains("pear"));
            Assert.That(result.Contains("peach"));

            Assert.That(!result.Contains("apple"));
            Assert.That(!result.Contains("banana"));
        }
    }
}
