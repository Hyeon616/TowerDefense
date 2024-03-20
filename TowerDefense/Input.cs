using TowerDefense.Map;
using TowerDefense.TowerManager;
using TowerDefense.Unit;

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
                                RandomTower.TowerSpawn(Maps.MapState.NORMALSTAR, 10, 1000, 1);
                                break;
                            case (int)Maps.MapState.NORMALSPADE:
                                RandomTower.TowerSpawn(Maps.MapState.NORMALSPADE, 10, 1000, 1);
                                break;
                            case (int)Maps.MapState.NORMALHEART:
                                RandomTower.TowerSpawn(Maps.MapState.NORMALHEART, 10, 1000, 1);
                                break;
                            case (int)Maps.MapState.NORMALLASOR:
                                RandomTower.TowerSpawn(Maps.MapState.NORMALLASOR, 10, 1000, 1);
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
                        Console.WriteLine("그곳은 건설할 수 없습니다.            ");
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
                    // 타워 조합
                    
                case ConsoleKey.Q:
                    if (Maps.map[player.X, player.Y] > 0)
                    {
                        switch ((Maps.MapState)Maps.map[player.X, player.Y])
                        {
                            case Maps.MapState.LINE:
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("그곳은 건설할 수 없습니다.            ");
                                break;
                            case Maps.MapState.BUILD:
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("그곳은 타워가 없습니다.");
                                break;

                            case Maps.MapState.NORMALSTAR:
                                RandomTower.MixTowerSpawn(1, Maps.MapState.NORMALSTAR, Maps.MapState.MAGICSTAR);
                                break;
                            case Maps.MapState.NORMALSPADE:
                                RandomTower.MixTowerSpawn(1, Maps.MapState.NORMALSPADE, Maps.MapState.MAGICSPADE);
                                break;
                            case Maps.MapState.NORMALHEART:
                                RandomTower.MixTowerSpawn(1, Maps.MapState.NORMALHEART, Maps.MapState.MAGICHEART);
                                break;
                            case Maps.MapState.NORMALLASOR:
                                RandomTower.MixTowerSpawn(1, Maps.MapState.NORMALLASOR, Maps.MapState.MAGICLASOR);
                                break;
                            case Maps.MapState.MAGICSTAR:
                                break;
                            case Maps.MapState.MAGICSPADE:
                                break;
                            case Maps.MapState.MAGICHEART:
                                break;
                            case Maps.MapState.MAGICLASOR:
                                break;
                            case Maps.MapState.RARESTAR:
                                break;
                            case Maps.MapState.RARESPADE:
                                break;
                            case Maps.MapState.RAREHEART:
                                break;
                            case Maps.MapState.RARELASOR:
                                break;
                            case Maps.MapState.EPICSTAR:
                                break;
                            case Maps.MapState.EPICSPADE:
                                break;
                            case Maps.MapState.EPICHEART:
                                break;
                            case Maps.MapState.EPICLASOR:
                                break;
                            case Maps.MapState.LEGENDSTAR:
                                break;
                            case Maps.MapState.LEGENDSPADE:
                                break;
                            case Maps.MapState.LEGENDHEART:
                                break;
                            case Maps.MapState.LEGENDLASOR:
                                break;
                            default:
                                break;
                        }
                    }
                    
                    break;

            }

        }




    }
}


