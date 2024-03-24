using TowerDefense.DisplayMenu;
using TowerDefense.Character.EnemySpawn;
using TowerDefense.Character.PlayerInput;

namespace TowerDefense.Character.MoveEnemy
{
    internal class EnemyMovement
    {
        public static bool enemyMoveCheck1 = true;
        public static bool enemyMoveCheck2 = true;
        public static bool enemyMoveCheck3 = true;

        public static bool missionEnemyMoveCheck1 = true;
        public static bool missionEnemyMoveCheck2 = true;
        public static bool missionEnemyMoveCheck3 = true;


        public static void EnemyMove(List<Enemy> enemies, List<MissionEnemy> missionEnemies)
        {
            Thread.Sleep(200);

            List<Enemy> arrivedEnemy = new List<Enemy>();
            List<Enemy> DeadEnemy = new List<Enemy>();

            List<MissionEnemy> arrivedMissionEnemy = new List<MissionEnemy>();
            List<MissionEnemy> DeadMissionEnemy = new List<MissionEnemy>();

            if (EnemySpawner.enemies.Count != 0)
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.IsMoveValid(enemy.X, enemy.Y))
                    {
                        // 4,0 까지
                        if (enemy.X < 4 && enemy.Y == 0)
                        {
                            enemy.X++;
                        }
                        // 4, 11 까지
                        else if (enemy.X == 4 && enemy.Y < 11 && enemyMoveCheck1)
                        {
                            enemy.Y++;

                        }
                        // 0, 11 까지
                        else if (enemy.X > 0 && enemy.Y == 11 && enemy.X < 5)
                        {
                            enemy.X--;

                            if (enemy.X == 0 && enemy.Y == 11)
                                enemyMoveCheck1 = false;
                        }
                        // 0,7 까지
                        else if (enemy.X == 0 && enemy.Y > 7)
                        {
                            enemy.Y--;

                        }
                        // 11, 7까지
                        else if (enemy.X < 11 && enemy.Y == 7 && enemyMoveCheck2)
                        {
                            enemy.X++;

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
                                enemyMoveCheck2 = false;

                        }
                        //7 ,0
                        else if (enemy.X == 7 && enemy.Y > 0 && enemyMoveCheck3)
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
                                enemyMoveCheck3 = false;

                        }
                        ////0,4
                        else if (enemy.X > 0 && enemy.Y == 4)
                        {
                            enemy.X--;
                        }

                    }

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
                    Input.player.Hp -= 1;
                    UI.UpdateEnemyHpUI();
                }
                foreach (var i in DeadEnemy)
                {
                    EnemySpawner.enemies.Remove(i);
                    UI.UpdateEnemyHpUI();
                }
            }

            if (EnemySpawner.missionEnemies.Count != 0)
            {
                foreach (var missionEnemy in missionEnemies)
                {
                    if (missionEnemy.IsMoveValid(missionEnemy.X, missionEnemy.Y))
                    {
                        if (missionEnemy.X < 4 && missionEnemy.Y == 0)
                        {
                            missionEnemy.X++;
                        }
                        else if (missionEnemy.X == 4 && missionEnemy.Y < 11 && missionEnemyMoveCheck1)
                        {
                            missionEnemy.Y++;
                        }
                        else if (missionEnemy.X > 0 && missionEnemy.Y == 11 && missionEnemy.X < 5)
                        {
                            missionEnemy.X--;

                            if (missionEnemy.X == 0 && missionEnemy.Y == 11)
                                missionEnemyMoveCheck1 = false;
                        }
                        else if (missionEnemy.X == 0 && missionEnemy.Y > 7)
                        {
                            missionEnemy.Y--;
                        }
                        else if (missionEnemy.X < 11 && missionEnemy.Y == 7 && missionEnemyMoveCheck2)
                        {
                            missionEnemy.X++;
                        }
                        else if (missionEnemy.X == 11 && missionEnemy.Y < 11 && missionEnemy.Y > 6)
                        {
                            missionEnemy.Y++;
                        }
                        else if (missionEnemy.X > 7 && missionEnemy.Y == 11)
                        {
                            missionEnemy.X--;

                            if (missionEnemy.X == 7 && missionEnemy.Y == 11)
                                missionEnemyMoveCheck2 = false;
                        }
                        else if (missionEnemy.X == 7 && missionEnemy.Y > 0 && missionEnemyMoveCheck3)
                        {
                            missionEnemy.Y--;
                        }
                        else if (missionEnemy.X < 11 && missionEnemy.Y == 0)
                        {
                            missionEnemy.X++;
                        }
                        else if (missionEnemy.X == 11 && missionEnemy.Y < 4)
                        {
                            missionEnemy.Y++;

                            if (missionEnemy.X == 11 && missionEnemy.Y == 4)
                                missionEnemyMoveCheck3 = false;
                        }
                        else if (missionEnemy.X > 0 && missionEnemy.Y == 4)
                        {
                            missionEnemy.X--;
                        }
                    }

                    if (missionEnemy.X == 0 && missionEnemy.Y == 4)
                    {
                        for (int i = 0; i < EnemySpawner.missionEnemies.Count; i++)
                        {
                            arrivedMissionEnemy.Add(missionEnemy);
                        }

                        Console.SetCursorPosition(33, 29);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"{missionEnemy.MissionEnemyName} 실패   ");
                        Console.ResetColor();
                    }
                    
                    if (missionEnemy.Hp < 1)
                    {
                        for (int i = 0; i < EnemySpawner.missionEnemies.Count; i++)
                        {
                            DeadMissionEnemy.Add(missionEnemy);
                        }
                    }
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
    }

}

