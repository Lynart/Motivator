﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivatorTemplar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Your motivator!***");
            Console.WriteLine("Version 1.00\n");
            Console.WriteLine("Who the hell do you think you are?\n");

            OSAPMotivator oMotivator = new OSAPMotivator();
            Console.WriteLine(oMotivator.Status());
            Console.WriteLine("Now smile and get the fuck out there!\nYour drill is the drill that will pierce the heavens!");
            Console.ReadLine();
        }
    }
}
