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
            Console.Write($"{Margin(5)}");
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
            Console.WriteLine($"{Margin(5)}Enter the team member's first and last name");
            Console.WriteLine($"{Margin(5)}Enter a blank line to exit.");
            if (!ParseName(ref firstName, ref lastName, ref continueInput)){
                Console.WriteLine($"{Margin(5)}Invalid input for first and last name");
                validInput = false;
            }
            if (validInput && continueInput)
            {
                Console.WriteLine($"{Margin(5)}Enter the team member's skill on a scale of 1-10:");
                Console.Write($"{Margin(5)}");
                string skillInput = Console.ReadLine();
                if (!int.TryParse(skillInput, out skill) || skill < 1 || skill > 10) 
                {
                    Console.WriteLine("Invalid input for skill level");
                    validInput = false;
                }
                if (validInput)
                {
                    Console.WriteLine($"{Margin(5)}Enter the team member's courage on a scale of 0.0 to 2.0");
                    Console.Write($"{Margin(5)}");
                    string courageInput = Console.ReadLine();
                    if (!float.TryParse(courageInput, out courage) || ( courage < 0.0 || courage > 2.0))
                    {
                        Console.WriteLine($"{Margin(5)}Invalid input for courage level");
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

        static bool SetupBank(ref Bank targetBank)
        {
            bool returnVal = false;
            string bankName;           // bank name
            string difficultyStr;      // difficulty of robbing bank
            int difficulty;            // stores int of difficulty
            bool tryAgain = true;      // repeat input in case of error
            ConsoleKeyInfo inputKey = new ConsoleKeyInfo();

            while (tryAgain) {
                Console.WriteLine("     Enter the bank name you have decided to target:");
                Console.Write($"{Margin(5)}");
                bankName = Console.ReadLine();
                Console.WriteLine($"     On a scale of 1 to 100, Enter the difficulty of pulling off a heist at {bankName}");
                Console.Write($"{Margin(5)}");
                difficultyStr = Console.ReadLine();
                if (int.TryParse(difficultyStr, out difficulty) && difficulty > 0 && difficulty <= 100 && bankName != String.Empty)
                {
                    targetBank = new Bank(bankName, difficulty);
                    tryAgain = false;
                    returnVal = true;
                } else
                {
                    Console.WriteLine("     Sorry, error entering bank information");
                    Console.Write("     Hit Escape to exit bank information input\n");
                    inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        tryAgain = false;
                    }
                }
            }
            return returnVal;
        }

        static string Margin(int spaces)
        {
            char[] leadingSpaces = new char[spaces];
            for (int i = 0; i < spaces; i++)
            {
                leadingSpaces[i] = ' ';
            }
            string returnString = new string(leadingSpaces);
            return returnString;
        }
        static void Main(string[] args)
        {
            Person personObj = null;
            Bank bankTarget = null;
            bool continueInput = true;
            List<Person> teamList = new List<Person>();
            Console.WriteLine($"{Margin(5)}Plan Your Heist!");
            if (SetupBank(ref bankTarget))
            {
                while (continueInput)
                {
                    if (GetMemberInfo(ref personObj, ref continueInput) && continueInput)
                    {
                        teamList.Add(personObj);
                    }
                }
                if (teamList.Count > 0)
                {
                    int runs = 0;
                    int successes = 0;
                    string input;
                    Console.WriteLine($"{Margin(5)}Enter number of trial runs of bank heist");
                    Console.Write($"{Margin(5)}");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out runs))
                    {
                        for (int i = 0; i < runs; i++)
                        {
                            Console.WriteLine($"     Attempting to rob {bankTarget.Name}:");
                            if (bankTarget.HeistAttempt(teamList))
                            {
                                Console.WriteLine($"     Your team has successfully pulled off the hiest of {bankTarget.Name}\n");
                                successes++;
                            }
                            else
                            {
                                Console.WriteLine($"     Failed hiest of {bankTarget.Name}\n");
                            }

                        }
                        Console.WriteLine($"{Margin(5)}Your team made {runs} attempts at robbing {bankTarget.Name}.");
                        Console.WriteLine($"{Margin(5)}Your team was successful on {successes} of {runs} attempts");
                    }

                }
            }
            Console.WriteLine($"{Margin(5)}Enter any key to exit.");
            Console.Write($"{Margin(5)}");
            Console.ReadKey();
        }
    }
}
