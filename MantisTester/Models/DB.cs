using LinqToDB;

namespace MantisTester.Models
{
    public class DB : LinqToDB.Data.DataConnection
    {
        public DB() : base("Bugtracker") { }

        public ITable<ProjectModel> projectTable => this.GetTable<ProjectModel>();
    }
}