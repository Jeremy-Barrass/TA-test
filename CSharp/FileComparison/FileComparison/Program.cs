using System.Collections;
using System.Json;
using System.Text;
using FileComparison.Interfaces;

namespace FileComparison
{
    public class Comparer
    {
        protected IJsonReader _reader;

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

        public string BuildDifferenceOutput(JsonObject objOne, JsonObject objTwo) {
            StringBuilder builder = new StringBuilder();
            string result = string.Empty;

            var loopLength = objOne.Count < objTwo.Count ? objOne.Count : objTwo.Count;
            var valuesOne = new JsonValue[objOne.Count];
            var valuesTwo = new JsonValue[objTwo.Count];
            objOne.Values.CopyTo(valuesOne, 0);
            objTwo.Values.CopyTo(valuesTwo, 0);

            for (var i = 0; i < loopLength; i++) {
                if (valuesOne[i].ToString() != valuesTwo[i].ToString()) {
                  builder.Append($"#{valuesOne[i]}, #{valuesTwo[i]} \n");
                 }
            }
            result = builder.ToString();

            return result;
        }

        private string CompareKeys(string[] listOne, string[] listTwo) {

        }

        private string CompareValues(string[] listOne, string[] listTwo) {

        }
    }
}
