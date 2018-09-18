using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{
    public abstract class ConsoleCommand
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }

        public void AddCommandToConsole()
        {
            //string addMessage = " command has been added to the console.";

            DeveloperConsole.AddCommandsToConsole(Command, this);
            //Debug.Log(Name + addMessage);
        }

        public abstract void RunCommand();
    }

    public class DeveloperConsole : MonoBehaviour
    {
        public static DeveloperConsole Instance { get; private set; }
        public static Dictionary<string, ConsoleCommand> LoggedInCommands { get; private set; }
        public static Dictionary<string, ConsoleCommand> LoggedOutCommands { get; private set; }

        [Header("UI Components")]
        public Canvas consoleCanvas;
        public Text consoleText;
        public Text inputText;
        public InputField consoleInput;
        public bool loggedIn = false;

        private void Awake()
        {
            if(Instance != null)
            {
                return;
            }

            Instance = this;
            consoleInput.ActivateInputField();


            LoggedInCommands = new Dictionary<string, ConsoleCommand>();
            LoggedOutCommands = new Dictionary<string, ConsoleCommand>();

        }

        private void Start()
        {
            consoleCanvas.gameObject.SetActive(true);
            CreateLoggedInCommands();
            CreateLoggedOutCommands();
        }

        //list all commands here 
        public void CreateLoggedInCommands()
            
        {
            CommandHelp.CreateCommand();
            CommandQuit.CreateCommand();
            CommandLogout.CreateCommand();
            
        }
        private void CreateLoggedOutCommands()

        {
            CommandLogin.CreateCommand();
        }

        //create dictionary commands - change to logged out and logged in dictionaries
        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
        {
            if (DeveloperConsole.Instance.loggedIn == true)
            {
                if (!LoggedInCommands.ContainsKey(_name))
                {
                    LoggedInCommands.Add(_name, _command);
                }
            }
            else
            {
                if (!LoggedOutCommands.ContainsKey(_name))
                {
                    LoggedOutCommands.Add(_name, _command);
                }
            }
        }

        //every frame - where input is captured - pressing enter
        private void Update()
        {
           
          if(Input.GetKeyDown(KeyCode.Return))
                {
                    if(inputText.text != "")
                    {
                        AddMessageToConsole(inputText.text);
                        ParseInput(inputText.text);
                        consoleInput.text = "";
                        consoleInput.ActivateInputField();
                    }
                }
            
        }

        //write out to console
        private void AddMessageToConsole(string msg)
        {
            consoleText.text += msg + "\n";
        }

        //where run command is called - need a second one if logged in/out to check different dictionaries?
        private void ParseInput(string input)
        {
            if (loggedIn == true)
            {
                string[] _input = input.Split(null);

                if (_input.Length == 0 || _input == null)
                {
                    AddMessageToConsole("Command not recognized. Use Help to see a list of available commands");
                    return;
                }

                if (!LoggedInCommands.ContainsKey(_input[0]))
                {
                    AddMessageToConsole("Command not recognized. Use Help to see a list of available commands");
                }
                else
                {
                    LoggedInCommands[_input[0]].RunCommand();
                }
            }
            else
            {
                string[] _input = input.Split(null);

                if (_input.Length == 0 || _input == null)
                {
                    AddMessageToConsole("You are not logged in. Please login to continue.");
                    return;
                }

                if (!LoggedOutCommands.ContainsKey(_input[0]))
                {
                    AddMessageToConsole("Command not recognised");
                }
                else
                {
                    LoggedOutCommands[_input[0]].RunCommand();
                }
            }

         }
        
    }
}
