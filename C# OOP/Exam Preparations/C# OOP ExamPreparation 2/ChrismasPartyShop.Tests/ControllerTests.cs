using ChristmasPastryShop.Core;
using ChristmasPastryShop.Models.Delicacies;
using System.Reflection;

namespace ChrismasPartyShop.Tests
{
    public class ControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddBoothAddsOneBoot()
        {
            //Arrange
            var ctrl = new Controller();

            //Act
            var result = ctrl.AddBooth(5);

            //Assert
            var expected = "Added booth number 1 with capacity 5 in the pastry shop!";
            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        public void AddCocktailAddsMilledWine()
        {
            //Arrange
            var ctrl = new Controller();
            ctrl.AddBooth(5);
            ctrl.AddBooth(5);

            //Act
            var result = ctrl.AddCocktail( 2, "MulledWine", "Redstar", "Middle");

            //Assert
            var expected = "Middle Redstar MulledWine added to the pastry shop!";
            Assert.That(result, Is.EqualTo(expected));

        }
    }
}