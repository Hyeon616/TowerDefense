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
            NORMALSTAR,
            NORMALSPADE,
            NORMALHEART,
            NORMALLASOR,
            MAGICSTAR,
            MAGICSPADE,
            MAGICHEART,
            MAGICLASOR,
            RARESTAR,
            RARESPADE,
            RAREHEART,
            RARELASOR,
            EPICSTAR,
            EPICSPADE,
            EPICHEART,
            EPICLASOR,
            LEGENDSTAR,
            LEGENDSPADE,
            LEGENDHEART,
            LEGENDLASOR

        }

        public const char lineImage = '□';
        public const char buildImage = '■';
        public const char starImage = '★';
        public const char spadeImage = '♠';
        public const char heartImage = '♥';
        public const char lasorImage = '◈';
        public const char playerImage = '▣';
        public const char enemyImage = '●';


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
            int grade = 0;

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
                            grade = 1;
                            break;

                        // 노말 타워
                        case MapState.NORMALSTAR:
                            displayMap[i, j] = starImage;
                            grade = 1;
                            break;
                        case MapState.NORMALSPADE:
                            displayMap[i, j] = spadeImage;
                            grade = 1;
                            break;
                        case MapState.NORMALHEART:
                            displayMap[i, j] = heartImage;
                            grade = 1;
                            break;
                        case MapState.NORMALLASOR:
                            displayMap[i, j] = lasorImage;
                            grade = 1;
                            break;

                        // 매직 타워
                        case MapState.MAGICSTAR:
                            displayMap[i, j] = starImage;
                            grade = 2;
                            break;
                        case MapState.MAGICSPADE:
                            displayMap[i, j] = spadeImage;
                            grade = 2;
                            break;
                        case MapState.MAGICHEART:
                            displayMap[i, j] = heartImage;
                            grade = 2;
                            break;
                        case MapState.MAGICLASOR:
                            displayMap[i, j] = lasorImage;
                            grade = 2;
                            break;

                        // 레어 타워
                        case MapState.RARESTAR:
                            displayMap[i, j] = starImage;
                            grade = 2;
                            break;
                        case MapState.RARESPADE:
                            displayMap[i, j] = spadeImage;
                            grade = 2;
                            break;
                        case MapState.RAREHEART:
                            displayMap[i, j] = heartImage;
                            grade = 2;
                            break;
                        case MapState.RARELASOR:
                            displayMap[i, j] = lasorImage;
                            grade = 2;
                            break;

                        // 에픽 타워
                        case MapState.EPICSTAR:
                            displayMap[i, j] = starImage;
                            grade = 2;
                            break;
                        case MapState.EPICSPADE:
                            displayMap[i, j] = spadeImage;
                            grade = 2;
                            break;
                        case MapState.EPICHEART:
                            displayMap[i, j] = heartImage;
                            grade = 2;
                            break;
                        case MapState.EPICLASOR:
                            displayMap[i, j] = lasorImage;
                            grade = 2;
                            break;

                        // 전설 타워
                        case MapState.LEGENDSTAR:
                            displayMap[i, j] = starImage;
                            grade = 2;
                            break;
                        case MapState.LEGENDSPADE:
                            displayMap[i, j] = spadeImage;
                            grade = 2;
                            break;
                        case MapState.LEGENDHEART:
                            displayMap[i, j] = heartImage;
                            grade = 2;
                            break;
                        case MapState.LEGENDLASOR:
                            displayMap[i, j] = lasorImage;
                            grade = 2;
                            break;
                    }

                    foreach (var enemy in enemies)
                    {
                        if (i == enemy.X && j == enemy.Y)
                        {
                            displayMap[i, j] = enemyImage;
                        }
                    }

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
                    switch (displayMapImage)
                    {
                        case lineImage:
                            color = ConsoleColor.Gray;
                            break;
                        case buildImage:
                            color = ConsoleColor.Yellow;
                            break;
                        case enemyImage:
                            color = ConsoleColor.Red;
                            break;
                        case playerImage:
                            color = ConsoleColor.Blue;
                            break;
                        case starImage:
                            if (grade == 1)
                                color = ConsoleColor.DarkYellow;
                            break;
                        case spadeImage:
                            if (grade == 1)
                                color = ConsoleColor.DarkYellow;
                            break;
                        case heartImage:
                            if (grade == 1)
                                color = ConsoleColor.DarkYellow;
                            break;
                        case lasorImage:
                            if (grade == 1)
                                color = ConsoleColor.DarkYellow;
                            break;
                        
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
