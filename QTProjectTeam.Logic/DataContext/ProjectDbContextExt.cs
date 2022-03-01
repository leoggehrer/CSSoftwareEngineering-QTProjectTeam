using QTProjectTeam.Logic.Entities;

namespace QTProjectTeam.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<Project> ProjectSet { get; set; }
        public DbSet<Member> MemberSet { get; set; }

        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : IdentityEntity
        {
            if (typeof(E) == typeof(Project))
            {
                handled = true;
                dbSet = ProjectSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Member))
            {
                handled = true;
                dbSet = MemberSet as DbSet<E>;
            }
        }
    }
}
