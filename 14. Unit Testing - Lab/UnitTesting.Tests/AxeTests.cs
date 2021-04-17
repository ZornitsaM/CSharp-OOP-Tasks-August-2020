using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace UnitTesting.Tests
{
    [TestFixture]
    class AxeTests
    {
        [Test]
        public void AxeShouldLoseDurability()
        {
            var axe = new Axe(10, 10);
            var target = new Dummy(10, 10);
            axe.Attack(target);
           
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }


        [Test]

        public void AxeShouldThrowExeption()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var axe = new Axe(10, 0);
                var target = new Dummy(100, 500);
                axe.Attack(target);
            });

        }

    }
}
