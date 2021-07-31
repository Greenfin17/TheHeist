using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeist.People
{
    class Person
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int Skill { get; set; }
        public float Courage { get; set; }

        public Person(string first, string last, int skill, float courage)
        {
            First = first;
            Last = last;
            Skill = skill;
            Courage = courage;
        }

        public string getName()
        {
            return $"{First} {Last}";
        }

        public void Status()
        {
            Console.WriteLine($"               {First} {Last}");
            Console.WriteLine($"               Skill: {Skill}, Courage: {Courage}");
        }
    }
}
