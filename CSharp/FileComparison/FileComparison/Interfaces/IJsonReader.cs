using System;
using System.Json;

namespace FileComparison.Interfaces
{
    public interface IJsonReader
    {
        JsonValue LoadFile(string path);
        JsonArray GetArray(string json);
        JsonObject GetJObject(string json);
    }
}
