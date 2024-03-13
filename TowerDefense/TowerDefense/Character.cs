using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map;
using static System.Net.Mime.MediaTypeNames;

namespace Character
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Image { get; set; }

        public Player(char image ,int x, int y)
        {
            X = x;
            Y = y;
            Image = image;
        }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }
    public class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Image { get; set; }

        public Enemy(char image, int x, int y)
        {
            X = x;
            Y = y;
            Image = image;
        }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }
}
