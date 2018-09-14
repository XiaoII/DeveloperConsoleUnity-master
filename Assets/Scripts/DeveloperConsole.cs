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
        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

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

            if (!loggedIn)
            {
                //if not logged in (logged in = false) then run a different dictionary of commands to logged in.
            }
            else
            {
                //register a different dictionary of commands
            }



            Commands = new Dictionary<string, ConsoleCommand>();
            consoleInput.ActivateInputField();
        }

        private void Start()
        {
            consoleCanvas.gameObject.SetActive(true);
            CreateCommands();
        }

        //list all commands here 
        private void CreateCommands()
            
        {
            CommandHelp.CreateCommand();
            CommandLogin.CreateCommand();
            CommandQuit.CreateCommand();
            
        }

        //create dictionary commands - change to logged out and logged in dictionaries
        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
        {
            if(!Commands.ContainsKey(_name))
            {
                Commands.Add(_name, _command);
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
            string[] _input = input.Split(null);

            if (_input.Length == 0 || _input == null)
            {
                AddMessageToConsole("Command not recognized. Use Help to see a list of available commands");
                return;
            }

            if (!Commands.ContainsKey(_input[0]))
            {
                AddMessageToConsole("Command not recognized. Use Help to see a list of available commands");
            }
            else
            {
                Commands[_input[0]].RunCommand();
            }

         }
        
    }
}
