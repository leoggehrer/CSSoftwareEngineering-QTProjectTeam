using QTProjectTeam.Logic.Entities;

namespace QTProjectTeam.Logic.Controllers
{
    public class MembersController : GenericController<Entities.Member>
    {
        public MembersController()
        {
        }

        public MembersController(ControllerObject other) : base(other)
        {
        }

        public override Task<Member> InsertAsync(Member entity)
        {
            CheckEntity(entity);

            return base.InsertAsync(entity);
        }
        public override Task<IEnumerable<Member>> InsertAsync(IEnumerable<Member> entities)
        {
            entities.ToList().ForEach(e => CheckEntity(e));

            return base.InsertAsync(entities);
        }
        public override Task<Member> UpdateAsync(Member entity)
        {
            CheckEntity(entity);

            return base.UpdateAsync(entity);
        }
        public override Task<IEnumerable<Member>> UpdateAsync(IEnumerable<Member> entities)
        {
            entities.ToList().ForEach(e => CheckEntity(e));

            return base.UpdateAsync(entities);
        }

        public Task<Member[]> GetMembersByProjectIdAsync(int projectId)
        {
            return EntitySet.Where(e => e.ProjectId == projectId).ToArrayAsync();
        }
        private static void CheckEntity(Member entity)
        {
            if (string.IsNullOrEmpty(entity.Firstname) == false && entity.Firstname.Length < 3)
            {
                throw new Modules.Exceptions.LogicException($"First name must be at least 3 characters long.");
            }

            if (string.IsNullOrEmpty(entity.Lastname) == false && entity.Lastname.Length < 3)
            {
                throw new Modules.Exceptions.LogicException($"Last name must be at least 3 characters long.");
            }
        }
    }
}
