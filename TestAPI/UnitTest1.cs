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
            var t2 = GoogleNewsAPI.NewsApi.GetNews("").Result;
            Assert.That(t2, Is.Not.Null);
        }
    }
}