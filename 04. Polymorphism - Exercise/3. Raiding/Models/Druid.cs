using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }


    }
}
