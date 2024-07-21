using Newtonsoft.Json;

namespace Services.App.Code.Services.Extensions
{
    public static class DataExtensions
    {
        public static T ToDeserialized<T>(this string json) => JsonConvert.DeserializeObject<T>(json);

        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
    }
}