using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public class CommandHelp : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }


        public CommandHelp()
        {
            Name = "Help";
            Command = "help";
            Description = "Lists all available commands";
            Help = "Enter help with no arguments";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {

            AddMessageToConsole("Available Commands:");
            foreach (KeyValuePair<string, ConsoleCommand> command in DeveloperConsole.LoggedInCommands)
            {
                AddMessageToConsole("-------------------------------------------------");
                //AddMessageToConsole(command.Key);
                AddMessageToConsole("Command: " + command.Value.Name.ToString());
                //AddMessageToConsole(command.Value.Command.ToString());
                AddMessageToConsole("Description: " + command.Value.Description.ToString());
                AddMessageToConsole("Usage: " + command.Value.Help.ToString());

            }
            
        }

        public static CommandHelp CreateCommand()
        {
            return new CommandHelp();
        }

        private void AddMessageToConsole(string msg)
        {
            DeveloperConsole.Instance.consoleText.text += msg + "\n";
        }


    }


}
