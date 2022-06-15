using MantisTester.Models;
using NUnit.Framework;

namespace MantisTester.Tests
{
    public class SoapTestSuite : BaseTest
    {
        [Test]
        public void AddProject()
        {
            var project = ProjectModel.Generate();
            Manager.SoapController.AddNewProject(project);
        }
    }
}
