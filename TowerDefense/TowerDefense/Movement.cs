using Character;
using Map;
using System.Threading;

namespace MovePlayer
{
    internal class Movement
    {
        static bool IsMoveValid(int x, int y)
        {
            return x >= 0 && x < Maps.map.GetLength(0) && y >= 0 && y < Maps.map.GetLength(1);
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

            if (IsMoveValid(enemy.X, enemy.Y + 1))
                enemy.Y++;
            else if (IsMoveValid(enemy.X - 1, enemy.Y))
                enemy.X++;
            else if (IsMoveValid(enemy.X + 1, enemy.Y))
                enemy.X++;
            else if (IsMoveValid(enemy.X, enemy.Y - 1))
                enemy.Y--;
            else
                return;
            
        }

    }



}

