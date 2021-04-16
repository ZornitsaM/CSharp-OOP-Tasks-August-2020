using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Interfaces
{
    public interface ICommando:ISpecialisedSoldier
    {

        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);


    }
}
