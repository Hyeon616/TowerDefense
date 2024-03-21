using System.Timers;
using TowerDefense.Map;
using TowerDefense.TowerManager;
using TowerDefense.Spawner;
using System.Net;

namespace TowerDefense.Unit
{
    public class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Hp { get; set; }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public bool IsMoveValid(int x, int y)
        {
            return x >= 0 && x < Maps.mapWidth && y >= 0 && y < Maps.mapHeight;
        }

    }

    public class Player : Unit
    {
        public int Money { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Money = 50000;
            Hp = 40;
        }
    }
    public class Enemy : Unit
    {
        public int ID {  get; set; }

        public Enemy(int x, int y, int id,int hp)
        {
            X = x;
            Y = y;
            ID = id;
            Hp = hp;
        }

    }


    public class Tower : Unit
    {
        public int Atk { get; set; }
        public int AttackSpeed {  get; set; }
        public int Grade { get; set; }
        
        public Maps.MapState TowerName { get; set; }
        
        public Tower(int x, int y, int atk, int grade, Maps.MapState towerName)
        {
            X = x;
            Y = y;
            Atk = atk;
            Grade = grade;
            TowerName = towerName;

        }

        

    }
}
