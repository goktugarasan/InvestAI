using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvestAI
{
    internal class JsonFavoritesService
    {
        private const string FileName = "favorites.json";
        private readonly string _filePath;

        public JsonFavoritesService()
        {
            // Store the file in the same directory as the application
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _filePath = Path.Combine(baseDirectory, FileName);

            // Create file if it doesn't exist
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<string> GetFavorites()
        {
            try
            {
                EnsureFileExists();
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        public void AddFavorite(string symbol)
        {
            var favorites = GetFavorites();
            
            if (!favorites.Contains(symbol))
            {
                favorites.Add(symbol);
                SaveFavorites(favorites);
            }
        }

        public void RemoveFavorite(string symbol)
        {
            var favorites = GetFavorites();
            
            if (favorites.Contains(symbol))
            {
                favorites.Remove(symbol);
                SaveFavorites(favorites);
            }
        }

        public bool IsFavorite(string symbol)
        {
            var favorites = GetFavorites();
            return favorites.Contains(symbol);
        }

        private void SaveFavorites(List<string> favorites)
        {
            try
            {
                string json = JsonSerializer.Serialize(favorites, new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving favorites: {ex.Message}");
            }
        }
    }
}
