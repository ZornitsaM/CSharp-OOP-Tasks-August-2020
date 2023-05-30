using PO7.Enums;
using PO7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName {get; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
