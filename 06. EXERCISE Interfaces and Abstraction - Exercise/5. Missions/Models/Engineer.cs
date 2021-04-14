using PO7.Enums;
using PO7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public readonly List<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Repairs: ");


            foreach (IRepair item in repairs)
            {
                sb.AppendLine(" " + item);

            }

            return sb.ToString().TrimEnd();
        }
    }
}
