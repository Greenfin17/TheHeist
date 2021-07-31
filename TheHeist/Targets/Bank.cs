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

            // create test for courage
            float fright = (float)rand.Next(0, 20) / 10;

            // select one randomt team member by index
            int faintOfHeart = rand.Next(0, robberyTeam.Count - 1);

            int skillSum = 0;
            bool returnVal = false;
            foreach(var member in robberyTeam)
            {
                skillSum += member.Skill;
            }
            Console.WriteLine($"     The heist team has a combined skill level of {skillSum}.");
            Console.WriteLine($"     The bank difficulty is {Difficulty}.");
            
            // select one random team member and test their criminal courage
            if(robberyTeam[faintOfHeart].Courage < fright)
            {
                Console.Write($"     Uh oh, {robberyTeam[faintOfHeart].getName()}");
                Console.Write($" has chickened out of the heist.\n");
                skillSum -= robberyTeam[faintOfHeart].Skill;
            }

            if (skillSum > Difficulty + luck)
            {
                returnVal = true;
            }
            return returnVal;
        }
    }
}
