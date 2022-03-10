using Microsoft.AspNetCore.Mvc;

namespace QTProjectTeam.AspMvc.Controllers
{
    public class MembersController : GenericController<Logic.Entities.Member, Models.Member>
    {
        private Logic.Entities.Project[]? projects = null;
        private Logic.Controllers.ProjectsController? projectsController = null;

        protected Logic.Entities.Project[] Projects
        {
            get
            {
                if (projects == null)
                {
                    Task.Run(async () => projects = await ProjectsController.GetAllAsync()).Wait();
                }
                return projects ??= Array.Empty<Logic.Entities.Project>();
            }
        }

        private Logic.Controllers.ProjectsController ProjectsController
        {
            get => projectsController ??= new Logic.Controllers.ProjectsController(Controller);
        }
        public MembersController(Logic.Controllers.MembersController controller) : base(controller)
        {
        }

        protected override Models.Member ToModel(Logic.Entities.Member entity)
        {
            var result = base.ToModel(entity);
            var project = Projects.FirstOrDefault(p => p.Id == result.ProjectId);

            result.Projects = Projects;

            if (project != null)
                result.ProjectName = project.Name;

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            ProjectsController?.Dispose();
            base.Dispose(disposing);
        }
    }
}
