using TowerDefense.Map;
using TowerDefense.RandomTower;
using TowerDefense.Spawner;
using TowerDefense.Unit;

namespace TowerDefense.Control
{
    internal class Movement
    {
        private static bool IsMoveValid(int x, int y)
        {
            return x >= 0 && x < Maps.mapWidth && y >= 0 && y < Maps.mapHeight;
        }
        
        public static Player player = new Player(5, 5);

        public static void Input(ConsoleKeyInfo keyInfo, Player player, List<Tower> towerLevel)
        {
            // 입력 처리
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
                // 타워 건설
                case ConsoleKey.Enter:
                    if (Maps.map[player.X, player.Y] == 1 && player.Money > 99)
                    {
                        switch (SetTower.BuildTowerNumber())
                        {
                            case (int)Maps.MapState.STAR:
                                Maps.map[player.X, player.Y] = 2;
                                SetTower.towerGroup.Add(new Tower(player.X, player.Y, 10, 1000));

                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("별 타워 건설                    ");
                                player.Money -= 100;
                                break;
                            case (int)Maps.MapState.SPADE:
                                Maps.map[player.X, player.Y] = 3;
                                SetTower.towerGroup.Add(new Tower(player.X, player.Y, 10, 2000));
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("스페이드 타워 건설                    ");
                                player.Money -= 100;
                                break;
                            case (int)Maps.MapState.MUSIC:
                                Maps.map[player.X, player.Y] = 4;
                                SetTower.towerGroup.Add(new Tower(player.X, player.Y, 10, 1000));
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("음악 타워 건설                    ");
                                player.Money -= 100;
                                break;
                            case (int)Maps.MapState.LASOR:
                                Maps.map[player.X, player.Y] = 5;
                                SetTower.towerGroup.Add(new Tower(player.X, player.Y, 10, 2000));
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("레이저 타워 건설                    ");
                                player.Money -= 100;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (Maps.map[player.X, player.Y] == 1 && player.Money < 100)
                    {
                        Console.SetCursorPosition(15, 16);
                        Console.WriteLine("금액이 부족해 건설할 수 없습니다.");
                        break;
                    }
                    else if (Maps.map[player.X, player.Y] == 0)
                    {
                        Console.SetCursorPosition(15, 16);
                        Console.WriteLine("거기는 건설할 수 없습니다.            ");
                        break;
                    }
                    break;
                // 타워 판매
                case ConsoleKey.Z:
                    if (Maps.map[player.X, player.Y] != 0 && Maps.map[player.X, player.Y] != 1)
                    {
                        Maps.map[player.X, player.Y] = 1;
                        Console.SetCursorPosition(15, 16);
                        Console.WriteLine("타워를 판매했습니다.");
                        player.Money += 50;
                    }
                    break;
                // 타워 업그레이드
                case ConsoleKey.Q:

                    break;
            }

        }


        public static bool moveCheck1 = true;
        public static bool moveCheck2 = true;
        public static bool moveCheck3 = true;


        public static void EnemyMove(Player player, List<Enemy> enemies)
        {
            List<Enemy> arrivedEnemy = new List<Enemy>();
            if (EnemySpawner.enemies.Count != 0)
            {
                Thread.Sleep(200);

                foreach (var enemy in enemies)
                {
                    if (IsMoveValid(enemy.X, enemy.Y))
                    {
                        // 4,0 까지
                        if (enemy.X < 4 && enemy.Y == 0)
                        {
                            ++enemy.X;

                        }
                        // 4, 11 까지
                        else if (enemy.X == 4 && enemy.Y < 11 && moveCheck1)
                        {
                            ++enemy.Y;

                        }
                        // 0, 11 까지
                        else if (enemy.X > 0 && enemy.Y == 11 && enemy.X < 5)
                        {
                            --enemy.X;

                            if (enemy.X == 0 && enemy.Y == 11)
                                moveCheck1 = false;
                        }
                        // 0,7 까지
                        else if (enemy.X == 0 && enemy.Y > 7)
                        {
                            --enemy.Y;

                        }
                        // 11, 7까지
                        else if (enemy.X < 11 && enemy.Y == 7 && moveCheck2)
                        {
                            ++enemy.X;

                        }
                        //11,11
                        else if (enemy.X == 11 && enemy.Y < 11 && enemy.Y > 6)
                        {
                            enemy.Y++;

                        }
                        // 7,11
                        else if (enemy.X > 7 && enemy.Y == 11)
                        {
                            enemy.X--;

                            if (enemy.X == 7 && enemy.Y == 11)
                                moveCheck2 = false;

                        }
                        //7 ,0
                        else if (enemy.X == 7 && enemy.Y > 0 && moveCheck3)
                        {
                            enemy.Y--;
                        }
                        // 11,0
                        else if (enemy.X < 11 && enemy.Y == 0)
                        {
                            enemy.X++;

                        }
                        ////11,4
                        else if (enemy.X == 11 && enemy.Y < 4)
                        {
                            enemy.Y++;

                            if (enemy.X == 11 && enemy.Y == 4)
                                moveCheck3 = false;

                        }
                        ////0,4
                        else if (enemy.X > 0 && enemy.Y == 4)
                        {
                            enemy.X--;
                        }


                    }
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}        ");


                    if (enemy.X == 0 && enemy.Y == 4)
                    {
                        for (int i = 0; i < EnemySpawner.enemies.Count; i++)
                        {
                            arrivedEnemy.Add(enemy);
                        }
                    }
                }

                foreach (var i in arrivedEnemy)
                {
                    EnemySpawner.enemies.Remove(i);
                    player.Hp -= 1;
                }

            }


        }

    }

}


