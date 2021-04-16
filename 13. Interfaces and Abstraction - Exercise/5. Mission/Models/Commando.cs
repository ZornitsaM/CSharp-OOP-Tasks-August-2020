using PO7.Enums;
using PO7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();

        }


        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Missions: ");


            foreach (IMission item in missions)
            {
                sb.AppendLine(" " + item);

            }

            return sb.ToString().TrimEnd();
        }
    }
}
