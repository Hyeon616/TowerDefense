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
            Money = 200;
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
        public System.Timers.Timer AttackTimer { get; set; }
        public Tower(int x, int y, int atk, int attackSpeed, int grade)
        {
            X = x;
            Y = y;
            Atk = atk;
            Grade = grade;
            AttackTimer = new System.Timers.Timer(attackSpeed);
            AttackTimer.Elapsed += AttackEnemy;
            AttackTimer.AutoReset = true;

        }

        public void StartAttack()
        {
            AttackTimer.Start();
        }

        public void StopAttack()
        {
            AttackTimer.Stop();
        }

        public static void AttackEnemy(object source, ElapsedEventArgs e)
        {

            if (RandomTower.towerGroup.Count != 0)
            {
                foreach (Tower tower in RandomTower.towerGroup)
                {
                    foreach (var enemy in EnemySpawner.enemies)
                    {
                        int distanceX = Math.Abs(tower.X - enemy.X);
                        int distanceY = Math.Abs(tower.Y - enemy.Y);

                        if (distanceX <= 2 && distanceY <= 2)
                        {
                            enemy.Hp -= tower.Atk;

                        }
                    }
                }
            }
        }



    }
}
