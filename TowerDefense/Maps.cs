using TowerDefense.Unit;
using System.Numerics;
using System;

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
        public static char lasorImage = ' ';
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


        public static void PrintMap(Player player, Enemy enemy1, Enemy enemy2, Enemy enemy3, Enemy enemy4, Enemy enemy5, Enemy enemy6, Enemy enemy7)
        {
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
                    else if (i == enemy1.X && j == enemy1.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(enemyImage);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i == enemy2.X && j == enemy2.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(enemyImage);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i == enemy3.X && j == enemy3.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(enemyImage);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i == enemy4.X && j == enemy4.Y)
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
                            case MapState.STAR:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(starImage);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case MapState.SPADE:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(spadeImage);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case MapState.MUSIC:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(musicImage);
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
