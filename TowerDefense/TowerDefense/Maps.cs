using Character;

namespace Map
{
    public class Maps
    {
        public const int mapWidth = 12;
        public const int mapHeight = 12;

        enum MapState
        {
            LINE,
            BUILD,
            FIRE,
            WATER,
            ELECTRO,
            LASOR,

        }

        private static char lineImage = '□';
        private static char buildImage = '■';
        private static char fireImage = ' ';
        private static char waterImage = ' ';
        private static char electroImage = ' ';
        private static char lasorImage = ' ';
        private static char playerImage = '▣';
        private static char enemyImage = '●';


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


        public static void Map(Player player, Enemy enemy)
        {
            //Console.Clear();


            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    if (i == player.X && j == player.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(playerImage);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i == enemy.X && j == enemy.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(enemyImage);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {

                        switch ((MapState)map[i, j])
                        {
                            case MapState.LINE:
                                Console.Write(lineImage);
                                break;
                            case MapState.BUILD:
                                Console.ForegroundColor = ConsoleColor.Yellow;

                                Console.Write(buildImage);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }


                    }
                }
                Console.WriteLine();
            }


        }


    }
}
