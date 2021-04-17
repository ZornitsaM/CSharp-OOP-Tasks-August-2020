using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroShoulHaveAnExpirience()
        {
            var weapon = new FakeWeapon();
            var hero = new Hero("Pesho", weapon);
            var target = new FakeTarget();
            hero.Attack(target);

            Assert.That(hero.Experience, Is.EqualTo(FakeTarget.DefaulthExpririence));

        }




    }
}
