using Character;
using Map;
using MovePlayer;
using System;

namespace TowerDefense
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            

            Player player = new Player(5, 5);

            Enemy enemy = new Enemy(0, 0, 100);

            Maps.Map(player, enemy);

            while (true)
            {
                Movement.EnemyMove(enemy);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Movement.Input(keyInfo, player);
                }

                Console.SetCursorPosition(0, 0);
                Maps.Map(player, enemy);


            }
        }
    }
}
