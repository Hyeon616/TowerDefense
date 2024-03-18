using TowerDefense.Map;
using TowerDefense.RandomTower;
using TowerDefense.Spawner;
using TowerDefense.Unit;
using TowerDefense.Control;

namespace TowerDefense
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 30);


            EnemySpawner.Spawn();


            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Maps.PrintMap(Movement.player, EnemySpawner.enemies);
                
                UI.PlayerUI(Movement.player);
                UI.EnemyHpUI(EnemySpawner.enemies);
                UI.WaveTimeUI(EnemySpawner.roundTime);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Movement.Input(keyInfo, Movement.player, SetTower.towerGroup);
                }

                foreach (Tower tower in SetTower.towerGroup)
                {
                    tower.StartAttack();
                }

                Movement.EnemyMove(Movement.player, EnemySpawner.enemies);
               

            }
        }






    }
}
