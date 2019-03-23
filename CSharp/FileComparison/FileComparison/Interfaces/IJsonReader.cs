using System;
using System.Json;

namespace FileComparison.Interfaces
{
    public interface IJsonReader
    {
        JsonObject LoadFile(string path);
        JsonArray GetArray(string json);
        JsonObject GetJObject(string json);
    }
}
