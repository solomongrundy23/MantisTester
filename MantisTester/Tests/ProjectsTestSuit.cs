using MantisTester.Models;
using NUnit.Framework;
using System;
using System.Linq;
using MantisTester.Helpers;

namespace MantisTester.Tests
{
    public class ProjectsTestSuit : WithAuth
    {
        [Test]
        public void AddProject()
        {
            var project = ProjectModel.Generate();
            Manager.ManagmentController.Open()
                   .ManagmentController.ToProjectManagement()
                   .ManagmentController.AddNewProject(project)
                   .ManagmentController.GetProjectListFromDB(out var projects);
            Assert.IsTrue(projects.Contains(project));
        }

        [Test]
        public void ListProject()
        {
            Manager.ManagmentController.Open()
                   .ManagmentController.ToProjectManagement()
                   .ManagmentController.GetProjectListFromDB(out var dbProjects)
                   .ManagmentController.GetProjectListFromDB(out var uiProjects);
            Assert.AreEqual(
                dbProjects.OrderBy(x => x.Name).ThenBy(x => x.Description), 
                uiProjects.OrderBy(x => x.Name).ThenBy(x => x.Description)
                );
        }

        [Test]
        public void RemoveProject()
        {
            Manager.ManagmentController.GetProjectListFromDB(out var projects);
            var project = projects.Random();
            Manager.ManagmentController.Open();
            Manager.ManagmentController.ToProjectManagement();
            Manager.ManagmentController.OpenProject(project);
            Manager.ManagmentController.PressRemoveFromProject();
            Manager.ManagmentController.GetProjectListFromDB(out projects);
            Assert.IsFalse(projects.Contains(project));
        }
    }
}
