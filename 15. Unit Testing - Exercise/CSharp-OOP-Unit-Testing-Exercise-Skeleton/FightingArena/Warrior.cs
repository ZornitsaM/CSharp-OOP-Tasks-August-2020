using System;

namespace FightingArena
{
    public class Warrior
    {
        private const int MIN_ATTACK_HP = 30;

        private string name;
        private int damage;
        private int hp;

        public Warrior(string name, int damage, int hp)
        {
            this.Name = name;
            this.Damage = damage;
            this.HP = hp;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            //OK X3
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty or whitespace!");
                }

                //OK
                this.name = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            //OK
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Damage value should be positive!");
                }

                //OK
                this.damage = value;
            }
        }

        public int HP
        {
            get
            {
                return this.hp;
            }

            //OK
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HP should not be negative!");
                }

                //OK
                this.hp = value;
            }
        }

        public void Attack(Warrior warrior)
        {
            //OK ?
            if (this.HP <= MIN_ATTACK_HP)
            {
                throw new InvalidOperationException("Your HP is too low in order to attack other warriors!");
            }

            //OK
            if (warrior.HP <= MIN_ATTACK_HP)
            {
                throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
            }

            //OK
            if (this.HP < warrior.Damage)
            {
                throw new InvalidOperationException($"You are trying to attack too strong enemy");
            }


            //OK
            this.HP -= warrior.Damage;


            //OK
            if (this.Damage > warrior.HP)
            {
                warrior.HP = 0;
            }

            //OK
            else
            {
                warrior.HP -= this.Damage;
            }
        }
    }
}
