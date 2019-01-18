using System.Collections.Generic;
using System.Linq;
using Resume.Models;

namespace Resume.Views
{
    public class DefaultModel
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Picture { get; set; }
        public List<string> AboutMe { get; set; }
        public List<Work> WorkPlaces { get; set; }
        public List<Education> Schools { get; set; }
        public List<Language> Languages { get; set; }
        public List<ContactRecord> ContactInfo { get; set; }

        public void OnRender(JsonResume resume)
        {
            Name = resume.Basics.Name;
            JobTitle = resume.Basics.Label;
            Picture = resume.Basics.Picture;
            AboutMe = resume.Basics.Summary.Split('\n').ToList();
            WorkPlaces = resume.Work;
            ContactInfo = new List<ContactRecord>();
            Schools = resume.Education;
            Languages = resume.Languages;

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
    }

    public class ContactRecord
    {
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
