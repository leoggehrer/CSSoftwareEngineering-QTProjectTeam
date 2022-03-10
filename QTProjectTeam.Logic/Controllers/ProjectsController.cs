using QTProjectTeam.Logic.Entities;
using System.Linq.Dynamic.Core;

namespace QTProjectTeam.Logic.Controllers
{
    public class ProjectsController : GenericController<Entities.Project>
    {
        public ProjectsController()
        {
        }

        public ProjectsController(ControllerObject other) : base(other)
        {
        }

        public IQueryable<Project> QueryBy(string? number, string? name)
        {
            IQueryable<Project> result = EntitySet;

            if (string.IsNullOrEmpty(number) == false)
            {
                result = result.Where(p => p.Number.ToUpper() == number.ToUpper());
            }
            if (string.IsNullOrEmpty(name) == false)
            {
                result = result.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }
            return result;
        }
        public override Task<Project> InsertAsync(Project entity)
        {
            CheckEntity(entity);

            return base.InsertAsync(entity);
        }
        public override Task<IEnumerable<Project>> InsertAsync(IEnumerable<Project> entities)
        {
            entities.ToList().ForEach(e => CheckEntity(e));

            return base.InsertAsync(entities);
        }
        public override Task<Project> UpdateAsync(Project entity)
        {
            CheckEntity(entity);

            return base.UpdateAsync(entity);
        }
        public override Task<IEnumerable<Project>> UpdateAsync(IEnumerable<Project> entities)
        {
            entities.ToList().ForEach(e => CheckEntity(e));

            return base.UpdateAsync(entities);
        }
        public override async Task DeleteAsync(int id)
        {
            using var memberCtrl = new MembersController(this);
            var members = await memberCtrl.GetMembersByProjectIdAsync(id).ConfigureAwait(false);

            if (members.Length > 0)
                throw new Modules.Exceptions.LogicException("The project cannot be deleted - there are still members assigned.");

            await base.DeleteAsync(id).ConfigureAwait(false);
        }
        private static void CheckEntity(Project entity)
        {
            if (Numbers.CheckProjectNumber(entity.Number) == false)
            {
                throw new Modules.Exceptions.LogicException($"Invalid project number '{entity.Number}'");
            }

            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new Modules.Exceptions.LogicException($"Invalid project name '{entity.Name}'");
            }
        }
    }
}
