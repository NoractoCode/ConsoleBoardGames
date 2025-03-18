using System;
using System.IO;
using System.Text.Json;

namespace BoardGames
{
    abstract public class SaveManager
    {
        // Save any object as JSON
        public static void Save<T>(T data, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // Ensure the filename has a .json extension
            if (!fileName.EndsWith(".json"))
            {
                fileName += ".json";
            }

            File.WriteAllText(fileName, jsonString);
            Console.WriteLine($"Saved to {fileName}");
        }

        // Load any object from a JSON file
        public static T Load<T>(string fileName)
        {
            if (!fileName.EndsWith(".json"))
            {
                fileName += ".json";
            }

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found. Returning default value.");
                return default; // Returns null for reference types and default values for value types
            }

            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }


}
