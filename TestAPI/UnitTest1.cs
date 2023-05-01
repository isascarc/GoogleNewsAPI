using NUnit.Framework;

namespace TestAPI
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var t = GoogleNewsAPI.NewsApi.GetNews(".net").Result;
            Assert.That(t, Is.Not.Null);
        }
    }
}