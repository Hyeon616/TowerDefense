using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map;

namespace Character
{
    public class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }

    public class Player : Unit
    {
        
        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
    public class Enemy : Unit
    {
        public int ID { get; set; }
        public int Hp { get; set; }
        
        public Enemy(int x, int y, int hp)
        {
            X = x;
            Y = y;
            Hp = hp;
        }

        
    }
}
