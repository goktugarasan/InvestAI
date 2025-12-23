using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvestAI
{

    public class Notification
    {
        public string symbol { get; set; }
        public decimal targetPrice { get; set; }
        public bool isAbove { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Notification other)
            {
                return symbol == other.symbol && 
                       targetPrice == other.targetPrice && 
                       isAbove == other.isAbove;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(symbol, targetPrice, isAbove);
        }
    }
    internal class JsonNotifsService
    {
        private const string FileName = "notifications.json";
        private readonly string _filePath;

        public JsonNotifsService()
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

        public List<Notification> GetNotifications()
        {
            try
            {
                EnsureFileExists();
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Notification>>(json) ?? new List<Notification>();
            }
            catch
            {
                return new List<Notification>();
            }
        }

        public void AddNotif(Notification notif)
        {
            var notifications = GetNotifications();
            
            if (!notifications.Any(n => n.Equals(notif)))
            {
                notifications.Add(notif);
                SaveNotifications(notifications);
            }
        }

        public void RemoveNotif(Notification notif)
        {
            var notifications = GetNotifications();
            var toRemove = notifications.FirstOrDefault(n => n.Equals(notif));
            
            if (toRemove != null)
            {
                notifications.Remove(toRemove);
                SaveNotifications(notifications);
            }
        }

        public bool IsNotif(Notification notif)
        {
            var notifications = GetNotifications();
            return notifications.Any(n => n.Equals(notif));
        }

        private void SaveNotifications(List<Notification> notifications)
        {
            try
            {
                string json = JsonSerializer.Serialize(notifications, new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving notifications: {ex.Message}");
            }
        }
    }
}
