// DO NOT MODIFY
// This Code is generated with https://app.quicktype.io?share=XT0YmmDbBkUbDmYsFUtD

namespace Resume.Schema
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class JsonResumeV1
    {
        /// <summary>
        /// Specify any awards you have received throughout your professional career
        /// </summary>
        [JsonProperty("awards", NullValueHandling = NullValueHandling.Ignore)]
        public Award[] Awards { get; set; }

        [JsonProperty("basics", NullValueHandling = NullValueHandling.Ignore)]
        public Basics Basics { get; set; }

        [JsonProperty("education", NullValueHandling = NullValueHandling.Ignore)]
        public Education[] Education { get; set; }

        [JsonProperty("interests", NullValueHandling = NullValueHandling.Ignore)]
        public Interest[] Interests { get; set; }

        /// <summary>
        /// List any other languages you speak
        /// </summary>
        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public Language[] Languages { get; set; }

        /// <summary>
        /// The schema version and any other tooling configuration lives here
        /// </summary>
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; }

        /// <summary>
        /// Specify career projects
        /// </summary>
        [JsonProperty("projects", NullValueHandling = NullValueHandling.Ignore)]
        public Project[] Projects { get; set; }

        /// <summary>
        /// Specify your publications through your career
        /// </summary>
        [JsonProperty("publications", NullValueHandling = NullValueHandling.Ignore)]
        public Publication[] Publications { get; set; }

        /// <summary>
        /// List references you have received
        /// </summary>
        [JsonProperty("references", NullValueHandling = NullValueHandling.Ignore)]
        public Reference[] References { get; set; }

        /// <summary>
        /// List out your professional skill-set
        /// </summary>
        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public Skill[] Skills { get; set; }

        [JsonProperty("volunteer", NullValueHandling = NullValueHandling.Ignore)]
        public Volunteer[] Volunteer { get; set; }

        [JsonProperty("work", NullValueHandling = NullValueHandling.Ignore)]
        public Work[] Work { get; set; }
    }

    public partial class Award
    {
        /// <summary>
        /// e.g. Time Magazine
        /// </summary>
        [JsonProperty("awarder", NullValueHandling = NullValueHandling.Ignore)]
        public string Awarder { get; set; }

        /// <summary>
        /// e.g. 1989-06-12
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// e.g. Received for my work with Quantum Physics
        /// </summary>
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        /// <summary>
        /// e.g. One of the 100 greatest minds of the century
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }

    public partial class Basics
    {
        /// <summary>
        /// e.g. thomas@gmail.com
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// URL (as per RFC 3986) to a image in JPEG or PNG format
        /// </summary>
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        /// <summary>
        /// e.g. Web Developer
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Location Location { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Phone numbers are stored as strings so use any format you like, e.g. 712-117-2923
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Specify any number of social networks that you participate in
        /// </summary>
        [JsonProperty("profiles", NullValueHandling = NullValueHandling.Ignore)]
        public Profile[] Profiles { get; set; }

        /// <summary>
        /// Write a short 2-3 sentence biography about yourself
        /// </summary>
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        /// <summary>
        /// URL (as per RFC 3986) to your website, e.g. personal homepage
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }

    public partial class Location
    {
        /// <summary>
        /// To add multiple address lines, use
        /// . For example, 1234 Glücklichkeit Straße
        /// Hinterhaus 5. Etage li.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// code as per ISO-3166-1 ALPHA-2, e.g. US, AU, IN
        /// </summary>
        [JsonProperty("countryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }

        [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        /// <summary>
        /// The general region where you live. Can be a US state, or a province, for instance.
        /// </summary>
        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }
    }

    public partial class Profile
    {
        /// <summary>
        /// e.g. Facebook or Twitter
        /// </summary>
        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public string Network { get; set; }

        /// <summary>
        /// e.g. http://twitter.example.com/neutralthoughts
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// e.g. neutralthoughts
        /// </summary>
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }
    }

    public partial class Education
    {
        /// <summary>
        /// e.g. Arts
        /// </summary>
        [JsonProperty("area", NullValueHandling = NullValueHandling.Ignore)]
        public string Area { get; set; }

        /// <summary>
        /// List notable courses/subjects
        /// </summary>
        [JsonProperty("courses", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Courses { get; set; }

        /// <summary>
        /// e.g. 2012-06-29
        /// </summary>
        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// grade point average, e.g. 3.67/4.0
        /// </summary>
        [JsonProperty("gpa", NullValueHandling = NullValueHandling.Ignore)]
        public string Gpa { get; set; }

        /// <summary>
        /// e.g. Massachusetts Institute of Technology
        /// </summary>
        [JsonProperty("institution", NullValueHandling = NullValueHandling.Ignore)]
        public string Institution { get; set; }

        /// <summary>
        /// e.g. 2014-06-29
        /// </summary>
        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// e.g. Bachelor
        /// </summary>
        [JsonProperty("studyType", NullValueHandling = NullValueHandling.Ignore)]
        public string StudyType { get; set; }
    }

    public partial class Interest
    {
        [JsonProperty("keywords", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keywords { get; set; }

        /// <summary>
        /// e.g. Philosophy
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class Language
    {
        /// <summary>
        /// e.g. Fluent, Beginner
        /// </summary>
        [JsonProperty("fluency", NullValueHandling = NullValueHandling.Ignore)]
        public string Fluency { get; set; }

        /// <summary>
        /// e.g. English, Spanish
        /// </summary>
        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageLanguage { get; set; }
    }

    /// <summary>
    /// The schema version and any other tooling configuration lives here
    /// </summary>
    public partial class Meta
    {
        /// <summary>
        /// URL (as per RFC 3986) to latest version of this document
        /// </summary>
        [JsonProperty("canonical", NullValueHandling = NullValueHandling.Ignore)]
        public string Canonical { get; set; }

        /// <summary>
        /// Using ISO 8601 with YYYY-MM-DDThh:mm:ss
        /// </summary>
        [JsonProperty("lastModified", NullValueHandling = NullValueHandling.Ignore)]
        public string LastModified { get; set; }

        /// <summary>
        /// A version field which follows semver - e.g. v1.0.0
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }
    }

    public partial class Project
    {
        /// <summary>
        /// Short summary of project. e.g. Collated works of 2017.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// e.g. 2012-06-29
        /// </summary>
        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Specify the relevant company/entity affiliations e.g. 'greenpeace', 'corporationXYZ'
        /// </summary>
        [JsonProperty("entity", NullValueHandling = NullValueHandling.Ignore)]
        public string Entity { get; set; }

        /// <summary>
        /// Specify multiple features
        /// </summary>
        [JsonProperty("highlights", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Highlights { get; set; }

        /// <summary>
        /// Specify special elements involved
        /// </summary>
        [JsonProperty("keywords", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keywords { get; set; }

        /// <summary>
        /// e.g. The World Wide Web
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Specify your role on this project or in company
        /// </summary>
        [JsonProperty("roles", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Roles { get; set; }

        /// <summary>
        /// resume.json uses the ISO 8601 date standard e.g. 2014-06-29
        /// </summary>
        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// e.g. 'volunteering', 'presentation', 'talk', 'application', 'conference'
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// e.g. http://www.computer.org/csdl/mags/co/1996/10/rx069-abs.html
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }

    public partial class Publication
    {
        /// <summary>
        /// e.g. The World Wide Web
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// e.g. IEEE, Computer Magazine
        /// </summary>
        [JsonProperty("publisher", NullValueHandling = NullValueHandling.Ignore)]
        public string Publisher { get; set; }

        /// <summary>
        /// e.g. 1990-08-01
        /// </summary>
        [JsonProperty("releaseDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Short summary of publication. e.g. Discussion of the World Wide Web, HTTP, HTML.
        /// </summary>
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        /// <summary>
        /// e.g. http://www.computer.org.example.com/csdl/mags/co/1996/10/rx069-abs.html
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

    public partial class Reference
    {
        /// <summary>
        /// e.g. Timothy Cook
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// e.g. Joe blogs was a great employee, who turned up to work at least once a week. He
        /// exceeded my expectations when it came to doing nothing.
        /// </summary>
        [JsonProperty("reference", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceReference { get; set; }
    }

    public partial class Skill
    {
        /// <summary>
        /// List some keywords pertaining to this skill
        /// </summary>
        [JsonProperty("keywords", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keywords { get; set; }

        /// <summary>
        /// e.g. Master
        /// </summary>
        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public string Level { get; set; }

        /// <summary>
        /// e.g. Web Development
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class Volunteer
    {
        /// <summary>
        /// e.g. 2012-06-29
        /// </summary>
        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Specify accomplishments and achievements
        /// </summary>
        [JsonProperty("highlights", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Highlights { get; set; }

        /// <summary>
        /// e.g. Facebook
        /// </summary>
        [JsonProperty("organization", NullValueHandling = NullValueHandling.Ignore)]
        public string Organization { get; set; }

        /// <summary>
        /// e.g. Software Engineer
        /// </summary>
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public string Position { get; set; }

        /// <summary>
        /// resume.json uses the ISO 8601 date standard e.g. 2014-06-29
        /// </summary>
        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Give an overview of your responsibilities at the company
        /// </summary>
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        /// <summary>
        /// e.g. http://facebook.example.com
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }

    public partial class Work
    {
        /// <summary>
        /// e.g. Social Media Company
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// e.g. 2012-06-29
        /// </summary>
        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Specify multiple accomplishments
        /// </summary>
        [JsonProperty("highlights", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Highlights { get; set; }

        /// <summary>
        /// e.g. Menlo Park, CA
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// e.g. Facebook
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// e.g. Software Engineer
        /// </summary>
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public string Position { get; set; }

        /// <summary>
        /// resume.json uses the ISO 8601 date standard e.g. 2014-06-29
        /// </summary>
        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Give an overview of your responsibilities at the company
        /// </summary>
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        /// <summary>
        /// e.g. http://facebook.example.com
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }
}
