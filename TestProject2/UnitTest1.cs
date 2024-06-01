using ClassLibraryLab10;
using Lab12;
using Lab12._2;
using Lab12._3;
using Lab12._4;
namespace TestProject2

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddPointWhenAddingItemInHashTable()
        {
            // Arrange
            int length = 5;
            MyHashTable<BankCard> myHashTable = new MyHashTable<BankCard>(length);
            int initialCapacity = myHashTable.Capacity;
            BankCard newItem = new BankCard();

            // Act
            myHashTable.AddPoint(newItem);

            // Assert
            Assert.AreEqual(initialCapacity, myHashTable.Capacity);
        }

        [TestMethod]
        public void ContainsWhenItemExistsInHashTable()
        {
            // Arrange
            MyHashTable<BankCard> myHashTable = new MyHashTable<BankCard>(5);
            BankCard item = new BankCard();
            myHashTable.AddPoint(item);

            // Act
            bool result = myHashTable.Contains(item);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveDataWhenItemExistsForHashTable()
        {
            // Arrange
            MyHashTable<BankCard> myHashTable = new MyHashTable<BankCard>(5);
            BankCard item = new BankCard();
            myHashTable.AddPoint(item);

            // Act
            bool removed = myHashTable.RemoveData(item);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(myHashTable.Contains(item));
        }

        [TestMethod]
        public void PrintListAndPrintsErrorMessage()
        {
            // Arrange
            Point<int> point = new Point<int>();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                point.ToString();

                // Assert
                string expected = "пустой список";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void GetHashCode()
        {
            // Arrange
            Point<string> point = new Point<string>();

            // Act
            int hashCode = point.GetHashCode();

            // Assert
            Assert.AreEqual(0, hashCode);
        }

        [TestMethod]
        public void ReturnsCorrectHashCode()
        {
            // Arrange
            Point<string> point = new Point<string>("тест");

            // Act
            int hashCode = point.GetHashCode();

            // Assert
            Assert.AreEqual("тест".GetHashCode(), hashCode);
        }



    }
}