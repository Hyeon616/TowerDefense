using System;
using System.Timers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TowerDefense.Character.EnemySpawn;
using TowerDefense.Character.PlayerInput;
using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using Timer = System.Timers.Timer;

namespace TowerDefense.Character
{
    public class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Hp { get; set; }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
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
            Hp = 50;
        }
    }
    public class Enemy : Unit
    {
        public int ID { get; set; }

        public Enemy(int x, int y, int id, int hp)
        {
            X = x;
            Y = y;
            ID = id;
            Hp = hp;
        }

        private static readonly List<(int, int)> Path = new List<(int, int)>
        {
            (0, 0), (1, 0), (2, 0), (3, 0), (4, 0), // 0 -> 4, 0으로 이동
            (4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (4, 7), (4, 8), (4, 9), (4, 10), (4, 11), // 4, 0 -> 4, 11로 이동
            (3, 11), (2, 11), (1, 11), (0, 11), // 4, 11 -> 0, 11로 이동
            (0, 10), (0, 9), (0, 8), (0, 7), // 0, 11 -> 0, 7로 이동
            (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), // 0, 7 -> 11, 7로 이동
            (11, 8), (11, 9), (11, 10), (11, 11), // 11, 7 -> 11, 11로 이동
            (10, 11), (9, 11), (8, 11), (7, 11), // 11, 11 -> 7, 11로 이동
            (7, 10), (7, 9), (7, 8), (7, 7), (7, 6), (7, 5), (7, 4), (7, 3), (7, 2), (7, 1), (7, 0), // 7, 11 -> 7, 0로 이동
            (8, 0), (9, 0), (10, 0), (11, 0), // 7, 0 -> 11, 0로 이동
            (11, 1), (11, 2), (11, 3), (11, 4), // 11, 0 -> 11, 4로 이동
            (10, 4), (9, 4), (8, 4), (7, 4), (6,4),(5,4),(4,4),(3,4),(2, 4),(1, 4),(0, 4)// 11, 4 -> 11, 0로 이동
        };


        //public bool enemyMoveCheck1 = true;
        //public bool enemyMoveCheck2 = true;
        //public bool enemyMoveCheck3 = true;

        public async Task EnemyMove()
        {
           
            List<Enemy> arrivedEnemy = new List<Enemy>();
            List<Enemy> DeadEnemy = new List<Enemy>();

            foreach ((int newX, int newY) in Path)
            {
                if (!IsMoveValid(newX, newY))
                    continue;
                
                X = newX;
                Y = newY;

                Console.SetCursorPosition(27, 29);
                Console.WriteLine($"{X}, {Y}    ");

                // 도착 여부 확인
                if (X == 0 && Y == 4)
                {
                    arrivedEnemy.Add(this);
                    break;
                }

                await Task.Delay(1000);
            }

            if (Hp < 1)
            {
                DeadEnemy.Add(this);
            }

            foreach (var i in arrivedEnemy)
            {
                EnemySpawner.enemies.Remove(i);
                Input.player.Hp -= 1;
                UI.UpdateEnemyHpUI();
            }

            foreach (var i in DeadEnemy)
            {
                EnemySpawner.enemies.Remove(i);
                UI.UpdateEnemyHpUI();
            }

            

        }
        //public static void SetupTimer(Enemy enemy, double interval)
        //{
        //    Timer timer = new Timer(1000);
        //    timer.Interval = interval;
        //    timer.AutoReset = true;
        //    timer.Elapsed += (sender, e) => enemy.EnemyMove();
        //    timer.Start();
        //}
    }




    public class MissionEnemy : Unit
    {
        public int Cost { get; set; }

        public Maps.MapState MissionEnemyName { get; set; }

        public MissionEnemy(int x, int y, int hp, int cost, Maps.MapState missionEnemyName)
        {
            X = x;
            Y = y;
            Hp = hp;
            Cost = cost;
            MissionEnemyName = missionEnemyName;
        }

        private bool missionEnemyMoveCheck1 = true;
        private bool missionEnemyMoveCheck2 = true;
        private bool missionEnemyMoveCheck3 = true;
        public void MissionMove()
        {
            Thread.Sleep(200);

            List<MissionEnemy> arrivedMissionEnemy = new List<MissionEnemy>();
            List<MissionEnemy> DeadMissionEnemy = new List<MissionEnemy>();


            if (IsMoveValid(X, Y))
            {
                if (X < 4 && Y == 0)
                {
                    X++;
                }
                else if (X == 4 && Y < 11 && missionEnemyMoveCheck1)
                {
                    Y++;
                }
                else if (X > 0 && Y == 11 && X < 5)
                {
                    X--;

                    if (X == 0 && Y == 11)
                        missionEnemyMoveCheck1 = false;
                }
                else if (X == 0 && Y > 7)
                {
                    Y--;
                }
                else if (X < 11 && Y == 7 && missionEnemyMoveCheck2)
                {
                    X++;
                }
                else if (X == 11 && Y < 11 && Y > 6)
                {
                    Y++;
                }
                else if (X > 7 && Y == 11)
                {
                    X--;

                    if (X == 7 && Y == 11)
                        missionEnemyMoveCheck2 = false;
                }
                else if (X == 7 && Y > 0 && missionEnemyMoveCheck3)
                {
                    Y--;
                }
                else if (X < 11 && Y == 0)
                {
                    X++;
                }
                else if (X == 11 && Y < 4)
                {
                    Y++;

                    if (X == 11 && Y == 4)
                        missionEnemyMoveCheck3 = false;
                }
                else if (X > 0 && Y == 4)
                {
                    X--;
                }
            }

            if (X == 0 && Y == 4)
            {
                arrivedMissionEnemy.Add(this);


                Console.SetCursorPosition(33, 29);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"{MissionEnemyName} 실패   ");
                Console.ResetColor();
            }

            if (Hp < 1)
            {
                DeadMissionEnemy.Add(this);

            }


            foreach (var i in arrivedMissionEnemy)
            {
                EnemySpawner.missionEnemies.Remove(i);
                Input.player.Hp -= 10;
                UI.UpdateEnemyHpUI();
            }
            foreach (var i in DeadMissionEnemy)
            {
                EnemySpawner.missionEnemies.Remove(i);
                Input.player.Money += i.Cost;
                UI.UpdateEnemyHpUI();

            }


        }


    }

    public class Tower : Unit
    {
        public int Atk { get; set; }
        public int AttackSpeed { get; set; }
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


//if (IsMoveValid(X, Y))
//{
//    // 4,0 까지
//    if (X < 4 && Y == 0)
//    {
//        X++;
//    }
//    // 4, 11 까지
//    else if (X == 4 && Y < 11 && enemyMoveCheck1)
//    {
//        Y++;

//    }
//    // 0, 11 까지
//    else if (X > 0 && Y == 11 && X < 5)
//    {
//        X--;

//        if (X == 0 && Y == 11)
//            enemyMoveCheck1 = false;
//    }
//    // 0,7 까지
//    else if (X == 0 && Y > 7)
//    {
//        Y--;

//    }
//    // 11, 7까지
//    else if (X < 11 && Y == 7 && enemyMoveCheck2)
//    {
//        X++;

//    }
//    //11,11
//    else if (X == 11 && Y < 11 && Y > 6)
//    {
//        Y++;

//    }
//    // 7,11
//    else if (X > 7 && Y == 11)
//    {
//        X--;

//        if (X == 7 && Y == 11)
//            enemyMoveCheck2 = false;

//    }
//    //7 ,0
//    else if (X == 7 && Y > 0 && enemyMoveCheck3)
//    {
//        Y--;
//    }
//    // 11,0
//    else if (X < 11 && Y == 0)
//    {
//        X++;

//    }
//    ////11,4
//    else if (X == 11 && Y < 4)
//    {
//        Y++;

//        if (X == 11 && Y == 4)
//            enemyMoveCheck3 = false;

//    }
//    ////0,4
//    else if (X > 0 && Y == 4)
//    {
//        X--;
//    }

//}

//if (X == 0 && Y == 4)
//{
//    arrivedEnemy.Add(this);

//}

//if (Hp < 1)
//{
//    DeadEnemy.Add(this);

//}



//foreach (var i in arrivedEnemy)
//{
//    EnemySpawner.enemies.Remove(i);
//    Input.player.Hp -= 1;
//    UI.UpdateEnemyHpUI();
//}
//foreach (var i in DeadEnemy)
//{
//    EnemySpawner.enemies.Remove(i);
//    UI.UpdateEnemyHpUI();
//}