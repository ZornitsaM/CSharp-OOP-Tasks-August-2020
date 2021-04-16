using PO7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Models
{
    public class LieutenantGeneral : Private,ILieutenantGeneral
    {
        private readonly List<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
         
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(IPrivate prPrivate)
        {
            this.privates.Add(prPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Privates: ");

            foreach (IPrivate item in this.privates)
            {

                sb.AppendLine("  " + item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
