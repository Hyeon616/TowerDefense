using Character;
using Map;

namespace MovePlayer
{
    internal class Movement
    {
        static bool IsMoveValid(int x, int y)
        {
            return x >= 0 && x < Maps.mapWidth && y >= 0 && y < Maps.mapHeight;
        }

        public static void Move(ConsoleKeyInfo keyInfo, Player player)
        {
            // 이동 처리
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (IsMoveValid(player.X - 1, player.Y))
                        player.X--;
                    break;
                case ConsoleKey.DownArrow:
                    if (IsMoveValid(player.X + 1, player.Y))
                        player.X++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (IsMoveValid(player.X, player.Y - 1))
                        player.Y--;
                    break;
                case ConsoleKey.RightArrow:
                    if (IsMoveValid(player.X, player.Y + 1))
                        player.Y++;
                    break;
            }

        }



        public static void EnemyMove(Enemy enemy)
        {
            Thread.Sleep(500);

            if (IsMoveValid(enemy.X, enemy.Y) && enemy.X < 4 &&enemy.Y==0)
            {
                enemy.X++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
            }
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X == 4 && enemy.Y < 11)
            {
                enemy.Y++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
            }
            else if (IsMoveValid(enemy.X , enemy.Y) && enemy.X > 0 && enemy.Y == 11)
            {
                enemy.X--;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
            }
            


        }

    }



}

