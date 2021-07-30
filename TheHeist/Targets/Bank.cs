using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHeist.People;

namespace TheHeist.Targets
{
    class Bank
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }

        public bool IsRobbed { get; set; }

        public Bank(string name, int difficulty = 25)
        {
            Name = name;
            Difficulty = difficulty;
            IsRobbed = false;
        }

        public bool HeistAttempt(List<Person> robberyTeam)
        {
            // create random number for heist luck value
            Random rand = new Random();
            int luck = rand.Next(-10, 10);

            int skillSum = 0;
            bool returnVal = false;
            foreach(var member in robberyTeam)
            {
                skillSum += member.Skill;
            }

            Console.WriteLine($"The heist team has a combined skill level of {skillSum}.");
            Console.WriteLine($"The bank difficulty is {Difficulty}.");

            if (skillSum > Difficulty + luck)
            {
                returnVal = true;
            }
            return returnVal;
        }
    }
}
