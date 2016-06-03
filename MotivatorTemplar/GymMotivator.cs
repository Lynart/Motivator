using System;
using MotivatorTemplar.Properties;

namespace MotivatorTemplar
{
    class GymMotivator
    {
        DateTime clavicleBreakDate;
        Int32 deadlift;
        Int32 squat;
        Int32 bench;
        Int32 shoulder;
        Int32 clean;

        public GymMotivator()
        {
            clavicleBreakDate = new DateTime(2014, 8, 30);

            deadlift = Settings.Default.Deadlift;
            squat = Settings.Default.Squat;
            bench = Settings.Default.Bench;
            shoulder = Settings.Default.Shoulder;
            clean = Settings.Default.Clean;
        }

        public String Stats()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~");
            String r0 = "You broke your clavicle on " + clavicleBreakDate.ToLongDateString() + "\n";
            String r1 = "Your stat points are:\n";
            String r2 = "Squat:    " + squat + '\n';
            String r3 = "Bench:    " + bench + '\n';
            String r4 = "Deadlift: " + deadlift + '\n';
            String r5 = "Shoulder: " + shoulder + '\n';
            String r6 = "Clean:    " + clean + '\n';

            return r0 + r1 + r2 + r3 + r4 + r5 + r6;
        }

        public void UpdateStats()
        {
            Console.WriteLine("Did you obliterate any records?!");
            String choice = Console.ReadLine().Trim().ToLower();
            if (choice == "yes" || choice == "y")
            {
                Console.WriteLine("What record did you demolish?");
                String input = Console.ReadLine().Trim().ToLower();
                do
                {
                    switch (input)
                    {
                        case "squat":
                            Console.WriteLine("How much did you power up?");
                            setSquat(Convert.ToInt32(Console.ReadLine().Trim()));
                            break;
                        case "bench":
                            Console.WriteLine("How much did you power up?");
                            setBench(Convert.ToInt32(Console.ReadLine().Trim()));
                            break;
                        case "deadlift":
                            Console.WriteLine("How much did you power up?");
                            setDeadlift(Convert.ToInt32(Console.ReadLine().Trim()));
                            break;
                        case "shoulder":
                            Console.WriteLine("How much did you power up?");
                            setShoulder(Convert.ToInt32(Console.ReadLine().Trim()));
                            break;
                        case "clean":
                            Console.WriteLine("How much did you power up?");
                            setClean(Convert.ToInt32(Console.ReadLine().Trim()));
                            break;
                        default:
                            Console.WriteLine("You made this app, stop making typos! (Squat, Bench, Deadlift, Shoulder, Clean)");
                            break;
                    }
                    Console.WriteLine("Any other puny records broken?!");
                    input = Console.ReadLine().Trim().ToLower();
                } while (input != "q" && input != string.Empty && input != "no" && input != "n");
            }
        }

        public void setDeadlift(int lifted)
        {
            Settings.Default.Deadlift = lifted;
            Settings.Default.Save();
        }

        public void setSquat(int lifted)
        {
            Settings.Default.Squat = lifted;
            Settings.Default.Save();
        }

        public void setBench(int lifted)
        {
            Settings.Default.Bench = lifted;
            Settings.Default.Save();
        }

        public void setShoulder(int lifted)
        {
            Settings.Default.Shoulder = lifted;
            Settings.Default.Save();
        }

        public void setClean(int lifted)
        {
            Settings.Default.Clean = lifted;
            Settings.Default.Save();
        }
    }
}
