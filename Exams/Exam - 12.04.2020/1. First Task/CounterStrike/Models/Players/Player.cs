

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Reflection.Metadata.Ecma335;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
            this.IsAlive = true;
        }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }

        }

        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (value==null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }
        public bool IsAlive { get;  set; }


        public virtual void TakeDamage(int points)
        {
            //TODO
            if (this.Armor - points < 0)
            {
                int result = points - this.Armor;
                this.Armor = 0;

                if (this.Health-result<=0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
                else
                {
                    this.Health -= result;
                }
              
            }

            else
            {
                this.Armor -= points;
            }
                
        }
    }
}
