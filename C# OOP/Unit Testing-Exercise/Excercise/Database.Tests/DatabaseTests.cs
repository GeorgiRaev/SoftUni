namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
       private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1,2);
        }

        [Test]
        public void CreatingDatabaseCorrectly()
        {
            int expectedResult = 2;
            int actualResult = database.Count;
            Assert.NotNull(database);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CapacityArrayMustBe16()
        {

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database = new Database(new int[17]));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

    }
}
