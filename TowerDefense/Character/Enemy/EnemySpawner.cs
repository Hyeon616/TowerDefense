using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.Utils;
using Timer = System.Timers.Timer;

namespace TowerDefense.Character.EnemySpawn
{
    internal class EnemySpawner
    {

        public static WaveTimer waveTimer = new WaveTimer(60, 0, 1000);
        public static MissionTimer missionTimer = new MissionTimer(0, 0, 1000);
        private static Timer spawnTimer;


        //public static List<Enemy> enemies = new List<Enemy>();
        public static List<Enemy> enemies = new List<Enemy>();
        
        public static List<MissionEnemy> missionEnemies = new List<MissionEnemy>();

        public static int level = 1;
        public static int id = 1;

        

        public static void StartEnemySpawn()
        {
            
            spawnTimer = new Timer(200);
            spawnTimer.Elapsed += (sender, e) => AddEnemy();
            spawnTimer.AutoReset = true;
            spawnTimer.Enabled = true;
        }
        
        public static void AddEnemy()
        {
            
            if (enemies.Count < 4 && waveTimer.Count < 1)
            {
                int enemyHp = 30 + (level-1)  * 12;

                enemies.Add(new Enemy(0, 0, id, enemyHp));

                id++;

                if (id == 5)
                    id = 1;
            }
            
        }

        public static void AddMissionEnemy(int hp, int money, Maps.MapState missionEnemyName)
        {
            if (missionEnemies.Count < 1 && missionTimer.Count <= 0)
            {
                missionEnemies.Add(new MissionEnemy(0, 0, hp, money, missionEnemyName));
                
            }
            else if (missionEnemies.Count > 0)
            {
                UI.AlertUIPosition();
                Console.WriteLine("이미 소환되어 있습니다.");
            }
            else if (missionTimer.Count > 0)
            {
                UI.AlertUIPosition();
                Console.WriteLine("아직 미션시간이 쿨타임이 남아있습니다.");
            }

        }

    }
}
