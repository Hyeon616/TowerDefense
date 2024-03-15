using TowerDefense.Unit;
using TowerDefense.Map;
using TowerDefense.RandomTower;

namespace TowerDefense.Movement
{
    internal class Movement
    {
        static bool IsMoveValid(int x, int y)
        { 
            return x >= 0 && x < Maps.mapWidth && y >= 0 && y < Maps.mapHeight;
        }


        public static void Input(ConsoleKeyInfo keyInfo, Player player)
        {
            // 이동 처리
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (IsMoveValid(player.X - 1, player.Y))
                    {
                        player.X--;
                        Console.SetCursorPosition(player.X, player.Y);
                        Console.Write($"{Maps.playerImage}");
                    }

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
                case ConsoleKey.Enter:
                    if (Maps.map[player.X, player.Y] == 1)
                    {
                        switch (RandomTower.RandomTower.BuildTowerNumber())
                        {
                            case (int)Maps.MapState.STAR:
                                Maps.map[player.X, player.Y] = 2;
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("별 타워 건설                    ");
                                break;
                            case (int)Maps.MapState.SPADE:
                                Maps.map[player.X, player.Y] = 3;
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("스페이드 타워 건설                    ");
                                break;
                            case (int)Maps.MapState.MUSIC:
                                Maps.map[player.X, player.Y] = 4;
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("음악 타워 건설                    ");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(15, 16);
                        Console.WriteLine("거기는 건설할 수 없습니다.");
                        break;
                    }
                    break;
            }

        }

        static bool moveCheck1 = true;
        static bool moveCheck2 = true;
        static bool moveCheck3 = true;
        static bool moveCheck4 = true;
        static bool moveCheck5 = true;
        static bool moveCheck6 = true;
        static bool moveCheck7 = true;
        static bool moveCheck8 = true;
        static bool moveCheck9 = true;
        static bool moveCheck10 = true;
        static bool moveCheck11 = true;

        

        public static void EnemyMove(Enemy enemy)
        {
            Thread.Sleep(300);

            // 4,0 까지
            if (IsMoveValid(enemy.X, enemy.Y) && enemy.X < 4 && enemy.Y == 0 && moveCheck1)
            {
                enemy.X++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 4 && enemy.Y == 0)
                    moveCheck1 = false;
            }
            // 4, 11 까지
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X == 4 && enemy.Y < 11 && moveCheck2)
            {
                enemy.Y++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 4 && enemy.Y == 11)
                {
                    moveCheck1 = true;
                    moveCheck2 = false;
                }
            }
            // 0, 11 까지
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X > 0 && enemy.Y == 11 && moveCheck3)
            {
                enemy.X--;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 0 && enemy.Y == 11)
                {
                    moveCheck2 = true;
                    moveCheck3 = false;
                }
            }

            // 0,7 까지
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X == 0 && enemy.Y > 7 && moveCheck4)
            {
                enemy.Y--;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 0 && enemy.Y == 7)
                {
                    moveCheck3 = true;
                    moveCheck4 = false;
                }
            }
            // 11, 7까지
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X < 11 && enemy.Y == 7 && moveCheck5)
            {
                enemy.X++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 11 && enemy.Y == 7)
                {
                    moveCheck4 = true;
                    moveCheck5 = false;
                }
            }
            //11,11
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X == 11 && enemy.Y < 11 && moveCheck6)
            {
                enemy.Y++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 11 && enemy.Y == 11)
                {
                    moveCheck5 = true;
                    moveCheck6 = false;
                }
            }
            // 7,11
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X > 7 && enemy.Y == 11 && moveCheck7)
            {
                enemy.X--;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 7 && enemy.Y == 11)
                    moveCheck7 = false;
            }
            //7 ,0
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X == 7 && enemy.Y > 0 && moveCheck8)
            {
                enemy.Y--;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 7 && enemy.Y == 0)
                    moveCheck8 = false;
            }
            // 11,0
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X < 11 && enemy.Y == 0 && moveCheck9)
            {
                enemy.X++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 11 && enemy.Y == 0)
                    moveCheck9 = false;
            }
            //11,4
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X == 11 && enemy.Y < 4 && moveCheck10)
            {
                enemy.Y++;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 11 && enemy.Y == 4)
                    moveCheck10 = false;
            }
            //0,4
            else if (IsMoveValid(enemy.X, enemy.Y) && enemy.X > 0 && enemy.Y == 4 && moveCheck11)
            {
                enemy.X--;
                Console.SetCursorPosition(15, 15);
                Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}");
                if (enemy.X == 0 && enemy.Y == 4)
                    moveCheck11 = false;
            }
        }

    }



}

