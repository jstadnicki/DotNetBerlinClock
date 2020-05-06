using System.ComponentModel;

namespace BerlinClock
{
    public static class LightColorExtensions
    {
        public static string GetDescription(this LightColor color)
        {
            var attributes = color.GetType().GetField(color.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes[0] as DescriptionAttribute).Description;
        }
    }
}
