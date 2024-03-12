using Character;


namespace Map
{
    public class Maps
    {
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
                        map[i, j] = playerImage;
                        Console.Write(playerImage);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i == enemy.X && j == enemy.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        map[i, j] = enemyImage;
                        Console.Write(enemyImage);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.SetCursorPosition(i, j);
                        switch ((MapState)map[i, j])
                        {
                            case MapState.LINE:
                                map[i, j] = lineImage;
                                Console.Write(lineImage);
                                break;
                            case MapState.BUILD:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                map[i, j] = buildImage;
                                Console.Write(buildImage);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        //public static void RenderMap()
        //{
        //    Array.Copy(map, bufMap, map.GetLength(0)*map.GetLength(1));

        //    for (int i = 0; i < map.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < map.GetLength(1); j++)
        //        {
        //            Console.SetCursorPosition(0, 0);
        //            Console.WriteLine(bufMap[i,j]);
        //        }
        //    }
        //}
    }
}
