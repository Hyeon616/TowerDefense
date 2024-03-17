using System;
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
            STAR,
            SPADE,
            MUSIC,
            LASOR,

        }

        public static char lineImage = '□';
        public static char buildImage = '■';
        public static char starImage = '★';
        public static char spadeImage = '♠';
        public static char musicImage = '♬';
        public static char lasorImage = '◈';
        public static char playerImage = '▣';
        public static char enemyImage = '●';


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

                    if (i == player.X && j == player.Y)
                    {
                        displayMap[i, j] = playerImage;

                    }
                    else if((MapState)map[i, j] == MapState.LINE)
                    {
                        
                        displayMap[i, j] = lineImage;
                    }
                    else if ((MapState)map[i, j] == MapState.BUILD)
                    {
                        displayMap[i, j] = buildImage;
                    }
                    else if ((MapState)map[i, j] == MapState.STAR)
                    {
                        displayMap[i, j] = starImage;
                    }
                    else if ((MapState)map[i, j] == MapState.SPADE)
                    {
                        displayMap[i, j] = spadeImage;
                    }
                    else if ((MapState)map[i, j] == MapState.MUSIC)
                    {
                        
                        displayMap[i, j] = musicImage;
                    }
                    else if ((MapState)map[i, j] == MapState.LASOR)
                    {

                        displayMap[i, j] = lasorImage;
                    }
                    foreach (var enemy in enemies)
                    {
                        if (i == enemy.X && j == enemy.Y)
                        {
                            displayMap[i, j] = enemyImage;
                        }
                    }

                }
                
            }// end for

            for (int i = 0; i < displayMap.GetLength(0); i++)
            {
                for (int j = 0; j < displayMap.GetLength(1); j++)
                {
                    if (displayMap[i,j] == lineImage)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if(displayMap[i, j] == buildImage)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (displayMap[i, j] == enemyImage)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (displayMap[i, j] == playerImage)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (displayMap[i, j] == spadeImage)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (displayMap[i, j] == starImage)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (displayMap[i, j] == musicImage)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (displayMap[i, j] == lasorImage)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(displayMap[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine();
            }


        }


    }
}
