using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    using System;

    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]

        public void IfConstructorWorksCorectly()
        {
            string ex = "Pesho";
            var data = new Warrior("Pesho", 5, 32);
            string act = data.Name;
            int exDamage = 5;
            int exHP = 32;

            int actDamage = data.Damage;
            int actHP = data.HP;

            Assert.AreEqual(ex, act);
            Assert.AreEqual(exDamage, actDamage);
            Assert.AreEqual(exHP, actHP);

        }




        [Test]
        public void NameShouldBeNotNull()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var data = new Warrior(null, 5, 6);

            });

        }

        [Test]
        public void NameShouldBeNotEmpty()

        {

            Assert.Throws<ArgumentException>(() =>
            {
                var data = new Warrior(string.Empty, 5, 6);

            });

        }


        [Test]
        public void NameShouldBeNotWhiteSpace()

        {

            Assert.Throws<ArgumentException>(() =>
            {
                var data = new Warrior("       ", 5, 6);

            });

        }

        //[Test]
        //public void GiveAName()

        //{
        //    var data = new Warrior("Koko", 25, 32);
        //    string ex = "Koko";
        //    string act = data.Name;

        //    Assert.AreEqual(ex, act);

        //}

        [Test]
        public void DamageShoulBePositiveNumber()

        {
            Assert.Throws<ArgumentException>(() =>
            {
                var data = new Warrior("Momo", -1, 6);

            });

        }


        [Test]
        public void DamageCanNotBeZero()

        {
            Assert.Throws<ArgumentException>(() =>
            {
                var data = new Warrior("Momo", 0, 6);

            });

        }


        //[Test]
        //public void ActualDamage()

        //{
        //    var data = new Warrior("Koko", 25, 32);
        //    int ex = 25;
        //    int act = data.Damage;

        //    Assert.AreEqual(ex, act);

        //}


        //[Test]
        //public void ActualHP()

        //{
        //    var data = new Warrior("Koko", 25, 32);
        //    int ex = 32;
        //    int act = data.HP;

        //    Assert.AreEqual(ex, act);

        //}



        [Test]
        public void HPCannotBeNegative()

        {
            Assert.Throws<ArgumentException>(() =>
            {
                var data = new Warrior("M", 5, -2);

            });

        }








        [Test]

        public void CanAttackIfHisHPisUnder30()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Warrior("Momo", 10, 25);
                data.Attack(new Warrior("K", 5, 35));
            });

        }

        //K
        [Test]

        public void CanAttackIfHisHPisEqualTo30()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Warrior("Momo", 10, 30);
                data.Attack(new Warrior("K", 5, 35));
            });

        }



        [Test]

        public void CanAttackWarriorHPisUnder30()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Warrior("Momo", 5, 35);
                data.Attack(new Warrior("K", 5, 25));
            });

        }

        //K

        [Test]

        public void CanAttackWarriorHPisEqualTo30()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Warrior("Momo", 5, 35);
                data.Attack(new Warrior("K", 5, 30));
            });

        }

        [Test]

        public void HPisLowerThanWarrior()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Warrior("Momo", 5, 32);
                data.Attack(new Warrior("K", 33, 25));
            });

        }


        [Test]

        public void CanAttack()
        {
            var data = new Warrior("Momo", 5, 32);
            data.Attack(new Warrior("K", 31, 31));

            int ex = 1;
            int act = data.HP;

            Assert.AreEqual(ex, act);

        }

        [Test]

        public void WhenDamageIsUpperThanWarriorHP()
        {
            var data = new Warrior("K", 40, 36);
            var warrior = new Warrior("koko", 35, 36);
            data.Attack(warrior);

            int ex = 0;
            int act = warrior.HP;

            Assert.AreEqual(ex, act);


        }


        [Test]

        public void WhenDamageIslOWERThanWarriorHP()
        {
            var data = new Warrior("K", 35, 42);
            var warrior = new Warrior("koko", 41, 36);
            data.Attack(warrior);

            int ex = 1;
            int act = warrior.HP;

            Assert.AreEqual(ex, act);


        }


    }
}



