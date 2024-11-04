using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class FactoryTests
    {
        private Factory factory;
        [SetUp]
        public void Setup()
        {
            factory = new("Ivan", 10);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string expectedName = "Ivan";
            int expectedCapacity = 10;

            Assert.AreEqual(expectedName, factory.Name);
            Assert.AreEqual(expectedCapacity, factory.Capacity);
            Assert.NotNull(factory.Robots);
            Assert.NotNull(factory.Supplements);
        }

        [Test]
        public void NameSettedShouldWorkProperly()
        {
            string expectedName = "Peter";

            factory.Name = expectedName;

            Assert.AreEqual(expectedName, factory.Name);
        }

        [Test]
        public void CapacitySettedShouldWorkProperly()
        {
            int expectedCapacity = 5;

            factory.Capacity = expectedCapacity;

            Assert.AreEqual(expectedCapacity, factory.Capacity);
        }

        [Test]
        public void ProduceRobotShouldAddRobotToInnerCollection()
        {
            Robot expectedRobot = new("Terminator", 123.4532, 24);

            string expectedMessege = $"Produced --> Robot model: {expectedRobot.Model} IS: {expectedRobot.InterfaceStandard}, Price: {expectedRobot.Price:f2}";

            string actualMessege = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);

            Robot actualRobot = factory.Robots.Single();

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
            Assert.AreEqual(expectedMessege, actualMessege);
        }

        [Test]
        public void ProduceRobotShouldNotAddToInnerCollectionWhenCapacityLimitIsReached()
        {
            factory.Capacity = 0;
            string excpectedMessege = "The factory is unable to produce more robots for this production day!";
            string actualMessege = factory.ProduceRobot("Terminator", 123, 24);
            Assert.AreEqual(excpectedMessege, actualMessege);
        }

        [Test]
        public void ProduceSupplementShouldAddSupplementToInnerCollection()
        {
            Supplement expectedSupplement = new("Terminator", 20);

            string excpectedMessege = $"Supplement: {expectedSupplement.Name} IS: {expectedSupplement.InterfaceStandard}";

            string actualMessege = factory.ProduceSupplement(expectedSupplement.Name, expectedSupplement.InterfaceStandard);

            Supplement actualSupplement = factory.Supplements.Single();

            Assert.AreEqual(expectedSupplement.Name, actualSupplement.Name);
            Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSupplement.InterfaceStandard);
            Assert.AreEqual(excpectedMessege, actualMessege);

        }

        [Test]
        public void UpgradeRobotShouldAddSupplementAndReturnTrue()
        {
            Robot robot = new("Terminator", 123.4532, 25);
            Supplement expectedSupplement = new("Laser", 25);

            bool actualResult = factory.UpgradeRobot(robot, expectedSupplement);

            Supplement actualSupplement = robot.Supplements.Single();

            Assert.True(actualResult);
            Assert.AreEqual(expectedSupplement.Name, actualSupplement.Name);
            Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSupplement.InterfaceStandard);
        }

        [Test]
        public void UpgradeRobotShouldNotAddSupplementAndReturnFalseWhenSupplementAlreadyAdded()
        {
            Robot robot = new("Terminator", 123.4532, 25);
            Supplement expectedSupplement = new("Laser", 25);

            _ = factory.UpgradeRobot(robot, expectedSupplement);
            bool expectedResult = factory.UpgradeRobot(robot, expectedSupplement);

            Assert.False(expectedResult);
            Assert.AreEqual(1, robot.Supplements.Count);

        }

        [Test]
        public void UpgradeRobotShouldNotAddSupplementAndReturnFalseWhenInterfaceStandardsDoesNotMatch()
        {
            int interfaceStandard = 25;
            Robot robot = new("Terminator", 123.4532, interfaceStandard);
            Supplement expectedSupplement = new("Laser", interfaceStandard + 1);

            bool expectedResult = factory.UpgradeRobot(robot, expectedSupplement);

            Assert.False(expectedResult);
            Assert.AreEqual(0, robot.Supplements.Count);
        }

        [Test]
        public void SellRobotShouldReturnCorrectRobot()
        {
            Robot expectedRobot = new("Terminator", 700, 24);


            _ = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
            _ = factory.ProduceRobot("Terminator2", 100, 25);
            _ = factory.ProduceRobot("Terminator3", 500,26);

            Robot actualRobot = factory.SellRobot(800);

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
        }
        [Test]
        public void SellRobotShouldReturnNullIfPriceIsToLow()
        {
            Robot expectedRobot = new("Terminator", 700, 24);


            _ = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
            _ = factory.ProduceRobot("Terminator2", 100, 25);
            _ = factory.ProduceRobot("Terminator3", 500, 26);

            Robot actualRobot = factory.SellRobot(20);

            Assert.Null(actualRobot);
        }
        [Test]
        public void SellRobotShouldReturnNullIfRobotsCollectionIsEmpty()
        {
            Robot actualRobot = factory.SellRobot(20);
            Assert.Null(actualRobot);
        }
    }
}