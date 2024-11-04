using NUnit.Framework;
namespace MathHelper.Tests
{
    public class MathHelperTests
    {
        [Test]
        public void Sum_Should_Sum_Correctly()
        {
            MathsHelper helper = new MathsHelper();

            Assert.AreEqual(10, helper.Sum(5,5), "Da ti eba i PROGRAMIRANETO!!!");
        }

        [Test]
        public void Sum_Should_Work_Correctly_With_Negative_Numbers()
        {
            MathsHelper helper = new MathsHelper();

            Assert.AreEqual(-11,helper.Sum(-5,-6),"Da ti EBA I SHIBANOTO PROGRAMIRANE!!!!!!!!");
        }
    }
}
