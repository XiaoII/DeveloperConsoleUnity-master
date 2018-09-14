using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandTemplate : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandTemplate()
        {
            Name = "NAME";
            Command = "COMMAND";
            Description = "WHAT IT DO";
            Help = "HOW DO USE";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {
                //do the thing the command is meant to do here
        }

        public static CommandTemplate CreateCommand()
        {
            return new CommandTemplate();
        }
    }
}