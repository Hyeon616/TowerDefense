using TowerDefense.Cooldown;
using TowerDefense.Spawner;
using TowerDefense.Unit;

namespace TowerDefense
{
    internal class EnemyMovement
    {
        public static bool moveCheck1 = true;
        public static bool moveCheck2 = true;
        public static bool moveCheck3 = true;

        //public static EnemyMoveTimer enemyMoveTimer = new EnemyMoveTimer(50, 0, 100);


        public static void EnemyMove(Player player, List<Enemy> enemies)
        {
            Thread.Sleep(200);

            List<Enemy> arrivedEnemy = new List<Enemy>();
            List<Enemy> DeadEnemy = new List<Enemy>();

            if (EnemySpawner.enemies.Count != 0)
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.IsMoveValid(enemy.X, enemy.Y))
                    {
                        // 4,0 까지
                        if (enemy.X < 4 && enemy.Y == 0)
                        {
                            ++enemy.X;
                        }
                        // 4, 11 까지
                        else if (enemy.X == 4 && enemy.Y < 11 && moveCheck1)
                        {
                            ++enemy.Y;

                        }
                        // 0, 11 까지
                        else if (enemy.X > 0 && enemy.Y == 11 && enemy.X < 5)
                        {
                            --enemy.X;

                            if (enemy.X == 0 && enemy.Y == 11)
                                moveCheck1 = false;
                        }
                        // 0,7 까지
                        else if (enemy.X == 0 && enemy.Y > 7)
                        {
                            --enemy.Y;

                        }
                        // 11, 7까지
                        else if (enemy.X < 11 && enemy.Y == 7 && moveCheck2)
                        {
                            ++enemy.X;

                        }
                        //11,11
                        else if (enemy.X == 11 && enemy.Y < 11 && enemy.Y > 6)
                        {
                            enemy.Y++;

                        }
                        // 7,11
                        else if (enemy.X > 7 && enemy.Y == 11)
                        {
                            enemy.X--;

                            if (enemy.X == 7 && enemy.Y == 11)
                                moveCheck2 = false;

                        }
                        //7 ,0
                        else if (enemy.X == 7 && enemy.Y > 0 && moveCheck3)
                        {
                            enemy.Y--;
                        }
                        // 11,0
                        else if (enemy.X < 11 && enemy.Y == 0)
                        {
                            enemy.X++;

                        }
                        ////11,4
                        else if (enemy.X == 11 && enemy.Y < 4)
                        {
                            enemy.Y++;

                            if (enemy.X == 11 && enemy.Y == 4)
                                moveCheck3 = false;

                        }
                        ////0,4
                        else if (enemy.X > 0 && enemy.Y == 4)
                        {
                            enemy.X--;
                        }


                    }
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine($"X : {enemy.X}, Y : {enemy.Y}        ");


                    if (enemy.X == 0 && enemy.Y == 4)
                    {
                        for (int i = 0; i < EnemySpawner.enemies.Count; i++)
                        {
                            arrivedEnemy.Add(enemy);
                        }
                    }

                    if (enemy.Hp < 1)
                    {
                        for (int i = 0; i < EnemySpawner.enemies.Count; i++)
                        {
                            DeadEnemy.Add(enemy);
                        }
                    }




                }

                foreach (var i in arrivedEnemy)
                {
                    EnemySpawner.enemies.Remove(i);
                    player.Hp -= 1;
                }
                foreach (var i in DeadEnemy)
                {
                    EnemySpawner.enemies.Remove(i);
                    UpdateEnemyHpUI();
                }
            }




        }

        public static void UpdateEnemyHpUI()
        {

            Console.SetCursorPosition(9, 20);
            Console.Write("                      ");
            Console.SetCursorPosition(9, 21);
            Console.Write("                      ");
            Console.SetCursorPosition(9, 22);
            Console.Write("                      ");
            Console.SetCursorPosition(9, 23);
            Console.Write("                      ");
        }
    }

}

