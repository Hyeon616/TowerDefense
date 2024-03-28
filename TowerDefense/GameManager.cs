using System.Text;
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

            StringBuilder sb = new StringBuilder();


            EnemySpawner.StartEnemySpawn();


            EnemyMovement.StartEnemyMovement();



            RandomTower.StartAttackTimer();
            

            while (true)
            {


                UI.DrawLine();

                UI.UpgradeUI();
                UI.TutorialUI();
                UI.LevelUI();
                UI.PlayerUI(Input.player);
                UI.EnemyHpUI(EnemySpawner.enemies);
                UI.EnemyHpUI(EnemySpawner.missionEnemies);
                UI.MissionTimeUI(EnemySpawner.missionTimer);

                //sb.Clear();


                Maps.PrintMap(Input.player, EnemySpawner.enemies, EnemySpawner.missionEnemies);
                UI.WaveTimeUI(EnemySpawner.waveTimer);
                //Maps.MapStringBuilderBuffer(sb);



                //UI.GetWaveTimeUI(sb);

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
