using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.Utils;
using TowerDefense.Character.MoveEnemy;
using System;
using System.Collections.Generic;

namespace TowerDefense.Character.EnemySpawn
{
    internal class EnemySpawner
    {

        public static WaveTimer waveTimer = new WaveTimer(10, 0, 1000);
        public static MissionTimer missionTimer = new MissionTimer(0, 0, 1000);
        public static List<Enemy> enemies = new List<Enemy>();
        public static Enemy enemy;
        public static List<MissionEnemy> missionEnemies = new List<MissionEnemy>();

        public static int level = 0;
        public static int id = 1;

        

        public static void AddEnemy()
        {
            if (enemies.Count < 4 && waveTimer.Count < 1)
            {
                int enemyHp = 100 + (level - 1) * 50;

                enemy = new Enemy(0,0,id,enemyHp);
                
                //enemies.Add(new Enemy(0, 0, id, enemyHp));

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
                 Console.SetCursorPosition(29, 27);;
                Console.WriteLine("이미 소환되어 있습니다.");
            }
            else if (missionTimer.Count > 0)
            {
                 Console.SetCursorPosition(29, 27);;
                Console.WriteLine("아직 미션시간이 쿨타임이 남아있습니다.");
            }

        }

    }
}
