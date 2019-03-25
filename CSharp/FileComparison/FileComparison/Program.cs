using System;
using System.Collections;
using System.Json;
using System.Text;
using FileComparison.Interfaces;

namespace FileComparison
{
    public class Comparer
    {
        protected IJsonReader _reader;
        protected StringBuilder _builder = new StringBuilder();
        protected string _result = string.Empty;

        public Comparer(IJsonReader reader) {
            _reader = reader;
        }

        public Comparer() : this(new JsonReader()) { }

        public static void Main(string[] args)
        {
            var comparer = new Comparer();

            var FilePathOne = args[0];

            var FilePathTwo = args[1];

            Console.Write(comparer.BuildDifferenceOutput(
              comparer._reader.GetArray(comparer._reader.LoadFile(FilePathOne)["items"]),
              comparer._reader.GetArray(comparer._reader.LoadFile(FilePathTwo)["items"])
            ));
        }

        public string BuildDifferenceOutput(JsonArray arrayOne, JsonArray arrayTwo) {
            CompareJsonArrays(arrayOne, arrayTwo);
            
            _result = _builder.ToString();
            
            return _result;
        }
        
        public void CompareJsonArrays(JsonArray aryOne, JsonArray aryTwo) {
            var loopLength = GetLoopLength(aryOne.Count, aryTwo.Count);

            if (CompareItemLengths(aryOne.Count, aryTwo.Count) != string.Empty)
            {
                _builder.Append($"Array Lengths: {CompareItemLengths(aryOne.Count, aryTwo.Count)}");
            }

            for (var i = 0; i < loopLength; i++) {
                var objOne = aryOne[i] as JsonObject;
                var objTwo = aryTwo[i] as JsonObject;
                CompareJsonObjects(objOne, objTwo);
            }
        }

        public void CompareJsonObjects(JsonObject objOne, JsonObject objTwo) {
            var loopLength = GetLoopLength(objOne.Count, objTwo.Count);

            if (CompareItemLengths(objOne.Count, objTwo.Count) != string.Empty) {
                _builder.Append($"Object Lengths: {CompareItemLengths(objOne.Count, objTwo.Count)}");
            }

            var keyArray1 = new string[objOne.Count];
            objOne.Keys.CopyTo(keyArray1, 0);
            var keyArray2 = new string[objTwo.Count];
            objTwo.Keys.CopyTo(keyArray2, 0);

            _builder.Append($"Keys:\n{CompareItems(keyArray1, keyArray2, loopLength)}");

            var valueArray1 = new JsonValue[objOne.Count];
            objOne.Values.CopyTo(valueArray1, 0);
            var valueArray2 = new JsonValue[objTwo.Count];
            objTwo.Values.CopyTo(valueArray2, 0);

            _builder.Append($"Values:\n{CompareItems(ValueToString(valueArray1), ValueToString(valueArray2), loopLength)}");
        }

        public int GetLoopLength(int one, int two) {
            return one <= two ? one : two;
        }
        
        public string CompareItemLengths(int lengthOne, int lengthTwo) {
            if (lengthOne != lengthTwo) return $"{lengthOne}, {lengthTwo}\n";
            return "";
        }
        
        public string CompareItems(string[] listOne, string[] listTwo, int loopLength) {
            var builder = new StringBuilder();
            for (var i = 0; i < loopLength; i++) {
                builder.Append(CompareStrings(listOne[i], listTwo[i]));
            }
            return builder.ToString();
        }
        
        public string CompareStrings(string valueOne, string valueTwo) {
            if (valueOne != valueTwo) return $"{valueOne}, {valueTwo}\n";
            return "";
        }

        private string[] ValueToString(JsonValue[] array) {
            var stringArray = new string[array.Length];
            array.CopyTo(stringArray, 0);
            return stringArray;
        }
    }
}
