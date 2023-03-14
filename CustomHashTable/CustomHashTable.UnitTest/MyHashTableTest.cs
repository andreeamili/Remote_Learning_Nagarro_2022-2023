
namespace CustomHashTable.UnitTest
{
    public class MyHashTableTest
    {
        [Fact]
        public void Get_WhenNodeIsNull_ThrowsException()
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(3);
            hashTable.Put("Romania", "Bucharest");
            hashTable.Put("Spain", "Madrid");

            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Get("France"));
        }

        [Fact]
        public void Get_WhenNodeIsNotNull_GetTheValueKey() 
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(3);
            hashTable.Put("Romania", "Bucharest");
            hashTable.Put("Spain", "Madrid");
            hashTable.Put("France", "Paris");

            string value1 = hashTable.Get("Romania");
            string value2 = hashTable.Get("Spain");
            string value3 = hashTable.Get("France");

            Assert.Equal("Bucharest", value1);
            Assert.Equal("Madrid", value2);
            Assert.Equal("Paris", value3);

        }

        [Fact]
        public void Put_WhenTheKeyIsNull_ArgumentNullException()
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(10);

            Assert.Throws<ArgumentNullException>(() => hashTable.Put(null, "value"));
        }

        [Fact]
        public void Put_WhenTheActionIsMade_AddInHashTable()
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(10);

            hashTable.Put("Romania", "Bucharest");
            string result = hashTable.Get("Romania");

            Assert.Equal("Bucharest", result);
        }

        [Fact]
        public void Remove_WhenNodeAndPredAreNotNull_Remove()
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(10);

            hashTable.Put("Romania", "Bucharest");
            bool result = hashTable.Remove("Romania");

            Assert.True(result);
            Assert.False(hashTable.ContainsKey("Romania"));
        }

        [Fact]
        public void Remove_WhenNotExistingKey_ReturnsFalse()
        {
            MyHashTable<string> table = new MyHashTable<string>(10);

            bool result = table.Remove("Germany");
             
            Assert.False(result);
        }

        [Fact]
        public void ContainsKey_WhenKeyExists_ReturnsTrue()
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(3);
            hashTable.Put("Romania", "Bucharest");
            hashTable.Put("Spain", "Madrid");

            bool contains1 = hashTable.ContainsKey("Romania");
            bool contains2 = hashTable.ContainsKey("Spain");

            Assert.True(contains1);
            Assert.True(contains2);
        }

        [Fact]
        public void ContainsKey_WhenKeyDoesNotExist_ReturnsFalse()
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(3);
            hashTable.Put("Romania", "Bucharest");
            hashTable.Put("Spain", "Madrid");

            bool contains = hashTable.ContainsKey("France");

            Assert.False(contains);
        }

        [Fact]
        public void Count_Everytime_ReturnTheLenght()
        {
            MyHashTable<string> hashTable = new MyHashTable<string>(10);

            hashTable.Put("Romania", "Bucharest");
            hashTable.Put("Spain", "Madrid");
            int result = hashTable.Count();

            Assert.Equal(2, result);
        }

    }
}