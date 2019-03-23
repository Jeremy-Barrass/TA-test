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
            // Console.WriteLine("Hello World!");
            var comparer = new Comparer();

            var FilePathOne = args[0];

            var FilePathTwo = args[1];

        }

        public string CompareJsonArrays(JsonArray aryOne, JsonArray aryTwo) {
            return "";
        }

        public string CompareJsonObjects(JsonObject objOne, JsonObject objTwo) {
            return "";
        }

        public string CompareKeys(string[] listOne, string[] listTwo) {
            return "";
        }
        
        public string CompareValues(JsonValue[] listOne, JsonValue[] listTwo) {
            return BuildDifferenceOutput(ValueToString(listOne), ValueToString(listTwo));
        }
        
        public string ComapareItemLengths(int lengthOne, int lengthTwo) {
            if (lengthOne != lengthTwo) return $"{lengthOne}, {lengthTwo}";
            return "";
        }

        public string BuildDifferenceOutput(string[] objOne, string[] objTwo) {
            var loopLength = objOne.Length < objTwo.Length ? objOne.Length : objTwo.Length;
            for (var i = 0; i < loopLength; i++) {
                if (objOne[i] != objTwo[i]) {
                  _builder.Append($"{objOne[i]}, {objOne[i]} \n");
                 }
            }
            _result = _builder.ToString();

            return _result;
        }

        private string[] ValueToString(JsonValue[] array) {
            var stringArray = new string[array.Length];
            array.CopyTo(stringArray, 0);
            return stringArray;
        }
    }
}
