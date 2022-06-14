using Bogus;
using LinqToDB.Mapping;
using MantisTester.Helpers;
using System;
using JsonHelper;

namespace MantisTester.Models
{
    [Table(Name = "mantis_project_table")]
    public class ProjectModel : IEquatable<ProjectModel>
    {
        [Column(Name = "id")]
        public long Id { get; set; }
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "description")]
        public string Description { get; set; }
        [Column(Name = "view_state")]
        public long ViewState { get; set; }
        [Column(Name = "status")]
        public long Status { get; set; }
        [Column(Name = "inherit_global")]
        public bool InheritGlobalSettings { get; set; }
        [Column(Name = "enabled")]
        public bool Enabled { get; set; }
        [Column(Name = "category_id")]
        public long CategoryId { get; set; }
        [Column(Name = "file_path")]
        public string FilePath { get; set; }
        [Column(Name = "access_min")]
        public long AccessMin { get; set; }

        public ProjectModel() { }

        public static ProjectModel Generate()
        {
            var faker = new Faker("ru");
            return new ProjectModel() {
                Name = faker.Random.Words(3).Replace(" ", "_"),
                Description = faker.Random.Words(30),
                InheritGlobalSettings = true,
                Status = Titles.ProjectConditionsTitles.Random().Id,
                ViewState = Titles.ProjectVisibilityTitles.Random().Id,
                Enabled = true
            };
        }

        public override string ToString()
        {
            return this.ToJson();
        }

        public bool Equals(ProjectModel other)
        {
            return other.Name == this.Name &&
                   other.Description == this.Description &&
                   other.ViewState == this.ViewState &&
                   other.Status == this.Status &&
                   other.Enabled == this.Enabled;
        }
    }
}
