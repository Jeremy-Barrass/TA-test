using System;
using System.Json;
using System.IO;
using System.Collections.Generic;
using FileComparison.Interfaces;

namespace FileComparison
{
    public class JsonReader : IJsonReader
    {
        public JsonObject LoadFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return JsonValue.Parse(sr.ReadToEnd()) as JsonObject;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("This is not JSON.");
                Console.WriteLine(e.Message);
                return new JsonObject(new KeyValuePair<string, JsonValue>("Not JSON", e.Message));
            }
        }

        public JsonArray GetArray(string json) {
            return JsonValue.Parse(json) as JsonArray;
        }

        public JsonObject GetJObject(string json) {
            return JsonValue.Parse(json) as JsonObject;
        }
    }
}
