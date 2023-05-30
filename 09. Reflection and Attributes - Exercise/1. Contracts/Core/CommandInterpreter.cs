using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string args)
        {
            string[] commandTokens = args.Split().ToArray();
            string commandName = commandTokens[0] + COMMAND_POSTFIX;
            string[] commandArgs = commandTokens.Skip(1).ToArray();
            
            var commandType = Assembly.GetCallingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Any(i => i.Name == nameof(ICommand)))
                .FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());
 

            if (commandType==null)
            {
                throw new ArgumentException("Invalid format");
            }

            var commandInstance =(ICommand) Activator.CreateInstance(commandType);
            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
