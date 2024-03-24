namespace TowerDefense.Utils
{
    public class DrawingUI
    {
        public static void TestMain()
        {
            var w = Console.WindowWidth;
            var h = Console.WindowHeight;

            // playerUI 좌측 위
            Draw(23, 5, new Point(0, 1), ConsoleColor.White);

            // timerUI 맵 위
            Draw(28, 5, new Point(25, 1), ConsoleColor.White);

            // EnemyHpUI 맵 왼쪽
            Draw(25, 10, new Point(0, 12), ConsoleColor.White);

            // AlertUI 맵아래
            Draw(78, 5, new Point(0, 25), ConsoleColor.White);

            // LevelUI 우측상단
            Draw(23, 5, new Point(55, 1), ConsoleColor.White);

            // tutorialUI 화면 아래
            Draw(78, 6, new Point(0, 32), ConsoleColor.White);

            // UpgradeUI 맵 오른쪽
            Draw(23, 15, new Point(55, 8), ConsoleColor.White);

            Console.CursorTop = h;
            Console.CursorLeft = 0;
        }

        public static void Draw(int Width, int Height, Point Location, ConsoleColor BorderColor)
        {
            Console.ForegroundColor = BorderColor;

            string s = "╔";
            for (int i = 0; i < Width; i++)
                s += "═";

            s += "╗" + "\n";

            Console.CursorTop = Location.Y;
            Console.CursorLeft = Location.X;
            Console.Write(s);

            for (int i = 0; i < Height; i++)
            {
                Console.CursorTop = Location.Y + 1 + i;
                Console.CursorLeft = Location.X;
                Console.WriteLine("║");
                Console.CursorTop = Location.Y + 1 + i;
                Console.CursorLeft = Location.X + Width + 1;
                Console.WriteLine("║");
            }

            s = "╚";
            for (int i = 0; i < Width; i++)
                s += "═";

            s += "╝" + "\n";

            Console.CursorTop = Location.Y + Height + 1;
            Console.CursorLeft = Location.X;
            Console.Write(s);
            Console.ResetColor();
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


}
