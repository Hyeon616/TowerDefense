using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.TowerManager;
using TowerDefense.Utils;
using TowerDefense.Character.EnemySpawn;

namespace TowerDefense.Character.PlayerInput
{
    internal class Input
    {

        public static Player player = new Player(5, 5);

        public static int gameStart = 0;

        public static void GameMenuInput()
        {
            Console.ResetColor();

            int option = 1;
            char decorator = '▶';

            bool isSelected = false;

            while (!isSelected)
            {


                if (option == 1)
                {
                    Console.SetCursorPosition(34, 27);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{decorator} 시작");
                }
                else
                {
                    Console.SetCursorPosition(34, 27);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"   시작");
                }

                if (option == 2)
                {
                    Console.SetCursorPosition(34, 28);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{decorator} 종료");
                }
                else
                {
                    Console.SetCursorPosition(34, 28);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"   종료");
                }

                Console.ResetColor();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyinfo = Console.ReadKey(true);

                    switch (keyinfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            option = option == 1 ? 2 : option - 1;
                            break;

                        case ConsoleKey.DownArrow:
                            option = option == 2 ? 1 : option + 1;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            if (option == 1)
                            {
                                gameStart++;
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                            break;
                    }
                }

            }

        }

        public static void GamePlayInput(Player player)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

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
                                    RandomTower.TowerSpawn(4, 1, Maps.MapState.NORMALCONSONANT);
                                    break;
                                case (int)Maps.MapState.NORMALWORD:
                                    RandomTower.TowerSpawn(4, 1, Maps.MapState.NORMALWORD);
                                    break;
                                case (int)Maps.MapState.NORMALALPHA:
                                    RandomTower.TowerSpawn(4, 1, Maps.MapState.NORMALALPHA);
                                    break;
                                case (int)Maps.MapState.NORMALNUMBER:
                                    RandomTower.TowerSpawn(4, 1, Maps.MapState.NORMALNUMBER);
                                    break;
                            }
                        }
                        else if (Maps.map[player.X, player.Y] == 1 && player.Money < 100)
                        {
                            UI.AlertUIPosition();
                            Console.WriteLine("금액이 부족해 건설할 수 없습니다.            ");
                            break;
                        }
                        else if (Maps.map[player.X, player.Y] == 0)
                        {
                            UI.AlertUIPosition();
                            Console.WriteLine("그곳은 건설할 수 없습니다.            ");
                            break;
                        }
                        else if(Maps.map[player.X, player.Y] >1)
                        {
                            UI.AlertUIPosition();
                            Console.WriteLine("그곳은 이미 타워가 있습니다.          ");
                        }
                        break;
                    // 타워 판매
                    case ConsoleKey.R:
                        RandomTower.SellTower();
                        break;

                    // 타워 조합
                    case ConsoleKey.Q:
                        if (Maps.map[player.X, player.Y] > 0)
                        {
                            switch ((Maps.MapState)Maps.map[player.X, player.Y])
                            {
                                case Maps.MapState.LINE:
                                    UI.AlertUIPosition();
                                    Console.WriteLine("그곳은 건설할 수 없습니다.            ");
                                    break;
                                case Maps.MapState.BUILD:
                                    UI.AlertUIPosition();
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
                                case Maps.MapState.NORMALNUMBER:
                                    RandomTower.MixTowerSpawn(Maps.MapState.NORMALNUMBER, Maps.MapState.MAGICNUMBER);
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
                                case Maps.MapState.MAGICNUMBER:
                                    RandomTower.MixTowerSpawn(Maps.MapState.MAGICNUMBER, Maps.MapState.RARENUMBER);
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
                                case Maps.MapState.RARENUMBER:
                                    RandomTower.MixTowerSpawn(Maps.MapState.RARENUMBER, Maps.MapState.EPICNUMBER);
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
                                case Maps.MapState.EPICNUMBER:
                                    RandomTower.MixTowerSpawn(Maps.MapState.EPICNUMBER, Maps.MapState.LEGENDNUMBER);
                                    break;

                                // 전설타워
                                case Maps.MapState.LEGENDCONSONANT:
                                    UI.AlertUIPosition();
                                    Console.WriteLine("타워가 최고 단계입니다.");
                                    break;
                                case Maps.MapState.LEGENDWORD:
                                    UI.AlertUIPosition();
                                    Console.WriteLine("타워가 최고 단계입니다.");
                                    break;
                                case Maps.MapState.LEGENDALPHA:
                                    UI.AlertUIPosition();
                                    Console.WriteLine("타워가 최고 단계입니다.");
                                    break;
                                case Maps.MapState.LEGENDNUMBER:
                                    UI.AlertUIPosition();
                                    Console.WriteLine("타워가 최고 단계입니다.");
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;

                    // 미션 몬스터 소환
                    case ConsoleKey.Z:
                        EnemySpawner.AddMissionEnemy(2000, 100, Maps.MapState.MISSION1);
                        break;
                    case ConsoleKey.X:
                        EnemySpawner.AddMissionEnemy(10000, 300, Maps.MapState.MISSION2);
                        break;
                    case ConsoleKey.C:
                        EnemySpawner.AddMissionEnemy(30000, 500, Maps.MapState.MISSION3);
                        break;
                    case ConsoleKey.V:
                        EnemySpawner.AddMissionEnemy(50000, 1000, Maps.MapState.MISSION4);
                        break;

                    // 타워 업그레이드
                    case ConsoleKey.U:
                        if (player.Money > 20)
                        {
                            TowerInfo.consonantAtkUp++;
                            player.Money -= 20;
                            break;
                        }
                        else
                        {
                            UI.AlertUIPosition();
                            Console.WriteLine("금액이 부족해 업그레이드 할 수 없습니다.           ");
                            break;
                        }
                    case ConsoleKey.I:
                        if (player.Money > 20)
                        {
                            TowerInfo.wordAtkUp++;
                            player.Money -= 20;
                            break;
                        }
                        else
                        {
                            UI.AlertUIPosition();
                            Console.WriteLine("금액이 부족해 업그레이드 할 수 없습니다.           ");
                            break;
                        }
                    case ConsoleKey.O:
                        if (player.Money > 20)
                        {
                            TowerInfo.alphaAtkUp++;
                            player.Money -= 20;
                            break;
                        }
                        else
                        {
                            UI.AlertUIPosition();
                            Console.WriteLine("금액이 부족해 업그레이드 할 수 없습니다.           ");
                            break;
                        }
                    case ConsoleKey.P:
                        if (player.Money > 20)
                        {
                            TowerInfo.numberAtkUp++;
                            player.Money -= 20;
                            break;
                        }
                        else
                        {
                            UI.AlertUIPosition();
                            Console.WriteLine("금액이 부족해 업그레이드 할 수 없습니다.           ");
                            break;
                        }

                    // 게임 종료
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        UI.AlertUIPosition();
                        Console.WriteLine("게임을 종료합니다.           ");
                        break;

                    case ConsoleKey.M:
                        player.Money += 10000;
                        break;

                }



            }

        }




    }
}


