
namespace QTProjectTeam.WebApi.Controllers
{
    public class ProjectsController : GenericController<Logic.Entities.Project, Models.EditProject, Models.Project>
    {
        public ProjectsController(Logic.Controllers.ProjectsController controller) : base(controller)
        {
        }
    }
}
