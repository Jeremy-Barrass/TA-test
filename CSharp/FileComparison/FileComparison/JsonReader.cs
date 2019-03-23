using System;
using System.Json;
using System.IO;
using System.Collections.Generic;

namespace FileComparison
{
    public class JsonReader
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
    }
}
