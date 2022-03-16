using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTProjectTeam.ConApp
{
    partial class Program
    {
        static readonly Random random = new Random(DateTime.Now.Millisecond);
        static partial void AfterRun()
        {
            for (int i = 0; i < 10; i++)
            {
                var n = Numbers.CreateProjectNumber();

                if (Numbers.CheckProjectNumber(n))
                    Console.WriteLine(n);
            }

            //using var projectCtrl = new Logic.Controllers.ProjectsController();
            //var projectFaker = new Faker<Logic.Entities.Project>()
            //                    .RuleFor(p => p.Number, f => Numbers.CreateProjectNumber())
            //                    .RuleFor(p => p.Name, f => String.Join(" ", f.Lorem.Words(5)));
            //var memberFaker = new Faker<Logic.Entities.Member>()
            //                    .RuleFor(m => m.Lastname, f => f.Name.LastName())
            //                    .RuleFor(m => m.Firstname, f => f.Name.FirstName());
            //var projects = projectFaker.Generate(10);

            //Task.Run(async () =>
            //{
            //    foreach (var project in projects)
            //    {
            //        project.Members.AddRange(memberFaker.Generate(random.Next(0, 10)));
            //    }
            //    await projectCtrl.InsertAsync(projects);
            //    await projectCtrl.SaveChangesAsync();
            //}).Wait();
        }
    }
}
