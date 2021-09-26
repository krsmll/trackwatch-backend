using System.Text.Json;

namespace TestProject.Helpers
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions =
            new JsonSerializerOptions(JsonSerializerDefaults.Web);
        
        public static TValue? DeserializeWithWebDefaults<TValue>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<TValue>(json, JsonSerializerOptions);
        }

        public static string? SerializeToString<TValue>(TValue json)
        {
            return JsonSerializer.Serialize(json, JsonSerializerOptions);
        }
    }
}