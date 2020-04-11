using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.IO;
using System.Text;
using Resume.Schema;

namespace Resume
{
    public partial class Program
    {
        public static Command CreateValidateCommand()
        {
            var command = new Command("validate", "Validate a json resume file.")
            {
                new Option(
                    new string[] { "-f", "--file" },
                    "Path to a resume.json file"
                )
                {
                    Argument = new Argument<FileInfo>(() => new FileInfo(RESUME_FILENAME))
                    {
                        Name = "filepath",
                        Arity = ArgumentArity.ZeroOrOne,
                    },
                    Required = false,
                },
            };

            command.Handler = CommandHandler.Create<FileInfo, IConsole>(async (file, console) =>
            {
                if (!file.Exists) throw new FileNotFoundException("Resume not found", file.FullName);

                using var stream = file.OpenRead();
                using var reader = new StreamReader(stream, Encoding.UTF8);
                var resumeJson = await reader.ReadToEndAsync();
                var resume = JsonResumeV1.FromJson(resumeJson);

                var validator = new Validator();
                (bool isValid, IList<string> messages) = await validator.Validate(resume);

                if (!isValid)
                {
                    console.Out.WriteLine("Errors: ");
                    foreach (var message in messages)
                    {
                        console.Out.WriteLine($"- {message}");
                    }
                    console.Out.WriteLine();
                    return 1;
                }
                else
                {
                    console.Out.WriteLine("Success!");
                    return 0;
                }
            });

            return command;
        }
    }
}
