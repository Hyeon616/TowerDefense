using System.Timers;
using TowerDefense.RandomTower;
using TowerDefense.Spawner;

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

        public Enemy(int x, int y, int hp)
        {
            X = x;
            Y = y;
            Hp = hp;
        }

    }




    public class Tower : Unit
    {
        public int Atk { get; set; }
        public int AttackSpeed {  get; set; }
        public System.Timers.Timer AttackTimer { get; set; }
        public Tower(int x, int y, int atk, int attackSpeed)
        {
            X = x;
            Y = y;
            Atk = atk;
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
            if (SetTower.towerGroup.Count != 0)
            {
                foreach (Tower tower in SetTower.towerGroup)
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
