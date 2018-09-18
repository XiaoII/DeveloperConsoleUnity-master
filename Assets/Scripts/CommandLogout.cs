using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandLogout : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandLogout()
        {
            Name = "Logout";
            Command = "logout";
            Description = "Log out of currently logged in user";
            Help = "Issue Logout at the command line";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {
            DeveloperConsole.Instance.loggedIn = false;
            AddMessageToConsole("You have been logged out");
        }

        public static CommandLogout CreateCommand()
        {
            return new CommandLogout();
        }

        private void AddMessageToConsole(string msg)
        {
            DeveloperConsole.Instance.consoleText.text += msg + "\n";
        }
    }
}