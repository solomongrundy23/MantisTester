using MantisTester.Helpers;
using MantisTester.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MantisTester.Controllers
{
    public class ManagmentController : BaseController
    {
        public ManagmentController(ControllersManager manager) : base(manager)
        {
        }

        public ControllersManager GetProjectListFromUI(out List<ProjectModel> projects)
        {
            projects = new List<ProjectModel>();
            var rows = GetProjectTableRows();
            foreach (var row in rows)
            {
                projects.Add(GetProjectModelFromRow(row));
            }
            return Manager;
        }

        public ControllersManager OpenProject(ProjectModel project)
        {
            var rows = GetProjectTableRows();
            foreach (var row in rows)
            {
                var projectModel = GetProjectModelFromRow(row);
                if (projectModel.Equals(project))
                {
                    row.FindElement(By.CssSelector("td:nth-child(1) > a")).Click();
                    break;
                }
            }
            return Manager;
        }

        public ControllersManager PressRemoveFromProject()
        {
            Driver.FindElement(By.CssSelector("#project-delete-form > fieldset > input.button")).Click();
            Driver.FindElement(By.CssSelector("#content > div > form > input.button")).Click();
            WaitProjectTable();
            return Manager;
        }

        private IReadOnlyCollection<IWebElement> GetProjectTableRows()
        {
            return Driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
        }

        private IWebElement[] GetProjectTableColumns(IWebElement tr)
        {
            WaitProjectTable();
            return tr.FindElements(By.TagName("td")).ToArray();
        }

        private ProjectModel GetProjectModelFromRow(IWebElement tr)
        {
            var columns = GetProjectTableColumns(tr);
            return new ProjectModel()
            {
                Name = columns[0].Text,
                Status = Titles.ProjectConditionsTitles.IdByValue(columns[1].Text),
                Enabled = columns[2].Text == "X",
                ViewState = Titles.ProjectVisibilityTableTitles.IdByValue(columns[3].Text),
                Description = columns[4].Text
            };
        }

        public ControllersManager GetProjectListFromDB(out List<ProjectModel> projects)
        {
            using (DB db = new DB())
            {
                var data = from g in db.projectTable select g;
                projects = data.ToList();
                return Manager;
            }
        }

        public ControllersManager Open()
        { 
            Driver.FindElement(By.ClassName("manage-menu-link")).Click();
            return Manager;
        }

        public ControllersManager ToProjectManagement()
        { 
            Driver.FindElements(By.TagName("li")).Where(x => x.Text == Titles.ManagementMenuTitles.project).First().Click();
            return Manager;
        }

        public ControllersManager AddNewProject(ProjectModel project)
        {
            Driver.FindElement(By.CssSelector("#content > div:nth-child(2) > form > fieldset > input.button-small")).Click();
            FillTextBox(By.CssSelector("#project-name"), project.Name);
            SelectElementInComboBox(By.CssSelector("#project-status"), Titles.ProjectConditionsTitles.ValueById(project.Status));
            if (project.InheritGlobalSettings) Driver.FindElement(By.CssSelector("#project-inherit-global")).Click();
            SelectElementInComboBox(By.CssSelector("#project-view-state"), Titles.ProjectVisibilityTitles.ValueById(project.ViewState));
            FillTextBox(By.CssSelector("#project-description"), project.Description);
            Driver.FindElement(By.CssSelector("#manage-project-create-form > fieldset > span > input")).Click();
            return Manager;
        }

        private void WaitProjectTable()
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            wait.Until(x => x.ExistsElement(By.TagName("tbody")));
        }
    }
}
