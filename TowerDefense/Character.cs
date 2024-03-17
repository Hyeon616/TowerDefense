namespace TowerDefense.Unit
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
        public int Hp { get; set; }
        

        public Enemy(int x, int y)
        {
            
            X = x;
            Y = y;
        }

        
    }
}
