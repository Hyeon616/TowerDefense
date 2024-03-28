using System.Text;
using TowerDefense.Character;
using TowerDefense.Utils;

namespace TowerDefense.Map
{
    public class Maps
    {
        public const int mapWidth = 12;
        public const int mapHeight = 12;

        public enum MapState
        {
            LINE,
            BUILD,
            NORMALCONSONANT,
            NORMALWORD,
            NORMALALPHA,
            NORMALNUMBER,
            MAGICCONSONANT,
            MAGICWORD,
            MAGICALPHA,
            MAGICNUMBER,
            RARECONSONANT,
            RAREWORD,
            RAREALPHA,
            RARENUMBER,
            EPICCONSONANT,
            EPICWORD,
            EPICALPHA,
            EPICNUMBER,
            LEGENDCONSONANT,
            LEGENDWORD,
            LEGENDALPHA,
            LEGENDNUMBER,
            PLAYER,
            ENEMY,
            MISSION1,
            MISSION2,
            MISSION3,
            MISSION4,
        }

        #region ImageDictionary
        public static char lineImage = Images.mapImages[MapState.LINE];
        public static char buildImage = Images.mapImages[MapState.BUILD];

        public static char normalConsonantImage = Images.mapImages[MapState.NORMALCONSONANT];
        public static char magicConsonantImage = Images.mapImages[MapState.MAGICCONSONANT];
        public static char rareConsonantImage = Images.mapImages[MapState.RARECONSONANT];
        public static char epicConsonantImage = Images.mapImages[MapState.EPICCONSONANT];
        public static char legendConsonantImage = Images.mapImages[MapState.LEGENDCONSONANT];

        public static char normalWordImage = Images.mapImages[MapState.NORMALWORD];
        public static char magicWordImage = Images.mapImages[MapState.MAGICWORD];
        public static char rareWordImage = Images.mapImages[MapState.RAREWORD];
        public static char epicWordImage = Images.mapImages[MapState.EPICWORD];
        public static char legendWordImage = Images.mapImages[MapState.LEGENDWORD];

        public static char normalAlphaImage = Images.mapImages[MapState.NORMALALPHA];
        public static char magicAlphaImage = Images.mapImages[MapState.MAGICALPHA];
        public static char rareAlphaImage = Images.mapImages[MapState.RAREALPHA];
        public static char epicAlphaImage = Images.mapImages[MapState.EPICALPHA];
        public static char legendAlphaImage = Images.mapImages[MapState.LEGENDALPHA];

        public static char normalNumberImage = Images.mapImages[MapState.NORMALNUMBER];
        public static char magicNumberImage = Images.mapImages[MapState.MAGICNUMBER];
        public static char rareNumberImage = Images.mapImages[MapState.RARENUMBER];
        public static char epicNumberImage = Images.mapImages[MapState.EPICNUMBER];
        public static char legendNumberImage = Images.mapImages[MapState.LEGENDNUMBER];

        public static char playerImage = Images.mapImages[MapState.PLAYER];
        public static char enemyImage = Images.mapImages[MapState.ENEMY];

        public static char missionEnemyImage1 = Images.mapImages[MapState.MISSION1];
        public static char missionEnemyImage2 = Images.mapImages[MapState.MISSION2];
        public static char missionEnemyImage3 = Images.mapImages[MapState.MISSION3];
        public static char missionEnemyImage4 = Images.mapImages[MapState.MISSION4];

        #endregion

        public static int[,] map =
            {
                { 0,1,1,1,0,1,1,0,0,0,0,0 },
                { 0,1,1,1,0,1,1,0,1,1,1,0 },
                { 0,1,1,1,0,1,1,0,1,1,1,0 },
                { 0,1,1,1,0,1,1,0,1,1,1,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 1,1,1,1,0,1,1,0,1,1,1,1 },
                { 1,1,1,1,0,1,1,0,1,1,1,1 },
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,1,1,1,0,1,1,0,1,1,1,0 },
                { 0,1,1,1,0,1,1,0,1,1,1,0 },
                { 0,1,1,1,0,1,1,0,1,1,1,0 },
                { 0,0,0,0,0,1,1,0,0,0,0,0 }
            };


