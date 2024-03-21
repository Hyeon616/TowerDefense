using TowerDefense.Unit;

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
            NORMALLASOR,
            MAGICCONSONANT,
            MAGICWORD,
            MAGICALPHA,
            MAGICLASOR,
            RARECONSONANT,
            RAREWORD,
            RAREALPHA,
            RARELASOR,
            EPICCONSONANT,
            EPICWORD,
            EPICALPHA,
            EPICLASOR,
            LEGENDCONSONANT,
            LEGENDWORD,
            LEGENDALPHA,
            LEGENDLASOR,
            PLAYER,
            ENEMY

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

        public static char normalLasorImage = Images.mapImages[MapState.NORMALLASOR];
        public static char magicLasorImage = Images.mapImages[MapState.MAGICLASOR];
        public static char rareLasorImage = Images.mapImages[MapState.RARELASOR];
        public static char epicLasorImage = Images.mapImages[MapState.EPICLASOR];
        public static char legendLasorImage = Images.mapImages[MapState.LEGENDLASOR];

        public static char playerImage = Images.mapImages[MapState.PLAYER];
        public static char enemyImage = Images.mapImages[MapState.ENEMY];
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


        public static void PrintMap(Player player, List<Enemy> enemies)
        {
            char[,] displayMap = new char[map.GetLength(0), map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    MapState setMapImage = (MapState)map[i, j];

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
                        case MapState.NORMALLASOR:
                            displayMap[i, j] = normalLasorImage;
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
                        case MapState.MAGICLASOR:
                            displayMap[i, j] = magicLasorImage;
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
                        case MapState.RARELASOR:
                            displayMap[i, j] = rareLasorImage;
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
                        case MapState.EPICLASOR:
                            displayMap[i, j] = epicLasorImage;
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
                        case MapState.LEGENDLASOR:
                            displayMap[i, j] = legendLasorImage;
                            break;
                    }

                    // 적 
                    foreach (var enemy in enemies)
                    {
                        if (i == enemy.X && j == enemy.Y)
                        {
                            displayMap[i, j] = enemyImage;
                        }
                    }

                    // 플레이어
                    if (i == player.X && j == player.Y)
                    {
                        displayMap[i, j] = playerImage;

                    }

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

                    // 노말
                    else if (displayMapImage == normalConsonantImage || displayMapImage == normalWordImage || displayMapImage == normalAlphaImage || displayMapImage == normalLasorImage)
                    {
                        color = ConsoleColor.DarkGray;
                    }
                    
                    // 매직
                    else if (displayMapImage == magicConsonantImage || displayMapImage == magicWordImage || displayMapImage == magicAlphaImage || displayMapImage == magicLasorImage)
                    {
                        color = ConsoleColor.DarkGreen;
                    }
                    
                    // 레어
                    else if (displayMapImage == rareConsonantImage || displayMapImage == rareWordImage || displayMapImage == rareAlphaImage || displayMapImage == rareLasorImage)
                    {
                        color = ConsoleColor.DarkBlue;
                    }
                    

                    // 에픽
                    else if (displayMapImage == epicConsonantImage || displayMapImage == epicWordImage || displayMapImage == epicAlphaImage || displayMapImage == epicLasorImage)
                    {
                        color = ConsoleColor.DarkMagenta;
                    }
                    
                    // 전설
                    else if (displayMapImage == legendConsonantImage || displayMapImage == legendWordImage || displayMapImage == legendAlphaImage || displayMapImage == legendLasorImage)
                    {
                        color = ConsoleColor.DarkRed;
                    }

                    Console.ForegroundColor = color;
                    Console.Write(displayMapImage);
                }
                Console.WriteLine();
                Console.ResetColor();

            }


        }


    }
}
