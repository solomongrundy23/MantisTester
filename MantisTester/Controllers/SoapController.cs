using MantisTester.Helpers;
using MantisTester.Models;

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
            MantisSoap.MantisConnectPortTypeClient portTypeClient = new MantisSoap.MantisConnectPortTypeClient();
            MantisSoap.ProjectData projectData = new MantisSoap.ProjectData()
            {
                name = project.Name,
                description = project.Description,
                status = new MantisSoap.ObjectRef() { 
                    id = project.Status.ToString(), 
                    name = Titles.ProjectStatusTitles.ValueById(project.Status)
                },
                inherit_global = project.InheritGlobalSettings,
                view_state = new MantisSoap.ObjectRef() { 
                    id = project.ViewState.ToString(), 
                    name = Titles.ProjectVisibilityTitles.ValueById(project.ViewState) 
                }
            };
            portTypeClient.mc_project_add(auth.UserName, auth.Password, projectData);
            return Manager;
        }
    }
}
