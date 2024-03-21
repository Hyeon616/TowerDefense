using System.Timers;
using TowerDefense.Spawner;
using TowerDefense.Control;
using TowerDefense.TowerManager;
using TowerDefense.Unit;

namespace TowerDefense.Cooldown
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
                Count = 10;
                
            }

            if(Count == 0)
            {
                Input.player.Money += 200;
                EnemySpawner.level += 1;
                
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
            if (Count >0)
            {
                Count--;

            }else if (Count < 0)
            {
                Count = 1;

            }

        }
    }

    class EnemyMoveTimer : Time
    {
        public EnemyMoveTimer(int count, int countdown, int time)
        {
            Count = count;
            Countdown = countdown;

            setTimer = new System.Timers.Timer(time);
            setTimer.Elapsed += EnemyMoveTime;
            //setTimer.AutoReset = true;
            setTimer.Enabled = true;
        }
        private void EnemyMoveTime(object source, ElapsedEventArgs e)
        {
            if (Count > 0)
            {
                Count--;

                EnemyMovement.EnemyMove(Input.player, EnemySpawner.enemies);
            }
            else if (Count < 0)
            {
                Count = 3;
                //EnemyMovement.EnemyMove(Input.player, EnemySpawner.enemies);
            }

        }
    }

}
