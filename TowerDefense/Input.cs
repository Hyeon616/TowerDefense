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
                        //TowerSpawn(타워공격력, 타워등급, 타워이름);
                        switch (RandomTower.BuildTowerNumber())
                        {
                            case (int)Maps.MapState.NORMALCONSONANT:
                                RandomTower.TowerSpawn(10, 1, Maps.MapState.NORMALCONSONANT);
                                break;
                            case (int)Maps.MapState.NORMALWORD:
                                RandomTower.TowerSpawn(10, 1, Maps.MapState.NORMALWORD);
                                break;
                            case (int)Maps.MapState.NORMALALPHA:
                                RandomTower.TowerSpawn(10, 1, Maps.MapState.NORMALALPHA);
                                break;
                            case (int)Maps.MapState.NORMALLASOR:
                                RandomTower.TowerSpawn(10, 1, Maps.MapState.NORMALLASOR);
                                break;
                            /*
                             case (int)Maps.MapState.MAGICCONSONANT:
                            RandomTower.TowerSpawn(10, 2, Maps.MapState.MAGICCONSONANT);
                            break;
                        case (int)Maps.MapState.MAGICWORD:
                            RandomTower.TowerSpawn(10, 2, Maps.MapState.MAGICWORD);
                            break;
                        case (int)Maps.MapState.MAGICALPHA:
                            RandomTower.TowerSpawn(10, 2, Maps.MapState.MAGICALPHA);
                            break;
                        case (int)Maps.MapState.MAGICLASOR:
                            RandomTower.TowerSpawn(10, 2, Maps.MapState.MAGICLASOR);
                            break;

                        case (int)Maps.MapState.RARECONSONANT:
                            RandomTower.TowerSpawn(10, 3, Maps.MapState.RARECONSONANT);
                            break;
                        case (int)Maps.MapState.RAREWORD:
                            RandomTower.TowerSpawn(10, 3, Maps.MapState.RAREWORD);
                            break;
                        case (int)Maps.MapState.RAREALPHA:
                            RandomTower.TowerSpawn(10, 3, Maps.MapState.RAREALPHA);
                            break;
                        case (int)Maps.MapState.RARELASOR:
                            RandomTower.TowerSpawn(10, 3, Maps.MapState.RARELASOR);
                            break;

                        case (int)Maps.MapState.EPICCONSONANT:
                            RandomTower.TowerSpawn(10, 4, Maps.MapState.EPICCONSONANT);
                            break;
                        case (int)Maps.MapState.EPICWORD:
                            RandomTower.TowerSpawn(10, 4, Maps.MapState.EPICWORD);
                            break;
                        case (int)Maps.MapState.EPICALPHA:
                            RandomTower.TowerSpawn(10, 4, Maps.MapState.EPICALPHA);
                            break;
                        case (int)Maps.MapState.EPICLASOR:
                            RandomTower.TowerSpawn(10, 4, Maps.MapState.EPICLASOR);
                            break;

                        case (int)Maps.MapState.LEGENDCONSONANT:
                            RandomTower.TowerSpawn(10, 5, Maps.MapState.LEGENDCONSONANT);
                            break;
                        case (int)Maps.MapState.LEGENDWORD:
                            RandomTower.TowerSpawn(10, 5, Maps.MapState.LEGENDWORD);
                            break;
                        case (int)Maps.MapState.LEGENDALPHA:
                            RandomTower.TowerSpawn(10, 5, Maps.MapState.LEGENDALPHA);
                            break;
                        case (int)Maps.MapState.LEGENDLASOR:
                            RandomTower.TowerSpawn(10, 5, Maps.MapState.LEGENDLASOR);
                            break;
                             */
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
                    RandomTower.SellTower();
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
                            // 노말 타워
                            case Maps.MapState.NORMALCONSONANT:
                                RandomTower.MixTowerSpawn(Maps.MapState.NORMALCONSONANT, Maps.MapState.MAGICCONSONANT);
                                break;
                            case Maps.MapState.NORMALWORD:
                                RandomTower.MixTowerSpawn(Maps.MapState.NORMALWORD, Maps.MapState.MAGICWORD);
                                break;
                            case Maps.MapState.NORMALALPHA:
                                RandomTower.MixTowerSpawn(Maps.MapState.NORMALALPHA, Maps.MapState.MAGICALPHA);
                                break;
                            case Maps.MapState.NORMALLASOR:
                                RandomTower.MixTowerSpawn(Maps.MapState.NORMALLASOR, Maps.MapState.MAGICLASOR);
                                break;
                            // 매직타워

                            case Maps.MapState.MAGICCONSONANT:
                                RandomTower.MixTowerSpawn(Maps.MapState.MAGICCONSONANT, Maps.MapState.RARECONSONANT);
                                break;
                            case Maps.MapState.MAGICWORD:
                                RandomTower.MixTowerSpawn(Maps.MapState.MAGICWORD, Maps.MapState.RAREWORD);
                                break;
                            case Maps.MapState.MAGICALPHA:
                                RandomTower.MixTowerSpawn(Maps.MapState.MAGICALPHA, Maps.MapState.RAREALPHA);
                                break;
                            case Maps.MapState.MAGICLASOR:
                                RandomTower.MixTowerSpawn(Maps.MapState.MAGICLASOR, Maps.MapState.RARELASOR);
                                break;

                            // 레어 타워
                            case Maps.MapState.RARECONSONANT:
                                RandomTower.MixTowerSpawn(Maps.MapState.RARECONSONANT, Maps.MapState.EPICCONSONANT);
                                break;
                            case Maps.MapState.RAREWORD:
                                RandomTower.MixTowerSpawn(Maps.MapState.RAREWORD, Maps.MapState.EPICWORD);
                                break;
                            case Maps.MapState.RAREALPHA:
                                RandomTower.MixTowerSpawn(Maps.MapState.RAREALPHA, Maps.MapState.EPICALPHA);
                                break;
                            case Maps.MapState.RARELASOR:
                                RandomTower.MixTowerSpawn(Maps.MapState.RARELASOR, Maps.MapState.EPICLASOR);
                                break;

                            // 에픽타워
                            case Maps.MapState.EPICCONSONANT:
                                RandomTower.MixTowerSpawn(Maps.MapState.EPICCONSONANT, Maps.MapState.LEGENDCONSONANT);
                                break;
                            case Maps.MapState.EPICWORD:
                                RandomTower.MixTowerSpawn(Maps.MapState.EPICWORD, Maps.MapState.LEGENDWORD);
                                break;
                            case Maps.MapState.EPICALPHA:
                                RandomTower.MixTowerSpawn(Maps.MapState.EPICALPHA, Maps.MapState.LEGENDALPHA);
                                break;
                            case Maps.MapState.EPICLASOR:
                                RandomTower.MixTowerSpawn(Maps.MapState.EPICLASOR, Maps.MapState.LEGENDLASOR);
                                break;

                            // 전설타워
                            case Maps.MapState.LEGENDCONSONANT:
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("타워가 최고 단계입니다.");
                                break;
                            case Maps.MapState.LEGENDWORD:
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("타워가 최고 단계입니다.");
                                break;
                            case Maps.MapState.LEGENDALPHA:
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("타워가 최고 단계입니다.");
                                break;
                            case Maps.MapState.LEGENDLASOR:
                                Console.SetCursorPosition(15, 16);
                                Console.WriteLine("타워가 최고 단계입니다.");
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    Console.SetCursorPosition(0, 28);
                    break;

            }

        }




    }
}


