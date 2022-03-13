using System.Threading.Tasks;

namespace QTProjectTeam.Logic.UnitTest
{
    public class BaseUnitTest
    {
        public static async Task DeleteAllEntitiesAsync()
        {
            using var projectCtrl = new Controllers.ProjectsController();
            using var memberCtrl = new Controllers.MembersController(projectCtrl);

            var members = await memberCtrl.GetAllAsync();

            foreach (var item in members)
            {
                await memberCtrl.DeleteAsync(item.Id);
            }
            await memberCtrl.SaveChangesAsync();

            var projects = await projectCtrl.GetAllAsync();

            foreach (var item in projects)
            {
                await projectCtrl.DeleteAsync(item.Id);
            }
            await projectCtrl.SaveChangesAsync();
        }

        protected static int Counter = 0;
    }
}
