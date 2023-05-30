using PO7.Enums;
using PO7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
