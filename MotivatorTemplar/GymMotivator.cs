using System;
using System.Configuration;

namespace MotivatorTemplar
{
    class GymMotivator
    {
        DateTime clavicleBreakDate;

        //Config needed to grab values from app.config
        Int32 deadlift;
        Int32 squat;
        Int32 bench;
        Int32 shoulder;
        Int32 clean;

        Configuration config; //needed for saving?

        public GymMotivator()
        {
            clavicleBreakDate = new DateTime(2014, 8, 30);
            deadlift = Convert.ToInt32(ConfigurationManager.AppSettings["Deadlift"]);
            squat = Convert.ToInt32(ConfigurationManager.AppSettings["Squat"]);
            bench = Convert.ToInt32(ConfigurationManager.AppSettings["Bench"]);
            shoulder = Convert.ToInt32(ConfigurationManager.AppSettings["Shoulder"]);
            clean = Convert.ToInt32(ConfigurationManager.AppSettings["Clean"]);

            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string configFile = System.IO.Path.Combine(appPath, "App.config");
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;
            config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
        }

        //Figure this shit out
    
        public void setDeadlift(int lifted)
        {
        }

        public void setSquat(int lifted)
        {

        }

        public void setBench(int lifted)
        {

        }

        public void setShoulder(int lifted)
        {

        }

        public void setClean(int lifted)
        {

        }
    }
}
