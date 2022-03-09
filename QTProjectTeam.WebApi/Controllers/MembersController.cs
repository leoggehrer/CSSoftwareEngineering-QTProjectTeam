namespace QTProjectTeam.WebApi.Controllers
{
    public class MembersController : GenericController<Logic.Entities.Member, Models.EditMember, Models.Member>
    {
        public MembersController(Logic.Controllers.MembersController controller) : base(controller)
        {
        }
    }
}
