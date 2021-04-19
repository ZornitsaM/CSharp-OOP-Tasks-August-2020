

using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>)this.players;


        public void Add(IPlayer model)
        {
            //if (model.Username != nameof(Terrorist) && model.Username != nameof(CounterTerrorist))
            //{
            //    throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            //}

            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            var currentPlayer = this.players.FirstOrDefault(x => x.Username == name);


            if (currentPlayer == null)
            {
                return null;
            }

            //TODO
            return (Player)currentPlayer;
        }

        public bool Remove(IPlayer model)
        {
            if (this.players.Contains(model))
            {
                this.players.Remove(model);
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
