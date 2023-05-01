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
            var t = GoogleNewsAPI.NewsApi.GetNews("דרעי","IL","HE").Result;
            Assert.That(t, Is.Not.Null);
            var t2 = GoogleNewsAPI.NewsApi.GetNews("bibi").Result;
            Assert.That(t2, Is.Not.Null);
            var t3 = GoogleNewsAPI.NewsApi.GetNews("bibi","IL","HE").Result;
            Assert.That(t3, Is.Not.Null);
            var t4 = GoogleNewsAPI.NewsApi.GetNews("bibi","IL","EN").Result;
            Assert.That(t4, Is.Not.Null);
            var t5 = GoogleNewsAPI.NewsApi.GetNews("bibi","IL","RU").Result;
            Assert.That(t5, Is.Not.Null);
        }
    }
}