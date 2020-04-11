using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace Resume.Schema
{
    public class Validator
    {
        private readonly HttpClient _client;

        public Validator() : this(new HttpClient())
        {
        }

        public Validator(HttpClient client)
        {
            _client = client;
        }

        public async Task<(bool IsValid, IList<string> Messages)> Validate(JsonResumeV1 resume)
        {
            var response = await _client.GetAsync(JsonResumeV1.SchemaUrl);
            var resumeSchema = await response.Content.ReadAsStringAsync();

            var schema = JSchema.Parse(resumeSchema);
            var resumeObject = JObject.FromObject(resume, JsonSerializer.Create(JsonResumeV1.Settings));

            bool isValid = resumeObject.IsValid(schema, out IList<string> messages);
            return (isValid, messages);
        }
    }
}
