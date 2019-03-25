using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using FileComparison.Interfaces;

namespace FileComparison
{
    public class FileReader : IFileReader
    {
        public string LoadFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Read File.");
                Console.WriteLine(e.Message);
                return $"Couldn't Read File: {e.Message}.";
            }

        }
    }
}