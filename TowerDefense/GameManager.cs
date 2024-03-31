<<<<<<< Updated upstream
﻿using TowerDefense.Control;
=======
﻿using TowerDefense.Character;
using TowerDefense.Character.EnemySpawn;
using TowerDefense.Character.MoveEnemy;
using TowerDefense.Character.PlayerInput;
>>>>>>> Stashed changes
using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.Spawner;
using TowerDefense.TowerManager;
using TowerDefense.Utils;
using Timer = System.Timers.Timer;

namespace TowerDefense
{
    internal class GameManager
    {
<<<<<<< Updated upstream
=======

        private static GameManager instance;
        private UI ui;
        private Player player;
        private EnemySpawner enemySpawner;
        private List<Enemy> enemies;
        private List<MissionEnemy> missionEnemies;
        private RandomTower randomTower;
        private WaveTimer waveTimer;
        private MissionTimer missionTimer;
        private Timer spawnTimer;

        public int level = 1;
        public int id = 1;

        public GameManager()
        {
            ui = new UI();
            enemySpawner = new EnemySpawner();
            waveTimer = new WaveTimer(60, 0, 1000);
            missionTimer = new MissionTimer(0, 0, 1000);
            enemies = new List<Enemy>();
            missionEnemies = new List<MissionEnemy>();
            randomTower = new RandomTower();

        }

        public static GameManager GetInstance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }

>>>>>>> Stashed changes
        public static void Menu()
        {
            while (true)
            {

                Console.SetCursorPosition(0, 0);
                UI.MainMenu();
                Input.GameMenuInput();

                if (Input.gameStart > 0)
                {
                    Console.Clear();
                    break;
                }
                    

            }

        }


        public static void GameStart()
        {

<<<<<<< Updated upstream
=======
            StartEnemySpawn();

            StartEnemyMovement();



            instance.randomTower.StartAttackTimer(instance.enemies, instance.missionEnemies);


>>>>>>> Stashed changes
            while (true)
            {

                
                Maps.PrintMap(Input.player, EnemySpawner.enemies,EnemySpawner.missionEnemies);

<<<<<<< Updated upstream
                UI.DrawLine();
                UI.PlayerUI(Input.player);
                UI.EnemyHpUI(EnemySpawner.enemies);
                UI.EnemyHpUI(EnemySpawner.missionEnemies);
                UI.WaveTimeUI(EnemySpawner.waveTimer);
                UI.MissionTimeUI(EnemySpawner.missionTimer);

=======
                instance.ui.DrawLine();

                UI.UpgradeUI();
                UI.TutorialUI();
                UI.LevelUI();
                UI.PlayerUI(instance.player);
                UI.EnemyHpUI(instance.enemies);
                UI.EnemyHpUI(instance.missionEnemies);
                UI.MissionTimeUI(instance.missionTimer);

                //sb.Clear();


                Maps.PrintMap(Input.player, instance.enemies, instance.missionEnemies);
                UI.WaveTimeUI(instance.waveTimer);
                //Maps.MapStringBuilderBuffer(sb);



                //UI.GetWaveTimeUI(sb);

                //UI.ProcessUI();
>>>>>>> Stashed changes

                EnemySpawner.AddEnemy();

                Input.GamePlayInput(Input.player);
                
                RandomTower.TowerAttack();

                EnemyMovement.EnemyMove(EnemySpawner.enemies, EnemySpawner.missionEnemies);

            }


        }


        



        public static void StartEnemySpawn()
        {

            instance.spawnTimer = new Timer(200);
            instance.spawnTimer.Elapsed += (sender, e) => AddEnemy();
            instance.spawnTimer.AutoReset = true;
            instance.spawnTimer.Enabled = true;
        }

        public static void AddEnemy()
        {

            if (instance.enemies.Count < 4 && instance.waveTimer.Count < 1)
            {
                int enemyHp = 30 + (instance.level - 1) * 12;

                instance.enemies.Add(new Enemy(0, 0, instance.id, enemyHp));

                instance.id++;

                if (instance.id == 5)
                    instance.id = 1;
            }

        }

        public static void AddMissionEnemy(int hp, int money, Maps.MapState missionEnemyName)
        {
            if (instance.missionEnemies.Count < 1 && instance.missionTimer.Count <= 0)
            {
                instance.missionEnemies.Add(new MissionEnemy(0, 0, hp, money, missionEnemyName));

            }
            else if (instance.missionEnemies.Count > 0)
            {
                UI.AlertUIPosition();
                Console.WriteLine("이미 소환되어 있습니다.");
            }
            else if (instance.missionTimer.Count > 0)
            {
                UI.AlertUIPosition();
                Console.WriteLine("아직 미션시간이 쿨타임이 남아있습니다.");
            }

        }





    }
}
