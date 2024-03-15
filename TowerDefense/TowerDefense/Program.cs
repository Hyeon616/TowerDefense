using TowerDefense.Map;
using TowerDefense.Unit;

namespace TowerDefense
{
    internal class Program
    {
        public static void Spa(Enemy enemy)
        {
            Movement.Movement.EnemyMove(enemy);
        }


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Player player = new Player();

            List<Enemy> enemyList = new List<Enemy>();
            Enemy enemy1 = new Enemy(0);
            Enemy enemy2 = new Enemy(1);
            Enemy enemy3 = new Enemy(2);
            Enemy enemy4 = new Enemy(3);
            Enemy enemy5 = new Enemy(4);
            Enemy enemy6 = new Enemy(5);
            Enemy enemy7 = new Enemy(6);


            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Maps.PrintMap(player, enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Movement.Movement.Input(keyInfo, player);
                }

                Spa(enemy1);
                Spa(enemy2);
                Spa(enemy3);
                Spa(enemy4);


                //Maps.RenderingMap(player, enemy);
                //Maps.MoveObject(player, enemy);


                




            }
        }
    }
}
