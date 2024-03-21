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

        public static void GameStart()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 40);

            
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Maps.PrintMap(Input.player, EnemySpawner.enemies);

                UI.PlayerUI(Input.player);
                UI.EnemyHpUI(EnemySpawner.enemies);
                UI.WaveTimeUI(EnemySpawner.waveTimer);


                EnemySpawner.AddEnemy();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Input.PlayerInput(keyInfo, Input.player, TowerManager.RandomTower.towerGroup);
                }
                
                RandomTower.TowerAttack();

                

                EnemyMovement.EnemyMove(Input.player, EnemySpawner.enemies);

            }


        }


    }
}
