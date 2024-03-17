using TowerDefense.Map;
using TowerDefense.Unit;

namespace TowerDefense
{
    internal class Program
    {
        


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(50, 30);


            Player player = new Player(5,5);

            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < 5; i++)
            {
                enemies.Add(new Enemy(0,0));
            }



            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Maps.PrintMap(player, enemies);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Movement.Movement.Input(keyInfo, player);
                }
                Movement.Movement.EnemyMove(enemies);
                
                //Spa(enemy2);
                //Spa(enemy3);
                //Spa(enemy4);


                //Maps.RenderingMap(player, enemy);
                //Maps.MoveObject(player, enemy);


                




            }
        }
    }
}
