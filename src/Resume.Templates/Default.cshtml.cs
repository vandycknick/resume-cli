using System.Collections.Generic;
using System.Linq;
using Resume.Schema;

namespace Resume.Templates
{
    public class DefaultModel
    {
        public DefaultModel(JsonResumeV1 resume)
        {
            Name = resume.Basics.Name;
            JobTitle = resume.Basics.Label;
            Picture = resume.Basics.Image;
            AboutMe = resume.Basics.Summary.Split('\n').ToList();
            WorkPlaces = resume.Work.ToList();
            Schools = resume.Education.ToList();
            Languages = resume.Languages.ToList();

            ContactInfo.Add(new ContactRecord()
            {
                Type = "Website",
                Data = resume.Basics.Url?.ToString(),
            });

            ContactInfo.Add(new ContactRecord()
            {
                Type = "Email",
                Data = resume.Basics.Email,
            });

            foreach (var profile in resume.Basics.Profiles)
            {
                ContactInfo.Add(new ContactRecord()
                {
                    Type = profile.Network,
                    Data = profile.Url,
                });
            }
        }

        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Picture { get; set; }
        public List<string> AboutMe { get; set; }
        public List<Work> WorkPlaces { get; set; }
        public List<Education> Schools { get; set; }
        public List<Language> Languages { get; set; }

        public class ContactRecord
        {
            public string Type { get; set; }
            public string Data { get; set; }
        }
        public List<ContactRecord> ContactInfo { get; set; } = new List<ContactRecord>();
    }
}
