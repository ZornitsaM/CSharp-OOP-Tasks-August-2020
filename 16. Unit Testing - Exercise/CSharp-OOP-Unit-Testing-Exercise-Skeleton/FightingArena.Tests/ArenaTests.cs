using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void EnrollWarWhoIsExisiting()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Arena();
                data.Enroll(new Warrior("M", 5, 6));
                data.Enroll(new Warrior("M", 5, 6));

            });
        }


        //K
        [Test]
        public void EnrollContainingWarrior()
        {
            var data = new Arena();
            var warrior = new Warrior("Popo", 5, 31);
            data.Enroll(warrior);

            Assert.That(data.Warriors, Has.Member(warrior));
        }


        //K
        [Test]
        public void EnrollWarriorWithTheSameName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Arena();
                data.Enroll(new Warrior("M", 30, 6));
                data.Enroll(new Warrior("M", 5, 6));

            });
        }

        [Test]
        public void EnrollWarWhoIsNOTExisiting()
        {
            var data = new Arena();
            data.Enroll(new Warrior("M", 5, 6));
            int ex = 1;
            int act = data.Count;

            Assert.AreEqual(ex, act);

        }

        //K
        [Test]
        public void TestTheConstructors()
        {
            var data = new Arena();
            Assert.IsNotNull(data.Warriors);

        }


        [Test]

        public void FightAttackerIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Arena();

                data.Enroll(new Warrior("O", 5, 6));
                data.Enroll(new Warrior("M", 5, 6));

                data.Fight("L", "O");

            });

        }


        [Test]

        public void DefenderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Arena();

                data.Enroll(new Warrior("O", 5, 6));
                data.Enroll(new Warrior("M", 5, 6));

                data.Fight("M", "K");

            });
        }


        [Test]

        public void BothAreNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Arena();

                data.Enroll(new Warrior("O", 5, 6));
                data.Enroll(new Warrior("M", 5, 6));

                data.Fight("P", "E");

            });
        }


        //K

        [Test]

        public void BothAreaREExist()

        {
            var data = new Arena();
            var firstWarrior = new Warrior("O", 4, 32);
            var secondWarrior = new Warrior("M", 5, 33);
            data.Enroll(firstWarrior);
            data.Enroll(secondWarrior);

            int exAHP = firstWarrior.HP - secondWarrior.Damage;  //5
            int exSHP = secondWarrior.HP - firstWarrior.Damage;  //0

            data.Fight("O", "M");

            Assert.AreEqual(exAHP, firstWarrior.HP);
            Assert.AreEqual(exSHP, secondWarrior.HP);

        }

    }
}


