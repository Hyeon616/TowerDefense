using System.Timers;
using TowerDefense.Control;
using TowerDefense.Unit;

namespace TowerDefense.Spawner
{
    internal class EnemySpawner
    {
        public static System.Timers.Timer SpawnTime = new System.Timers.Timer();
        public static RoundTime roundTime = new RoundTime(60, 0, 500);

        public static List<Enemy> enemies = new List<Enemy>();

        public static int level = 1;
        public static int count = 0;
        public static void Spawn()
        {
            SpawnTime.Elapsed += AddEnemy;
            SpawnTime.Interval = 200; // 1초마다
            SpawnTime.AutoReset = true; // 타이머가 자동으로 재시작되도록 설정
            SpawnTime.Enabled = true; // 타이머 활성화

        }


        public static void StopSpawn()
        {
            SpawnTime.Stop();
        }

        private static void AddEnemy(object sender, ElapsedEventArgs e)
        {

            if (level == 1 && roundTime.Count < 4 && enemies.Count < 4)
            {
                enemies.Add(new Enemy(0, 0, 100));
            }
            else if(enemies.Count ==0)
            {
                Movement.moveCheck1 = true;
                Movement.moveCheck2 = true;
                Movement.moveCheck3 = true;
            }

        }

    }
}
