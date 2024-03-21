using TowerDefense.Control;
using TowerDefense.Cooldown;
using TowerDefense.Map;
using TowerDefense.Spawner;
using TowerDefense.Unit;

namespace TowerDefense.TowerManager
{
    internal class RandomTower
    {

        public const int towerWidthRange = 5;
        public const int towerHeightRange = 5;

        public static List<Tower> towerGroup = new List<Tower>();
        public static AttackTimer attackTimer = new AttackTimer(2, 0, 300);

        public static int tempDamge;
        public static int tempGrade;

        public static int BuildTowerNumber()
        {
            Random random = new Random();
            int randomTower = random.Next(2, 6);

            return randomTower;
        }
        public static void TowerSpawn(int towerAtkDamage, int towerGrade, Maps.MapState spawnTowerName)
        {
            towerGroup.Add(new Tower(Input.player.X, Input.player.Y, towerAtkDamage, towerGrade, spawnTowerName));

            Maps.map[Input.player.X, Input.player.Y] = (int)spawnTowerName;

            string towerName = "";

            switch (spawnTowerName)
            {
                // 노말 타워
                case Maps.MapState.NORMALCONSONANT:
                    towerName = "[노말] 자음 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALWORD:
                    towerName = "[노말] 단어 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALALPHA:
                    towerName = "[노말] 알파벳 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALLASOR:
                    towerName = "[노말] 숫자 타워";
                    Input.player.Money -= 100;
                    break;

                // 매직 타워
                case Maps.MapState.MAGICCONSONANT:
                    towerName = "[매직] 자음 타워";
                    break;
                case Maps.MapState.MAGICWORD:
                    towerName = "[매직] 단어 타워";
                    break;
                case Maps.MapState.MAGICALPHA:
                    towerName = "[매직] 알파벳 타워";
                    break;
                case Maps.MapState.MAGICLASOR:
                    towerName = "[매직] 숫자 타워";
                    break;

                // 레어 타워
                case Maps.MapState.RARECONSONANT:
                    towerName = "[레어] 자음 타워";
                    break;
                case Maps.MapState.RAREWORD:
                    towerName = "[레어] 단어 타워";
                    break;
                case Maps.MapState.RAREALPHA:
                    towerName = "[레어] 알파벳 타워";
                    break;
                case Maps.MapState.RARELASOR:
                    towerName = "[레어] 숫자 타워";
                    break;

                // 에픽 타워
                case Maps.MapState.EPICCONSONANT:
                    towerName = "[에픽] 자음 타워";
                    break;
                case Maps.MapState.EPICWORD:
                    towerName = "[에픽] 단어 타워";
                    break;
                case Maps.MapState.EPICALPHA:
                    towerName = "[에픽] 알파벳 타워";
                    break;
                case Maps.MapState.EPICLASOR:
                    towerName = "[에픽] 숫자 타워";
                    break;

                // 전설 타워
                case Maps.MapState.LEGENDCONSONANT:
                    towerName = "[전설] 자음 타워";
                    break;
                case Maps.MapState.LEGENDWORD:
                    towerName = "[전설] 단어 타워";
                    break;
                case Maps.MapState.LEGENDALPHA:
                    towerName = "[전설] 알파벳 타워";
                    break;
                case Maps.MapState.LEGENDLASOR:
                    towerName = "[전설] 숫자 타워";
                    break;
            }

            Console.SetCursorPosition(15, 16);
            Console.WriteLine($"{towerName} 건설                       ");


        }

        public static void TowerAttack()
        {
            if (towerGroup.Count == 0 || attackTimer.Count != 0)
                return;

            List<Enemy> enemies = EnemySpawner.enemies;

            for (int i = 0; i < towerGroup.Count; i++)
            {
                Tower tower = towerGroup[i];

                foreach (Enemy enemy in enemies)
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

        public static void MixTowerSpawn(Maps.MapState currentGradeTower, Maps.MapState nextGradeTower)
        {
            List<Tower> gradeUpTower = new List<Tower>();
            gradeUpTower.Clear();

            for (int i = 0; i < Maps.map.GetLength(0); i++)
            {
                for (int j = 0; j < Maps.map.GetLength(1); j++)
                {
                    foreach (var tower in towerGroup)
                    {
                        Maps.MapState checkTower = (Maps.MapState)Maps.map[i, j];

                        if (checkTower == currentGradeTower && tower.X == i && tower.Y == j)
                        {
                            gradeUpTower.Add(tower);

                        }
                    }
                }
            }

            if (gradeUpTower.Count > 1)
            {
                Tower? firstTower = null;
                Tower? secondTower = null;

                foreach (var tower in gradeUpTower)
                {
                    if (tower.X == Input.player.X && tower.Y == Input.player.Y)
                    {
                        firstTower = tower;
                    }
                    else
                    {
                        secondTower = tower;
                    }
                }

                towerGroup.Remove(firstTower);
                towerGroup.Remove(secondTower);
                Maps.map[firstTower.X, firstTower.Y] = (int)Maps.MapState.BUILD;
                Maps.map[secondTower.X, secondTower.Y] = (int)Maps.MapState.BUILD;
                TowerSpawn(firstTower.Atk + 10, firstTower.Grade + 1, nextGradeTower);
                return;
            }
        }

        public static void SellTower()
        {
            Queue<Tower> sellTower = new Queue<Tower>();

            if (Maps.map[Input.player.X, Input.player.Y] != 0 && Maps.map[Input.player.X, Input.player.Y] != 1)
            {
                foreach (var tower in towerGroup)
                {
                    sellTower.Enqueue(tower);
                }

                foreach (var tower in sellTower)
                {
                    towerGroup.Remove(tower);
                }

                Maps.map[Input.player.X, Input.player.Y] = (int)Maps.MapState.BUILD;
                Console.SetCursorPosition(15, 16);
                Console.WriteLine("타워를 판매했습니다.             ");
                Input.player.Money += 50;
                sellTower.Clear();
            }

        }
    }
}
