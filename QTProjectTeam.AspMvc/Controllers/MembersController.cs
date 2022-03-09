namespace QTProjectTeam.AspMvc.Controllers
{
    public class MembersController : GenericController<Logic.Entities.Member, Models.Member>
    {
        public MembersController(Logic.Controllers.MembersController controller) : base(controller)
        {
        }

    }
}
