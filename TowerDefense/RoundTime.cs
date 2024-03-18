using System.Runtime.CompilerServices;
using System;
using System.Timers;

namespace TowerDefense
{
    public class RoundTime
    {
        public int Count { get; set; }
        public int Countdown { get; set; }
        public System.Timers.Timer roundTimer { get; set; }


        public RoundTime(int count, int countdown, int time)
        {
            Count = count;
            Countdown = countdown;

            roundTimer = new System.Timers.Timer(time);
            roundTimer.Elapsed += CheckWaveTime;
            roundTimer.AutoReset = true;
            roundTimer.Enabled = true;
        }

        public void StartTimer()
        {
            roundTimer.Start();
        }

        public void StopTimer()
        {
            roundTimer.Stop();
        }

        private void CheckWaveTime(object source, ElapsedEventArgs e)
        {
            Count++;

            if (Count > 20)
            {
                Count = 0;
            }


        }



    }


}
