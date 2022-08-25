using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SeaAPI.Utils
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
