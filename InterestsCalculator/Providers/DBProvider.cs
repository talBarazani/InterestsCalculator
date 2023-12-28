using InterestsCalculator.Models.DBModels;
using System.Text.Json;

namespace InterestsCalculator.Providers
{
    public class DBProvider : IDBProvider
    {
        private CustomDBContext? customDBContext;
        public async Task<CustomDBContext> GetDBContext()
        {
            if (customDBContext == null)
            {
                var s = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = s + "\\\\InterestsCalculatorDB.json";
                using FileStream openStream = File.OpenRead(filePath);
                customDBContext = await JsonSerializer.DeserializeAsync<CustomDBContext>(openStream);
                //using StreamReader reader = new(filePath);
                //var json = reader.ReadToEnd();
                //customDBContext = JsonSerializer.Deserialize<CustomDBContext>(json);
                return customDBContext ?? throw new ArgumentNullException("CustomDBContext");
            }
            else return customDBContext;
        }
    }
}
