using TowerDefense.Control;
using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.Spawner;
using TowerDefense.TowerManager;
using TowerDefense.Unit;

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

            }
            
        }




        public static void GameStart()
        {
            

            
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Maps.PrintMap(Input.player, EnemySpawner.enemies);

                UI.PlayerUI(Input.player);
                UI.EnemyHpUI(EnemySpawner.enemies);
                UI.WaveTimeUI(EnemySpawner.waveTimer);


                EnemySpawner.AddEnemy();

                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(0, 30);
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Input.PlayerInput(keyInfo, Input.player, RandomTower.towerGroup);
                    
                }
                
                RandomTower.TowerAttack();

                

                EnemyMovement.EnemyMove(Input.player, EnemySpawner.enemies);

            }


        }


    }
}
