//COP 4365-Spring 2022
//Homework #2: A Smarter Stoplight Problem
//This code is a more advanced stoplight that goes through a sequence from each direction displaying green, yellow, and red lights
//Homework2 A Smarter Stoplight Problem
//Sophia Hostetler
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Homework2_A_Smarter_Stoplight_Problem
{
    public partial class Form1 : Form
    {
        //Initialize lights
        TrafficLight North = new TrafficLight("North", true, false, false);
        TrafficLight East = new TrafficLight("East", false, false, true);
        TrafficLight South = new TrafficLight("South", false, false, true);
        TrafficLight West = new TrafficLight("West", false, false, true);

        public Form1()
        {
            //update light color
            InitializeComponent();
           updateLight(North);
           updateLight(South);
            updateLight(East);
           updateLight(West);
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public void StartButton_Click(object sender, EventArgs e)
        {
            //Start the program to print out the sequence in the console 

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // Get the elapsed time as a TimeSpan value.
            int ts = stopWatch.Elapsed.Seconds;
            setYellowTime(North, ts);
            Debug.WriteLine("Begin");
            string prevString = "";
            while (ts <= 60)
            {

                //If car shows up 
                if (ts >= 35 && ts < 45)
                {
                    setRed(North);
                    setRed(South);
                    setRed(West);
                    setGreen(East);
                    North.turnYellowTime = 0;
                    North.turnRedTime = 0;
                    South.turnYellowTime = 0;
                    South.turnRedTime = 0;
                    West.turnYellowTime = 0;
                    West.turnYellowTime = 0;
                    setYellowTime(East, ts);

                    var temp = (ts.ToString() + " " + displayColor(North) + " " + displayColor(South) + " " + displayColor(East) + " " + displayColor(West));
                    if (temp != prevString)
                    {
                        Console.WriteLine(temp);
                        prevString = temp;
                    }
                    //announcing emergency vehicle
                    var veh = (ts.ToString() + " An emergency vehicle has been detected coming from the East .\n" + " " + displayColor(North) + " " + displayColor(South) + " " + displayColor(East) + " " + displayColor(West));
                    if (ts == 35)
                    {
                        Console.WriteLine(veh);
                    }
                    //announcing the vehicle leaving
                    var left = (ts.ToString() + " The emergency vehicle has left the area .\n" + " " + displayColor(North) + " " + displayColor(South) + " " + displayColor(East) + " " + displayColor(West));

                    if (ts == 45)
                    {
                        Console.WriteLine(left);
                    }


                }
                else
                {
                    //if statements turning the light colors
                    if (North.turnYellowTime == ts)
                    {
                        setYellow(North);

                    }
                    if (North.turnRedTime == ts)
                    {
                        setRed(North);

                    }

                    if (East.turnRedTime == ts && ts != 0)
                    {
                        setRed(East);


                    }


                    if (West.turnRedTime == ts && ts != 0)
                    {
                        setRed(West);
                        setGreen(North);
                        setYellowTime(North, ts);

                    }

                    if (South.turnRedTime == ts && ts != 0)
                    {
                        setRed(South);
                        setGreen(East);
                        setYellowTime(East, ts);

                    }

                    if (North.turnYellowTime - 3 == ts)
                    {
                        setGreen(South);
                        setYellowTime(South, ts);

                    }

                    if (East.turnYellowTime == ts && ts != 3 && ts != 0)
                    {
                        setYellow(East);

                    }

                    if (East.turnYellowTime - 3 == ts && ts != 3)
                    {
                        setGreen(West);
                        setYellowTime(West, ts);

                    }

                    if (West.turnYellowTime == ts && ts != 0)
                    {
                        setYellow(West);

                    }

                    if (South.turnYellowTime == ts && ts != 0)
                    {
                        setYellow(South);

                    }

                    if (true)
                    {
                        var temp = (ts.ToString() + " " + displayColor(North) + " " + displayColor(South) + " " + displayColor(East) + " " + displayColor(West));
                        if (temp != prevString)
                        {
                            Console.WriteLine(temp);
                            prevString = temp;
                        }

                    }
                }


                ts = stopWatch.Elapsed.Seconds;
            }

            stopWatch.Stop();
        }
        //display the color that is appearing
        private string displayColor(TrafficLight light)
        {
            if (light.isGreen)
            {
                return "Green";
            }
            else if (light.isYellow)
            {
                return "Yellow";
            }
            else
            {
                return "Red";
            }
        }

        private void setYellowTime(TrafficLight light, int time)
        {
            light.turnYellowTime = 9 + time;
            light.turnRedTime = 12 + time;
        }

        private void setRed(TrafficLight light)
        {
            light.isRed = true;
            light.isYellow = false;
            light.isGreen = false;
            updateLight(light);

        }
        //set the colors
        private void setYellow(TrafficLight light)
        {
            light.isRed = false;
            light.isYellow = true;
            light.isGreen = false;
            updateLight(light);

        }

        private void setGreen(TrafficLight light)
        {
            light.isRed = false;
            light.isYellow = false;
            light.isGreen = true;
            updateLight(light);
        }
       //update light colors
        public void updateLight(TrafficLight light)
        {
            switch (light.Name)
            {
                case "North":
                    GreenNorth.Visible = light.isGreen;
                    RedNorth.Visible = light.isRed;
                    YellowNorth.Visible = light.isYellow;
                    break;
                case "South":
                   GreenSouth.Visible = light.isGreen;
                    RedSouth.Visible = light.isRed;
                    YellowSouth.Visible = light.isYellow;
                    break;
                case "East":
                    GreenEast.Visible = light.isGreen;
                    RedEast.Visible = light.isRed;
                    YellowEast.Visible = light.isYellow;
                    break;
                case "West":
                    GreenWest.Visible = light.isGreen;
                    RedWest.Visible = light.isRed;
                    YellowWest.Visible = light.isYellow;
                   break;
               default:
                    break;
            }
        }
        //close form
        private void StopButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
