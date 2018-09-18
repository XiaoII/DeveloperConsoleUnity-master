using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Login needs to be issued when the console wakes up automatically
//login must be disabled if already logged in check login state, set a variable somewhere
//logout needs to be a command with a check, y/n
//usernames - password - root - user 
//permissions

namespace Console
{
    public class CommandLogin : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandLogin()
        {
            Name = "Login";
            Command = "login";
            Description = "Login to the terminal";
            Help = "Type Login, then enter username and password separated by a space";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {
            DeveloperConsole.Instance.loggedIn = true;
            AddMessageToConsole("You have been logged in");
            DeveloperConsole.Instance.CreateLoggedInCommands();
        }


        public static CommandLogin CreateCommand()
        {
            return new CommandLogin();
        }

        private void AddMessageToConsole(string msg)
        {
            DeveloperConsole.Instance.consoleText.text += msg + "\n";
        }
    }
}