
using TowerDefense.Character.EnemySpawn;
using TowerDefense.Character.MoveEnemy;
using TowerDefense.Character.PlayerInput;
using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.TowerManager;

namespace TowerDefense
{
    internal class GameManager
    {

        static readonly object consoleLock = new object();

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

            EnemySpawner.StartEnemySpawn();


            EnemyMovement.StartEnemyMovement();



            RandomTower.StartAttackTimer();




            while (true)
            {

                Maps.PrintMap(Input.player, EnemySpawner.enemies, EnemySpawner.missionEnemies);

                UI.DrawLine();
                UI.PlayerUI(Input.player);
                UI.EnemyHpUI(EnemySpawner.enemies);
                UI.EnemyHpUI(EnemySpawner.missionEnemies);
                UI.WaveTimeUI(EnemySpawner.waveTimer);
                UI.MissionTimeUI(EnemySpawner.missionTimer);
                UI.UpgradeUI();
                UI.TutorialUI();
                UI.LevelUI();



                //UI.ProcessUI();

                
                Input.GamePlayInput(Input.player);

                if (Input.player.Hp <= 0)
                {
                    Input.player.Hp = 0;
                    UI.AlertUIPosition();
                    Console.WriteLine("패배 하셨습니다.      ");
                    break;
                }


            }


        }


    }
}
