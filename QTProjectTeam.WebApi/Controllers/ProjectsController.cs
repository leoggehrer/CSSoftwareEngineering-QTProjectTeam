
using Microsoft.AspNetCore.Mvc;

namespace QTProjectTeam.WebApi.Controllers
{
    public class ProjectsController : GenericController<Logic.Entities.Project, Models.EditProject, Models.Project>
    {
        public ProjectsController(Logic.Controllers.ProjectsController controller) : base(controller)
        {
        }

        [HttpGet("Query", Name = nameof(Query))]
        [ProducesResponseType(typeof(Models.Project), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Models.Project>> Query(
            [FromQuery(Name = "number")]string? number,
            [FromQuery(Name = "name")]string? name)
        {
            using var prjCtrl = new Logic.Controllers.ProjectsController();
            var result = prjCtrl.QueryBy(number, name).ToArray();

            return Ok(result.Select(e => ToModel(e)));
        }
    }
}
