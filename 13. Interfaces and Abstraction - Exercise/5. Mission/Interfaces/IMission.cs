using PO7.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        MissionState State { get; }

        void CompleteMission();
    }
}
