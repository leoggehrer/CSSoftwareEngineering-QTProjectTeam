using Microsoft.AspNetCore.Mvc;

namespace QTProjectTeam.AspMvc.Controllers
{
    public class ProjectsController : GenericController<Logic.Entities.Project, Models.Project>
    {
        public ProjectsController(Logic.Controllers.ProjectsController controller) : base(controller)
        {
        }
    }
}
