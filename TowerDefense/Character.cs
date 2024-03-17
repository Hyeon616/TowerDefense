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

        public Player()
        {
            X = 5;
            Y = 5;
        }

    }
    public class Enemy : Unit
    {
        public int ID { get; set; }
        public int Hp { get; set; }
        

        public Enemy(int id)
        {
            ID = id;
            X = 0;
            Y = 0;
            Thread.Sleep(300);
        }

        
    }
}
