using TowerDefense.Control;
using TowerDefense.Cooldown;
using TowerDefense.Unit;

namespace TowerDefense.Spawner
{
    internal class EnemySpawner
    {

        public static WaveTimer waveTimer = new WaveTimer(10, 0, 1000);
        public static List<Enemy> enemies = new List<Enemy>();

        public static int level = 0;
        public static int id = 1;

        public static void AddEnemy()
        {
            if (enemies.Count < 4 && waveTimer.Count < 1)
            {
                int enemyStrength = 100 + (level - 1) * 50;

                enemies.Add(new Enemy(0, 0, id, enemyStrength));

                id++;

                if (id == 5)
                    id = 1;
            }
            if (enemies.Count == 0)
            {

                EnemyMovement.moveCheck1 = true;
                EnemyMovement.moveCheck2 = true;
                EnemyMovement.moveCheck3 = true;
            }

        }

    }
}