        public static void PrintMap(Player player, List<Enemy> enemies, List<MissionEnemy> missionEnemies)
        {
            char[,] displayMap = new char[map.GetLength(0), map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    MapState setMapImage = (MapState)map[i, j];

                    // 타워, 라인 이미지
                    switch (setMapImage)
                    {
                        // 라인, 건설
                        case MapState.LINE:
                            displayMap[i, j] = lineImage;
                            break;
                        case MapState.BUILD:
                            displayMap[i, j] = buildImage;
                            break;

                        // 노말 타워
                        case MapState.NORMALCONSONANT:
                            displayMap[i, j] = normalConsonantImage;
                            break;
                        case MapState.NORMALWORD:
                            displayMap[i, j] = normalWordImage;
                            break;
                        case MapState.NORMALALPHA:
                            displayMap[i, j] = normalAlphaImage;
                            break;
                        case MapState.NORMALNUMBER:
                            displayMap[i, j] = normalNumberImage;
                            break;

                        // 매직 타워
                        case MapState.MAGICCONSONANT:
                            displayMap[i, j] = magicConsonantImage;
                            break;
                        case MapState.MAGICWORD:
                            displayMap[i, j] = magicWordImage;
                            break;
                        case MapState.MAGICALPHA:
                            displayMap[i, j] = magicAlphaImage;
                            break;
                        case MapState.MAGICNUMBER:
                            displayMap[i, j] = magicNumberImage;
                            break;

                        // 레어 타워
                        case MapState.RARECONSONANT:
                            displayMap[i, j] = rareConsonantImage;
                            break;
                        case MapState.RAREWORD:
                            displayMap[i, j] = rareWordImage;
                            break;
                        case MapState.RAREALPHA:
                            displayMap[i, j] = rareAlphaImage;
                            break;
                        case MapState.RARENUMBER:
                            displayMap[i, j] = rareNumberImage;
                            break;

                        // 에픽 타워
                        case MapState.EPICCONSONANT:
                            displayMap[i, j] = epicConsonantImage;
                            break;
                        case MapState.EPICWORD:
                            displayMap[i, j] = epicWordImage;
                            break;
                        case MapState.EPICALPHA:
                            displayMap[i, j] = epicAlphaImage;
                            break;
                        case MapState.EPICNUMBER:
                            displayMap[i, j] = epicNumberImage;
                            break;

                        // 전설 타워
                        case MapState.LEGENDCONSONANT:
                            displayMap[i, j] = legendConsonantImage;
                            break;
                        case MapState.LEGENDWORD:
                            displayMap[i, j] = legendWordImage;
                            break;
                        case MapState.LEGENDALPHA:
                            displayMap[i, j] = legendAlphaImage;
                            break;
                        case MapState.LEGENDNUMBER:
                            displayMap[i, j] = legendNumberImage;
                            break;
                    }

                    // 적
                    if(enemies != null)
                    {
                        foreach (var enemy in enemies)
                        {
                            if (IsValidPosition(enemy.X, enemy.Y, displayMap))
                            {
                                displayMap[enemy.X, enemy.Y] = enemyImage;
                            }
                            
                        }
                    }
                    

                    // 미션 적
                    if (missionEnemies.Count != 0)
                    {
                        foreach (var missionEnemy in missionEnemies)
                        {
                            if (i == missionEnemy.X && j == missionEnemy.Y)
                            {
                                if (missionEnemy.MissionEnemyName == MapState.MISSION1)
                                {
                                    displayMap[i, j] = missionEnemyImage1;
                                }
                                else if (missionEnemy.MissionEnemyName == MapState.MISSION2)
                                {
                                    displayMap[i, j] = missionEnemyImage2;
                                }
                                else if (missionEnemy.MissionEnemyName == MapState.MISSION3)
                                {
                                    displayMap[i, j] = missionEnemyImage3;
                                }
                                else if (missionEnemy.MissionEnemyName == MapState.MISSION4)
                                {
                                    displayMap[i, j] = missionEnemyImage4;
                                }

                            }
                        }
                    }


                    // 플레이어

                    displayMap[player.X, player.Y] = playerImage;



                }

            }

            for (int i = 0; i < displayMap.GetLength(0); i++)
            {
                for (int j = 0; j < displayMap.GetLength(1); j++)
                {

                    char displayMapImage = displayMap[i, j];

                    ConsoleColor color = ConsoleColor.White;

                    if (displayMapImage == lineImage)
                    {
                        color = ConsoleColor.Gray;
                    }
                    else if (displayMapImage == buildImage)
                    {
                        color = ConsoleColor.Yellow;
                    }
                    else if (displayMapImage == enemyImage)
                    {
                        color = ConsoleColor.Red;
                    }
                    else if (displayMapImage == playerImage)
                    {
                        color = ConsoleColor.Blue;
                    }
                    else if (displayMapImage == missionEnemyImage1)
                    {
                        color = ConsoleColor.Cyan;
                    }
                    else if (displayMapImage == missionEnemyImage2)
                    {
                        color = ConsoleColor.Cyan;
                    }
                    else if (displayMapImage == missionEnemyImage3)
                    {
                        color = ConsoleColor.DarkCyan;
                    }
                    else if (displayMapImage == missionEnemyImage4)
                    {
                        color = ConsoleColor.DarkCyan;
                    }


                    // 노말
                    else if (displayMapImage == normalConsonantImage || displayMapImage == normalWordImage || displayMapImage == normalAlphaImage || displayMapImage == normalNumberImage)
                    {
                        color = ConsoleColor.DarkGray;
                    }

                    // 매직
                    else if (displayMapImage == magicConsonantImage || displayMapImage == magicWordImage || displayMapImage == magicAlphaImage || displayMapImage == magicNumberImage)
                    {
                        color = ConsoleColor.DarkGreen;
                    }

                    // 레어
                    else if (displayMapImage == rareConsonantImage || displayMapImage == rareWordImage || displayMapImage == rareAlphaImage || displayMapImage == rareNumberImage)
                    {
                        color = ConsoleColor.DarkBlue;
                    }


                    // 에픽
                    else if (displayMapImage == epicConsonantImage || displayMapImage == epicWordImage || displayMapImage == epicAlphaImage || displayMapImage == epicNumberImage)
                    {
                        color = ConsoleColor.DarkMagenta;
                    }

                    // 전설
                    else if (displayMapImage == legendConsonantImage || displayMapImage == legendWordImage || displayMapImage == legendAlphaImage || displayMapImage == legendNumberImage)
                    {
                        color = ConsoleColor.DarkRed;
                    }

                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(29 + j * 2, 12 + i);
                    Console.Write(displayMapImage);
                }
                    Console.Write(" ");
                Console.WriteLine();
                Console.ResetColor();

            }


        }

        private static bool IsValidPosition(int x, int y, char[,] displayMap)
        {
            return x >= 0 && x < displayMap.GetLength(0) && y >= 0 && y < displayMap.GetLength(1);
        }

        public static void MapStringBuilderBuffer(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                Console.SetCursorPosition(29, 12 + i);
                Console.Write(sb.ToString());
            }


        }





    }
}
