using MantisTester.Models;
using NUnit.Framework;
using MantisTester.Helpers;

namespace MantisTester.Tests
{
    public class SoapTestSuite : BaseTest
    {
        [Test]
        public void AddProject()
        {
            var project = ProjectModel.Generate();
            Manager.SoapController.AddNewProject(project)
                   .SoapController.GetProjects(out var projects);
            Assert.IsTrue(projects.Contains(project));
        }

        [Test]
        public void RemoveProject()
        {
            Manager.ManagmentController.GetProjectListFromDB(out var projects);
            var project = projects.Random();
            Manager.SoapController.RemoveProject(project)
                   .SoapController.GetProjects(out projects);
            Assert.IsFalse(projects.Contains(project));
        }
    }
}
