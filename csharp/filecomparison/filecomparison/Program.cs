using System;
using System.Collections;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using FileComparison.Interfaces;

namespace FileComparison
{
    public class Comparer
    {
        protected IJsonReader _jsonReader;
        protected IFileReader _fileReader;
        protected StringBuilder _builder = new StringBuilder();
        protected string _result = string.Empty;

        public Comparer(IJsonReader jsonReader, IFileReader fileReader)
        {
            _jsonReader = jsonReader;
            _fileReader = fileReader;
        }

        public Comparer() : this(new JsonReader(), new FileReader()) { }

        public static void Main(string[] args)
        {
            var comparer = new Comparer();

            var FilePathOne = args[0];

            var FilePathTwo = args[1];

            Console.Write(comparer.BuildDifferenceOutput(
              comparer._jsonReader.GetArray(comparer._jsonReader.LoadFile(FilePathOne)["items"].ToString()),
              comparer._jsonReader.GetArray(comparer._jsonReader.LoadFile(FilePathTwo)["items"].ToString())
            ));


        }

        public string BuildDifferenceOutput(JsonArray arrayOne, JsonArray arrayTwo)
        {
            CompareJsonArrays(arrayOne, arrayTwo);

            _result = _builder.ToString();

            return _result;
        }

        public void CompareJsonArrays(JsonArray aryOne, JsonArray aryTwo)
        {
            var loopLength = GetLoopLength(aryOne.Count, aryTwo.Count);

            if (CompareItemLengths(aryOne.Count, aryTwo.Count) != string.Empty)
            {
                _builder.Append($"Array Lengths: {CompareItemLengths(aryOne.Count, aryTwo.Count)}");
            }

            for (var i = 0; i < loopLength; i++)
            {
                var objOne = aryOne[i] as JsonObject;
                var objTwo = aryTwo[i] as JsonObject;
                CompareJsonObjects(objOne, objTwo);
            }

            var valueArray1 = new JsonValue[aryOne.Count];
            aryOne.CopyTo(valueArray1, 0);
            var valueArray2 = new JsonValue[aryTwo.Count];
            aryTwo.CopyTo(valueArray2, 0);
            
            _builder.Append(GetRemainingItems(ValueToString(valueArray1), ValueToString(valueArray2)));
        }

        public void CompareJsonObjects(JsonObject objOne, JsonObject objTwo)
        {
            var loopLength = GetLoopLength(objOne.Count, objTwo.Count);

            if (CompareItemLengths(objOne.Count, objTwo.Count) != string.Empty)
            {
                _builder.Append($"Object Lengths: {CompareItemLengths(objOne.Count, objTwo.Count)}");
            }

            var keyArray1 = new string[objOne.Count];
            objOne.Keys.CopyTo(keyArray1, 0);
            var keyArray2 = new string[objTwo.Count];
            objTwo.Keys.CopyTo(keyArray2, 0);

            var keyComparison = CompareItems(keyArray1, keyArray2, loopLength);

            if (string.Empty != keyComparison)
            {
                _builder.Append($"Keys:\n{keyComparison}");
                _builder.Append(GetRemainingItems(keyArray1, keyArray2));
            }

            var valueArray1 = new JsonValue[objOne.Count];
            objOne.Values.CopyTo(valueArray1, 0);
            var valueArray2 = new JsonValue[objTwo.Count];
            objTwo.Values.CopyTo(valueArray2, 0);

            var valueComparison = CompareItems(ValueToString(valueArray1), ValueToString(valueArray2), loopLength);

            if (string.Empty != valueComparison)
            {
                _builder.Append($"Values:\n{valueComparison}");
                _builder.Append(GetRemainingItems(ValueToString(valueArray1), ValueToString(valueArray2)));
            }
        }

        public int GetLoopLength(int one, int two)
        {
            return one <= two ? one : two;
        }

        public string CompareItemLengths(int lengthOne, int lengthTwo)
        {
            if (lengthOne != lengthTwo) return $"{lengthOne}, {lengthTwo}\n";
            return "";
        }

        public string CompareItems(string[] listOne, string[] listTwo, int loopLength)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < loopLength; i++)
            {
                builder.Append(CompareStrings(listOne[i], listTwo[i]));
            }
            return builder.ToString();
        }

        public string GetRemainingItems(string[] list1, string[] list2)
        {
            if (list1.Length != list2.Length)
            {
                var builder = new StringBuilder();
                var longerList = list1.Length < list2.Length ? list2 : list1;
                var shorterList = list1.Length < list2.Length ? list1 : list2;
                var startIndex = shorterList.Length;
                for (var i = startIndex; i < longerList.Length; i++)
                {
                    if (shorterList == list1)
                    {
                        builder.Append($", {longerList[i]}\n");
                    }
                    else
                    {
                        builder.Append($"{longerList[i]},\n");
                    }
                }

                return builder.ToString();
            }
            return "";
        }

        public string CompareStrings(string valueOne, string valueTwo)
        {
            if (valueOne != valueTwo) return $"{valueOne}, {valueTwo}\n";
            return "";
        }

        private string[] ValueToString(JsonValue[] array)
        {
            var stringArray = new List<string>();
            foreach (var item in array)
            {
                stringArray.Add(item.ToString());
            }
            return stringArray.ToArray();
        }
    }
}
