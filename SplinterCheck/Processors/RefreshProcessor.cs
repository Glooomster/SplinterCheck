using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterCheck.Processors
{
    public class RefreshProcessor
    {
        public static int GetTimerSeconds(int SelectedCmbRefresh)

        {

            int timerTicker = 0;

            if (SelectedCmbRefresh == 0)
            {
                timerTicker = 60;
            }
            else if (SelectedCmbRefresh == 1)
            {
                timerTicker = 300;
            }
            else if (SelectedCmbRefresh == 2)
            {
                timerTicker = 600;
            }
            else if (SelectedCmbRefresh == 3)
            {
                timerTicker = 1800;
            }
            else if (SelectedCmbRefresh == 4)
            {
                timerTicker = 3600;
            }

            return timerTicker;

        }

    }


}
