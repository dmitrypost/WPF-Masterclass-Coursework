using System;
using System.Linq;
using Weather.Enums;
using Weather.Interfaces;

namespace Weather.Data.Repository
{
    public class SettingRepository : ISettingRepository
    {
        public string GetValue(SettingKey key)
        {
            try
            {
                var keyString = key.ToString();
                using (var context = new AppDbContext())
                    return context.Settings.SingleOrDefault(x => x.Key == keyString)?.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
