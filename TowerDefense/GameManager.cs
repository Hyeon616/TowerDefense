
using System;
using TowerDefense.Character;
using TowerDefense.Character.EnemySpawn;
using TowerDefense.Character.PlayerInput;
using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.TowerManager;

namespace TowerDefense
{
    internal class GameManager
    {
        private UI ui;
        private static GameManager instance;


        public GameManager()
        {
            ui = new UI();
        }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void Menu()
        {
            while (true)
            {

                Console.SetCursorPosition(0, 0);
                ui.MainMenu();
                Input.GameMenuInput();

                if (Input.gameStart > 0)
                {
                    Console.Clear();
                    break;
                }

            }

        }


        public void GameStart()
        {

            EnemySpawner.AddEnemy();
            Enemy enemy1 = new Enemy(0, 0, 5, 500);
            //Enemy.SetupTimer(enemy1, 1000);
            enemy1.EnemyMove();
            while (true)
            {


                Maps.PrintMap(Input.player, enemy1, EnemySpawner.missionEnemies);
                ui.DrawLine();
                ui.PlayerUI(Input.player);
                ui.EnemyHpUI(EnemySpawner.enemies);
                ui.EnemyHpUI(EnemySpawner.missionEnemies);
                ui.WaveTimeUI(EnemySpawner.waveTimer);
                ui.MissionTimeUI(EnemySpawner.missionTimer);
                ui.UpgradeUI();
                ui.TutorialUI();
                ui.LevelUI();
                // ui.ProcessUI();




                if (EnemySpawner.enemy != null)
                {
                    EnemySpawner.enemy.EnemyMove();

                }

                Input.GamePlayInput(Input.player);

                RandomTower.TowerAttack();




            }


        }


    }
}
