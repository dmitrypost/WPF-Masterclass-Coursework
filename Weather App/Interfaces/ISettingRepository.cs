using Weather.Enums;

namespace Weather.Interfaces
{
    public interface ISettingRepository
    {
        string GetValue(SettingKey key);
    }
}