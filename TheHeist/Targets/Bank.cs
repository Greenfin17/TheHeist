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

        public Bank(string name, int difficulty = 100)
        {
            Name = name;
            Difficulty = difficulty;
            IsRobbed = false;
        }

        public bool HeistAttempt(List<Person> robberyTeam)
        {
            int skillSum = 0;
            bool returnVal = false;
            foreach(var member in robberyTeam)
            {
                skillSum += member.Skill;
            }

            if (skillSum > Difficulty)
            {
                returnVal = true;
            }
            return returnVal;
        }
    }
}
