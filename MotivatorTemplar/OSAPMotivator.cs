using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivatorTemplar
{
    class OSAPMotivator
    {
        //OSAP variables
        DateTime beginning; //date of graduation
        DateTime osapEnd; //goal date
        Int32 totalDays; //total days between beginning to OSAP goal date


        DateTime today;
        Int32 daysCompleted; //how many days left
        Decimal result; //percentage

        public OSAPMotivator()
        {
            beginning = new DateTime(2016, 5, 2);
            osapEnd = new DateTime(2019, 11, 2);
            totalDays = (Int32)Math.Floor((osapEnd - beginning).TotalDays);

            today = DateTime.Now;
            daysCompleted = (Int32)Math.Floor((today - beginning).TotalDays);
            result = ((Decimal)daysCompleted / (Decimal)totalDays);
        }

        public String Status()
        {
            Int32 percentageComplete = ((Int32)Math.Round(result * 100));
            String addOnMsg; //For milestones!
            if(percentageComplete>25 && percentageComplete<50) {
                addOnMsg = "You've hit your first milestone!";
            }
            return "You are " + percentageComplete + "% of the way to completing your OSAP payments!";
        }
    }
}
