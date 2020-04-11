using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Resume.Schema
{
    public partial class JsonResumeV1
    {
        public const string SchemaUrl = "https://raw.githubusercontent.com/jsonresume/resume-schema/v1.0.0/schema.json";

        internal static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter
                {
                    DateTimeStyles = DateTimeStyles.AdjustToUniversal,
                    DateTimeFormat = "yyyy-MM-dd",
                }
            },
        };

        public static JsonResumeV1 FromJson(StreamReader reader)
        {
            using var jsonReader = new JsonTextReader(reader);
            return new JsonSerializer().Deserialize<JsonResumeV1>(jsonReader);
        }

        public static JsonResumeV1 FromJson(string json) => JsonConvert.DeserializeObject<JsonResumeV1>(json, Settings);
        public string ToJson() => JsonConvert.SerializeObject(this, Settings);
    }
}
