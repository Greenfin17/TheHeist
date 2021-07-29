using System;
using TheHeist.People;
using System.Collections.Generic;

namespace TheHeist
{
    class Program
    {
        static bool ParseName(ref string firstName, ref string lastName)
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
            else {
                Console.WriteLine("Enter a first and last name only");
            }
            return returnVal;
        }
        static bool GetMemberInfo(ref Person personObj)
        {
            bool validInput = true;
            string firstName = String.Empty;
            string lastName = String.Empty;
            int skill = -1;
            float courage = -1;
            Console.WriteLine("Enter the team member's first and last name");
            if (!ParseName(ref firstName, ref lastName)){
                Console.Write("Invalid input for first and last name");
                validInput = false;
            }
            Console.WriteLine("Enter the team member's skill on a scale of 1-10:");
            string skillInput = Console.ReadLine();
            if (!int.TryParse(skillInput, out skill))
            {
                Console.Write("Invalid input for skill level");
                validInput = false;
            } 
            Console.WriteLine("Enter the team member's courage on a scale of 0.0 to 2.0");
            string courageInput = Console.ReadLine();
            if (!float.TryParse(courageInput, out courage))
            {
                Console.Write("Invalide input for courage level");
                validInput = false;
            }

            if (validInput)
            {
                personObj = new Person(firstName, lastName, skill, courage);
            }
            return validInput;
        }
        static void Main(string[] args)
        {
            Person personObj = null;
            List<Person> teamList = new List<Person>();
            Console.WriteLine("Plan Your Heist!");
            if (GetMemberInfo(ref personObj))
            {
                teamList.Add(personObj);
                Console.WriteLine($"     So far the team consists of");
                teamList[0].Status();
            }
        }
    }
}
