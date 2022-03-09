using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTProjectTeam.Logic.UnitTest
{
    [TestClass]
    public class MemberUnitTest : BaseUnitTest
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            await DeleteAllEntitiesAsync();
        }

        [TestMethod]
        public async Task Create_WithValidFirstAndLastName_ShouldBeAccept()
        {
            using var prjCtrl = new Controllers.ProjectsController();
            using var memCtrl = new Controllers.MembersController();
            using var memCtrlAfter = new Controllers.MembersController();
            var project = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertProject = await prjCtrl.InsertAsync(project);

            Assert.IsNotNull(insertProject);
            await prjCtrl.SaveChangesAsync();

            var member = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FNA",
                Lastname = "LNA",
            };

            var insertMember = await memCtrl.InsertAsync(member);

            Assert.IsNotNull(insertMember);
            await memCtrl.SaveChangesAsync();

            var actualMember = await memCtrlAfter.GetByIdAsync(insertMember.Id);

            Assert.IsNotNull(actualMember);
            Assert.IsTrue(insertMember.AreEqualProperties(actualMember));
        }

        [TestMethod]
        public async Task CreateArray_WithValidFirstAndLastName_ShouldBeAccept()
        {
            using var prjCtrl = new Controllers.ProjectsController();
            using var memCtrl = new Controllers.MembersController();
            using var memCtrlAfter = new Controllers.MembersController();
            var project = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertProject = await prjCtrl.InsertAsync(project);

            Assert.IsNotNull(insertProject);
            await prjCtrl.SaveChangesAsync();

            var member = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FN1",
                Lastname = "LN1",
            };
            var member2 = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FN2",
                Lastname = "LN2",
            };

            var insertMembers = await memCtrl.InsertAsync(new [] { member, member2 });

            Assert.IsNotNull(insertMembers);
            await memCtrl.SaveChangesAsync();

            var actualMember = await memCtrlAfter.GetByIdAsync(insertMembers.ElementAt(0).Id);

            Assert.IsNotNull(actualMember);
            Assert.IsTrue(insertMembers.ElementAt(0).AreEqualProperties(actualMember));

            actualMember = await memCtrlAfter.GetByIdAsync(insertMembers.ElementAt(1).Id);

            Assert.IsNotNull(actualMember);
            Assert.IsTrue(insertMembers.ElementAt(1).AreEqualProperties(actualMember));
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task Create_WithValidFirstAndInvalidLastName_ExpectedException()
        {
            using var prjCtrl = new Controllers.ProjectsController();
            using var memCtrl = new Controllers.MembersController();
            using var memCtrlAfter = new Controllers.MembersController();
            var project = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertProject = await prjCtrl.InsertAsync(project);

            Assert.IsNotNull(insertProject);
            await prjCtrl.SaveChangesAsync();

            var member = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FNA",
                Lastname = "LN",
            };

            var insertMember = await memCtrl.InsertAsync(member);

            Assert.IsNotNull(insertMember);
            await memCtrl.SaveChangesAsync();

            var actualMember = await memCtrlAfter.GetByIdAsync(insertMember.Id);

            Assert.IsNotNull(actualMember);
            Assert.IsTrue(insertMember.AreEqualProperties(actualMember));
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task Create_WithInvalidFirstAndValidLastName_ExpectedException()
        {
            using var prjCtrl = new Controllers.ProjectsController();
            using var memCtrl = new Controllers.MembersController();
            using var memCtrlAfter = new Controllers.MembersController();
            var project = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertProject = await prjCtrl.InsertAsync(project);

            Assert.IsNotNull(insertProject);
            await prjCtrl.SaveChangesAsync();

            var member = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FN",
                Lastname = "LNA",
            };

            var insertMember = await memCtrl.InsertAsync(member);

            Assert.IsNotNull(insertMember);
            await memCtrl.SaveChangesAsync();

            var actualMember = await memCtrlAfter.GetByIdAsync(insertMember.Id);

            Assert.IsNotNull(actualMember);
            Assert.IsTrue(insertMember.AreEqualProperties(actualMember));
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task CreateArray_WithInvalidFirstAndValidLastName_ExpectedException()
        {
            using var prjCtrl = new Controllers.ProjectsController();
            using var memCtrl = new Controllers.MembersController();
            using var memCtrlAfter = new Controllers.MembersController();
            var project = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertProject = await prjCtrl.InsertAsync(project);

            Assert.IsNotNull(insertProject);
            await prjCtrl.SaveChangesAsync();

            var member = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FN1",
                Lastname = "LN1",
            };
            var member2 = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FN",
                Lastname = "LN2",
            };

            var insertMembers = await memCtrl.InsertAsync(new[] { member, member2 });
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task CreateArray_WithValidFirstAndInvalidLastName_ExpectedException()
        {
            using var prjCtrl = new Controllers.ProjectsController();
            using var memCtrl = new Controllers.MembersController();
            using var memCtrlAfter = new Controllers.MembersController();
            var project = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertProject = await prjCtrl.InsertAsync(project);

            Assert.IsNotNull(insertProject);
            await prjCtrl.SaveChangesAsync();

            var member = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FN1",
                Lastname = "LN",
            };
            var member2 = new Entities.Member
            {
                ProjectId = insertProject.Id,
                Firstname = "FN2",
                Lastname = "LN2",
            };

            var insertMembers = await memCtrl.InsertAsync(new[] { member, member2 });

            Assert.IsNotNull(insertMembers);
            await memCtrl.SaveChangesAsync();

            var actualMember = await memCtrlAfter.GetByIdAsync(insertMembers.ElementAt(0).Id);

            Assert.IsNotNull(actualMember);
            Assert.IsTrue(insertMembers.ElementAt(0).AreEqualProperties(actualMember));

            actualMember = await memCtrlAfter.GetByIdAsync(insertMembers.ElementAt(1).Id);

            Assert.IsNotNull(actualMember);
            Assert.IsTrue(insertMembers.ElementAt(1).AreEqualProperties(actualMember));
        }
    }
}
