

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private readonly ICollection<IPlayer> players;

        public Map()
        {
            this.players = new List<IPlayer>();

        }



        public string Start(ICollection<IPlayer> players)
        {
            var listTerrorist = new Queue<IPlayer>();
            var listCounterTerrosrist = new Queue<IPlayer>();

            foreach (var player in players)
            {
                if (player.GetType().Name == nameof(CounterTerrorist))
                {
                    listCounterTerrosrist.Enqueue(player);
                }

                else if (player.GetType().Name == nameof(Terrorist))
                {
                    listTerrorist.Enqueue(player);
                }
            }

            bool winCounter = false;
            bool winTerrosrist = false;

            while (true)
            {
                if (listTerrorist.Count == 0)
                {
                    winTerrosrist = true;
                    break;
                }

                if (listCounterTerrosrist.Count == 0)
                {
                    winCounter = true;
                    break;
                }

                var currentTerrorist = listTerrorist.Dequeue();
                var currentCounterTerrorist = listCounterTerrosrist.Dequeue();

                var fireBiilets = currentTerrorist.Gun.Fire();
                if (currentTerrorist.Gun.BulletsCount >= fireBiilets)
                {
                    currentCounterTerrorist.TakeDamage(fireBiilets);

                }



                if (currentCounterTerrorist.Health>0)
                {
                    fireBiilets = currentCounterTerrorist.Gun.Fire();
                    if (currentCounterTerrorist.Gun.BulletsCount >= fireBiilets)
                    {
                        currentTerrorist.TakeDamage(fireBiilets);

                    }


                }

                if (currentTerrorist.Health>0)
                {
                    listTerrorist.Enqueue(currentTerrorist);
                }

                if (currentCounterTerrorist.Health>0)
                {
                    listCounterTerrosrist.Enqueue(currentCounterTerrorist);
                }


            }

            string output = string.Empty;

            if (winTerrosrist)
            {
                output = "Counter Terrorist wins!";
               
            }

            else if (winCounter)
            {
                output = "Terrorist wins!";
            }

            return output;

        }
    }
}
