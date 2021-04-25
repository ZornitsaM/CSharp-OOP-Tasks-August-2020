
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enum;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Core
{
    
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<ProcedureType, IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<ProcedureType, IProcedure>();
            this.Addprocedurees();
        }

        private void Addprocedurees()
        {
            this.procedures.Add(ProcedureType.Charge, new Charge());
            this.procedures.Add(ProcedureType.Chip, new Chip());
            this.procedures.Add(ProcedureType.Polish, new Polish());
            this.procedures.Add(ProcedureType.Rest, new Rest());
            this.procedures.Add(ProcedureType.TechCheck, new TechCheck());
            this.procedures.Add(ProcedureType.Work, new Work());
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                return string.Format(ExceptionMessages.InexistingRobot, robotName);
            }

            
            IProcedure procedure = this.procedures[ProcedureType.Charge];
            IRobot robot = this.garage.Robots[robotName];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }


        public string Chip(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                return string.Format(ExceptionMessages.InexistingRobot, robotName);
            }

            IProcedure procedure = this.procedures[ProcedureType.Chip];
            IRobot robot = this.garage.Robots[robotName];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);

        }


        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType newProcedureType);
            var procedure = this.procedures[newProcedureType];


            return procedure.History();
        }


        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            if (robotType==nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }

            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);

            }

            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);

            }

            else
            {
                return string.Format(ExceptionMessages.InvalidRobotType, robotType);
            }

            this.garage.Manufacture(robot);
            return string.Format(OutputMessages.RobotManufactured, robot.Name);

        }


        public string Polish(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                return string.Format(ExceptionMessages.InexistingRobot, robotName);
            }

            IProcedure procedure = this.procedures[ProcedureType.Polish];
            IRobot robot = this.garage.Robots[robotName];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }


        public string Rest(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                return string.Format(ExceptionMessages.InexistingRobot, robotName);
            }
            IProcedure procedure = this.procedures[ProcedureType.Rest];
            IRobot robot = this.garage.Robots[robotName];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }


        public string Sell(string robotName, string ownerName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                return string.Format(ExceptionMessages.InexistingRobot, robotName);
            }

            IRobot robot = this.garage.Robots[robotName];
            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }

            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }


        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                return string.Format(ExceptionMessages.InexistingRobot, robotName);
            }

            IProcedure procedure = this.procedures[ProcedureType.TechCheck];
            IRobot robot = this.garage.Robots[robotName];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }



        public string Work(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                return string.Format(ExceptionMessages.InexistingRobot, robotName);
            }

            IProcedure procedure = this.procedures[ProcedureType.Work];
            IRobot robot = this.garage.Robots[robotName];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName,procedureTime);
        }
    }
}
