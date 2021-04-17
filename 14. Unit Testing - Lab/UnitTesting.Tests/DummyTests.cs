using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
   public class DummyTests
    {
        [Test]
        public void DummyLosesPointsByAttack()
        {
            var dummy = new Dummy(10, 20);
            dummy.TakeAttack(20);

            Assert.That(dummy.Health, Is.EqualTo(10 - 20));

        }

        [Test]
        public void DummyShouldThrowExceptionByAttack()
        {
            Assert.Throws<InvalidOperationException>(() =>
           {
               var dummy = new Dummy(0, 20);
               dummy.TakeAttack(20);

           });

        }



        [Test]
        public void DummyCanGiveAExpirienceIfDead()
        {
            var dummy = new Dummy(0, 30);
            var exp = dummy.GiveExperience();
           
            Assert.That(dummy.GiveExperience(),Is.EqualTo(30));

        }

        [Test]
        public void DummyCanGiveAExpirienceIfAlive()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var dummy = new Dummy(20, 30);
                var exp = dummy.GiveExperience();
            });

        }

    }
}
