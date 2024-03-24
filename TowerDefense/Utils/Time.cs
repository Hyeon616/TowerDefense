using System.Timers;
using TowerDefense.Character.EnemySpawn;
using TowerDefense.Character.PlayerInput;

namespace TowerDefense.Utils
{
    public class Time
    {
        public int Count { get; set; }
        public int Countdown { get; set; }
        public System.Timers.Timer setTimer { get; set; }

        public void StartTimer()
        {
            setTimer.Start();
        }

        public void StopTimer()
        {
            setTimer.Stop();
        }

    }

    class WaveTimer : Time
    {
        public WaveTimer(int count, int countdown, int time)
        {
            Count = count;
            Countdown = countdown;

            setTimer = new System.Timers.Timer(time);
            setTimer.Elapsed += CheckWaveTime;
            setTimer.AutoReset = true;
            setTimer.Enabled = true;
        }
        private void CheckWaveTime(object source, ElapsedEventArgs e)
        {
            if (EnemySpawner.enemies.Count == 0)
            {
                Count--;

            }

            if (EnemySpawner.enemies.Count > 0)
            {
                Count = 30;

            }

            if (Count == 0)
            {
                Input.player.Money += 200;
                EnemySpawner.level += 1;

            }
        }
    }

    class MissionTimer : Time
    {


        public MissionTimer(int count, int countdown, int time)
        {
            Count = count;
            Countdown = countdown;

            setTimer = new System.Timers.Timer(time);
            setTimer.Elapsed += CheckMissionTime;
            setTimer.AutoReset = true;
            setTimer.Enabled = true;
        }
        private void CheckMissionTime(object source, ElapsedEventArgs e)
        {
            if (Count > 0)
            {
                Count--;

            }
            else
            {
                Count = 0;
            }

            if (EnemySpawner.missionEnemies.Count > 0)
            {

                Count = 40;

            }

        }
    }

    class AttackTimer : Time
    {
        public AttackTimer(int count, int countdown, int time)
        {
            Count = count;
            Countdown = countdown;

            setTimer = new System.Timers.Timer(time);
            setTimer.Elapsed += TowerAttacktime;
            setTimer.AutoReset = true;
            setTimer.Enabled = true;
        }
        private void TowerAttacktime(object source, ElapsedEventArgs e)
        {
            if (Count > 0)
            {
                Count--;

            }
            else if (Count < 0)
            {
                Count = 1;

            }

        }
    }

}
