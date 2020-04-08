using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Resume
{
    public partial class Program
    {
        public static Command CreateValidateCommand()
        {
            var command = new Command("validate", "Validate a json resume file.")
            {
                new Option(
                    new string[] { "-l", "--location" },
                    "Path to a resume.json file"
                )
                {
                    Argument = new Argument<FileInfo>
                    {
                        Name = "filepath",
                        Arity = ArgumentArity.ExactlyOne,
                    },
                    Required = true,
                },
            };

            command.Handler = CommandHandler.Create<FileInfo>(async (location) =>
            {
                (bool isValid, IList<string> messages) = await ValidateSchema(location);

                Console.WriteLine("Your json resume is {0}", isValid ? "valid" : "invalid:");

                Console.WriteLine("---");

                foreach (var message in messages)
                {
                    Console.WriteLine($"- {message}");
                }

                Console.WriteLine("Done!");
            });

            return command;
        }

        private const string SCHEMA_URL = "https://raw.githubusercontent.com/jsonresume/resume-schema/v1.0.0/schema.json";

        public static Task<(bool IsValid, IList<string> Messages)> ValidateSchema(FileInfo schema) =>
            ValidateSchema(schema, SCHEMA_URL);

        public static async Task<(bool IsValid, IList<string> Messages)> ValidateSchema(FileInfo schemaFileInfo, string schemaUrl)
        {
            var response = await new HttpClient().GetAsync(schemaUrl);
            var resumeSchema = await response.Content.ReadAsStringAsync();

            using var stream = schemaFileInfo.OpenRead();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            var resume = await reader.ReadToEndAsync();

            var schema = JSchema.Parse(resumeSchema);
            var resumeObject = JObject.Parse(resume);

            bool isValid = resumeObject.IsValid(schema, out IList<string> messages);
            return (isValid, messages);
        }
    }
}
