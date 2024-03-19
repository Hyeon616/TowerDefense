using TowerDefense.Map;
using TowerDefense.Unit;
using TowerDefense.TowerManager;

namespace TowerDefense.Control
{
    internal class Input
    {
        
        public static Player player = new Player(5, 5);

        public static void PlayerInput(ConsoleKeyInfo keyInfo, Player player, List<Tower> towerLevel)
        {
            // 입력 처리
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (player.IsMoveValid(player.X - 1, player.Y))
                        player.X--;
                    break;
                case ConsoleKey.DownArrow:
                    if (player.IsMoveValid(player.X + 1, player.Y))
                        player.X++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (player.IsMoveValid(player.X, player.Y - 1))
                        player.Y--;
                    break;
                case ConsoleKey.RightArrow:
                    if (player.IsMoveValid(player.X, player.Y + 1))
                        player.Y++;
                    break;
                // 타워 건설
                case ConsoleKey.Enter:
                    if (Maps.map[player.X, player.Y] == 1 && player.Money > 99)
                    {
                        switch (RandomTower.BuildTowerNumber())
                        {
                            case (int)Maps.MapState.NORMALSTAR:
                                RandomTower.SpawnTower(Maps.MapState.NORMALSTAR, 10, 1000,1);
                                break;
                            case (int)Maps.MapState.NORMALSPADE:
                                RandomTower.SpawnTower(Maps.MapState.NORMALSPADE, 10, 1000, 1);
                                break;
                            case (int)Maps.MapState.NORMALMUSIC:
                                RandomTower.SpawnTower(Maps.MapState.NORMALMUSIC, 10, 1000, 1);
                                break;
                            case (int)Maps.MapState.NORMALLASOR:
                                RandomTower.SpawnTower(Maps.MapState.NORMALLASOR, 10, 1000, 1);
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

        


    }
}


