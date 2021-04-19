

using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }

            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);

            }

            this.guns.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);


        }


        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player;
            string output = string.Empty;

            var gun = this.guns.Models.FirstOrDefault(x => x.Name == gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            else
            {
                if (type == nameof(Terrorist))
                {
                    player = new Terrorist(username, health, armor, gun);
                }

                else if (type == nameof(CounterTerrorist))
                {

                    player = new CounterTerrorist(username, health, armor, gun);
                }

                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
                }
            }

            this.players.Add(player);
            output = string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            return output;

        }

        public string Report()
        {
            var finalCollection = this.players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenBy(x => x.Health)
                .ThenBy(x => x.Username).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in finalCollection)
            {
                sb.AppendLine($"{item.GetType().Name}: {item.Username}");
                sb.AppendLine($"--Health: {item.Health}");
                sb.AppendLine($"--Armor: {item.Armor}");
                sb.AppendLine($"--Gun: {item.Gun.Name}");

            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            ICollection<IPlayer> allivePlayers = this.players.Models.Where(x => x.IsAlive).ToList();
            return map.Start(allivePlayers);
        }
    }
}
