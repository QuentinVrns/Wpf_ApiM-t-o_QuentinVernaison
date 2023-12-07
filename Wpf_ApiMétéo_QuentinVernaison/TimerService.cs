using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Wpf_ApiMétéo_QuentinVernaison
{
    internal class TimerService
    {
        
            public MainWindow mainwindow { get; set; }

            public void Timer()
            {
                // Faire un timer qui s'actualise toutes les 10 minutes pour actualiser la météo
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMinutes(10);
                timer.Tick += mainwindow.Timer_Tick;
                timer.Start();

            }
        
    }
}
