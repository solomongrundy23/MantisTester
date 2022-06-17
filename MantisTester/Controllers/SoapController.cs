using MantisTester.Helpers;
using MantisTester.Models;
using System.Collections.Generic;
using System.Linq;

namespace MantisTester.Controllers
{
    public class SoapController : BaseController
    {
        public SoapController(ControllersManager manager) : base(manager)
        {
        }

        public ControllersManager AddNewProject(ProjectModel project)
        {
            var auth = AuthModel.GetAdmin();
            var portTypeClient = new MantisSoapOutland.MantisConnectPortTypeClient();
            MantisSoapOutland.ProjectData projectData = new MantisSoapOutland.ProjectData()
            {
                name = project.Name,
                description = project.Description,
                status = new MantisSoapOutland.ObjectRef() { 
                    id = project.Status.ToString(), 
                    name = Titles.ProjectStatusTitles.ValueById(project.Status)
                },
                inherit_global = project.InheritGlobalSettings,
                view_state = new MantisSoapOutland.ObjectRef() { 
                    id = project.ViewState.ToString(), 
                    name = Titles.ProjectVisibilityTitles.ValueById(project.ViewState) 
                }
            };
            portTypeClient.mc_project_add(auth.UserName, auth.Password, projectData);
            return Manager;
        }

        public ControllersManager GetProjects(out List<ProjectModel> projects)
        {
            var auth = AuthModel.GetAdmin();
            var portTypeClient = new MantisSoapOutland.MantisConnectPortTypeClient();
            var projectDataArray = portTypeClient.mc_projects_get_user_accessible(auth.UserName, auth.Password);
            projects = new List<ProjectModel>();
            projects.AddRange(projectDataArray.Select(x => new ProjectModel { 
                Id = x.id.ParseLong(),
                Name = x.name,
                Description = x.description,
                Enabled = x.enabled,
                AccessMin = x.access_min.id.ParseLong(),
                //CategoryId = ?
                InheritGlobalSettings = x.inherit_global,
                Status = x.status.id.ParseLong(),
                FilePath = x.file_path,
                ViewState = long.Parse(x.view_state.id)
            }));
            return Manager;
        }

        public ControllersManager RemoveProject(ProjectModel project)
        {
            var auth = AuthModel.GetAdmin();
            var portTypeClient = new MantisSoapOutland.MantisConnectPortTypeClient();
            portTypeClient.mc_project_delete(auth.UserName, auth.Password, project.Id.ToString());
            return Manager;
        }
    }
}
