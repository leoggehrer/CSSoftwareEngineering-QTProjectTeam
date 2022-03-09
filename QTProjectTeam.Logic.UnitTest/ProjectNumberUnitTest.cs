using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QTProjectTeam.Logic.UnitTest
{
    [TestClass]
    public class ProjectNumberUnitTest
    {
        [TestMethod]
        public void Check_ValidNumberWithCheckSignX_ShouldBeTrue()
        {
            var number = "3-49913-599-X";

            Assert.IsTrue(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_ValidNumberWithCheckSignx_ShouldBeTrue()
        {
            var number = "3-49913-599-x";

            Assert.IsTrue(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_ValidNumberWithCheckDigit8_ShouldBeTrue()
        {
            var number = "3-44619-313-8";

            Assert.IsTrue(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_ValidNumberWithCheckDigit6_ShouldBeTrue()
        {
            var number = "0-74755-100-6";

            Assert.IsTrue(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_ValidNumberWithCheckDigit2_ShouldBeTrue()
        {
            var number = "1-57231-422-2";

            Assert.IsTrue(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_InvalidNumberWithCheckDigit1_ShouldBeFalse()
        {
            var number = "1-57231-422-1";

            Assert.IsFalse(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_InvalidNumberWithCheckDigit3_ShouldBeFalse()
        {
            var number = "1-57231-422-3";

            Assert.IsFalse(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_InvalidNumberWithWrongLength_ShouldBeFalse()
        {
            var number = "1-572-42-2";

            Assert.IsFalse(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        public void Check_EmptyNumber_ShouldBeFalse()
        {
            var number = string.Empty;

            Assert.IsFalse(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Check_NullNumber_ExpectedArgumentNullException()
        {
            string? number = null;

            Assert.IsFalse(Numbers.CheckProjectNumber(number));
        }

        [TestMethod]
        public void Create_100ValidNumber_ShouldBeTrue()
        {
            for (int i = 0; i < 100; i++)
            {
                var number = Numbers.CreateProjectNumber();

                Assert.IsTrue(Numbers.CheckProjectNumber(number.Replace("-", string.Empty)));
            }
        }
    }
}