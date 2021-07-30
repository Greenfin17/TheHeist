using System;
using System.Collections.Generic;
using TheHeist.People;
using TheHeist.Targets;

namespace TheHeist
{
    class Program
    {
        static bool ParseName(ref string firstName, ref string lastName, ref bool continueInput)
        {
            bool returnVal = false;
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            if (words.Length == 2)
            {
                firstName = words[0];
                lastName = words[1];
                returnVal = true;
            }
            else if (input == String.Empty)
            {
                continueInput = false;
                returnVal = true;
            }
            else {
                returnVal = false;
            }
            return returnVal;
        }
        static bool GetMemberInfo(ref Person personObj, ref bool continueInput)
        {
            bool validInput = true;
            string firstName = String.Empty;
            string lastName = String.Empty;
            int skill = -1;
            float courage = -1;
            Console.WriteLine("Enter the team member's first and last name");
            Console.WriteLine("Enter a blank line to exit.");
            if (!ParseName(ref firstName, ref lastName, ref continueInput)){
                Console.WriteLine("Invalid input for first and last name");
                validInput = false;
            }
            if (validInput && continueInput)
            {
                Console.WriteLine("Enter the team member's skill on a scale of 1-10:");
                string skillInput = Console.ReadLine();
                if (!int.TryParse(skillInput, out skill) || skill < 1 || skill > 10) 
                {
                    Console.WriteLine("Invalid input for skill level");
                    validInput = false;
                }
                if (validInput)
                {
                    Console.WriteLine("Enter the team member's courage on a scale of 0.0 to 2.0");
                    string courageInput = Console.ReadLine();
                    if (!float.TryParse(courageInput, out courage) || ( courage < 0.0 || courage > 2.0))
                    {
                        Console.WriteLine("Invalid input for courage level");
                        validInput = false;
                    }
                    if (validInput)
                    {
                        personObj = new Person(firstName, lastName, skill, courage);
                    }
                }
            }
            return validInput;
        }
        static void Main(string[] args)
        {
            Person personObj = null;
            Bank bankTarget = new Bank("Last Bank");
            bool continueInput = true;
            List<Person> teamList = new List<Person>();
            Console.WriteLine("Plan Your Heist!");
            while (continueInput){
                if (GetMemberInfo(ref personObj, ref continueInput) && continueInput)
                {
                    teamList.Add(personObj);
                }
            }
            if (teamList.Count > 0)
            {
                int runs = 0;
                string input;
                Console.WriteLine("Enter number of trial runs of bank heist");
                input = Console.ReadLine();
                if (int.TryParse(input, out runs))
                {
                    for (int i = 0; i < runs; i++)
                    {
                        Console.WriteLine($"Attempting to rob {bankTarget.Name}:");
                        if (bankTarget.HeistAttempt(teamList))
                        {
                            Console.WriteLine($"You team has successfully pulled off the hiest of {bankTarget.Name}\n");
                        }
                        else
                        {
                            Console.WriteLine($"Failed hiest of {bankTarget.Name}\n");
                        }

                    }
                }

            }

        }
    }
}
