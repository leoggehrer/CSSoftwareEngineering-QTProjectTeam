using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace QTProjectTeam.Logic.UnitTest
{
    [TestClass]
    public class ProjectUnitTest : BaseUnitTest
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            await DeleteAllEntitiesAsync();
        }

        [TestMethod]
        public async Task Create_WithValidNumberAndName_ShouldBeAccept()
        {
            using var ctrl = new Controllers.ProjectsController();
            using var ctrlAfter = new Controllers.ProjectsController();
            var entity = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertEntity = await ctrl.InsertAsync(entity);

            Assert.IsNotNull(insertEntity);
            await ctrl.SaveChangesAsync();

            var actualEntity = await ctrlAfter.GetByIdAsync(insertEntity.Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntity.AreEqualProperties(actualEntity));
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task Create_WithValidNumberAndInvalidName_ExpectedException()
        {
            using var ctrl = new Controllers.ProjectsController();
            using var ctrlAfter = new Controllers.ProjectsController();
            var entity = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = string.Empty,
            };

            var insertEntity = await ctrl.InsertAsync(entity);

            Assert.IsNotNull(insertEntity);
            await ctrl.SaveChangesAsync();

            var actualEntity = await ctrlAfter.GetByIdAsync(insertEntity.Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntity.AreEqualProperties(actualEntity));
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task CreateArray_WithValidNumberAndInvalidName_ExpectedException()
        {
            using var ctrl = new Controllers.ProjectsController();
            using var ctrlAfter = new Controllers.ProjectsController();
            var entity = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };
            var entity2 = new Entities.Project
            {
                Number = "3-44619-313-8".Replace("-", string.Empty),
                Name = string.Empty,
            };

            var insertEntities = await ctrl.InsertAsync(new[] { entity, entity2 });

            Assert.IsNotNull(insertEntities);
            Assert.AreEqual(2, insertEntities.Count());
            await ctrl.SaveChangesAsync();

            var actualEntity = await ctrlAfter.GetByIdAsync(insertEntities.ElementAt(0).Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntities.ElementAt(0).AreEqualProperties(actualEntity));

            actualEntity = await ctrlAfter.GetByIdAsync(insertEntities.ElementAt(1).Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntities.ElementAt(1).AreEqualProperties(actualEntity));
        }

        [TestMethod]
        public async Task CreateArray_WithValidNumberAndName_ShouldBeAccept()
        {
            using var ctrl = new Controllers.ProjectsController();
            using var ctrlAfter = new Controllers.ProjectsController();
            var entity = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };
            var entity2 = new Entities.Project
            {
                Number = "3-44619-313-8".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertEntities = await ctrl.InsertAsync(new [] {entity, entity2 });

            Assert.IsNotNull(insertEntities);
            Assert.AreEqual(2, insertEntities.Count());
            await ctrl.SaveChangesAsync();

            var actualEntity = await ctrlAfter.GetByIdAsync(insertEntities.ElementAt(0).Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntities.ElementAt(0).AreEqualProperties(actualEntity));

            actualEntity = await ctrlAfter.GetByIdAsync(insertEntities.ElementAt(1).Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntities.ElementAt(1).AreEqualProperties(actualEntity));
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task Create_WithInvalidNumberAndName_ExpectedException()
        {
            using var ctrl = new Controllers.ProjectsController();
            using var ctrlAfter = new Controllers.ProjectsController();
            var entity = new Entities.Project
            {
                Number = "0-74755-100-5".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertEntity = await ctrl.InsertAsync(entity);

            Assert.IsNotNull(insertEntity);
            await ctrl.SaveChangesAsync();

            var actualEntity = await ctrlAfter.GetByIdAsync(insertEntity.Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntity.AreEqualProperties(actualEntity));
        }

        [TestMethod]
        [ExpectedException(typeof(Modules.Exceptions.LogicException))]
        public async Task CreateArray_WithAnyInvalidNumberAndName_ExpectedException()
        {
            using var ctrl = new Controllers.ProjectsController();
            using var ctrlAfter = new Controllers.ProjectsController();
            var entity = new Entities.Project
            {
                Number = "0-74755-100-6".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };
            var entity2 = new Entities.Project
            {
                Number = "3-44619-314-8".Replace("-", string.Empty),
                Name = $"Project{++Counter}",
            };

            var insertEntities = await ctrl.InsertAsync(new[] { entity, entity2 });

            Assert.IsNotNull(insertEntities);
            Assert.AreEqual(2, insertEntities.Count());
            await ctrl.SaveChangesAsync();

            var actualEntity = await ctrlAfter.GetByIdAsync(insertEntities.ElementAt(0).Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntities.ElementAt(0).AreEqualProperties(actualEntity));

            actualEntity = await ctrlAfter.GetByIdAsync(insertEntities.ElementAt(1).Id);

            Assert.IsNotNull(actualEntity);
            Assert.IsTrue(insertEntities.ElementAt(1).AreEqualProperties(actualEntity));
        }
    }
}
