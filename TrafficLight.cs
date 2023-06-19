using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_A_Smarter_Stoplight_Problem
{
    public class TrafficLight
    {
        public TrafficLight(string name, bool isgreen, bool isyellow, bool isred)
        {
            Name = name;
            isGreen = isgreen;
            isYellow = isyellow;
            isRed = isred; 
        }
        public string Name { get; set; }
        public bool isGreen { get; set; }
        public bool isYellow { get; set; }
        public bool isRed { get; set; } 

        public int turnYellowTime { get; set; }
        public int turnRedTime { get; set; }
    }
}
