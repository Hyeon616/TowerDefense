using TowerDefense.Control;
using TowerDefense.Cooldown;
using TowerDefense.DisplayMenu;
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
            string towerGradeColor = "";
            ConsoleColor towerColor = ConsoleColor.White;

            switch (spawnTowerName)
            {
                // 노말 타워
                case Maps.MapState.NORMALCONSONANT:
                case Maps.MapState.NORMALWORD:
                case Maps.MapState.NORMALALPHA:
                case Maps.MapState.NORMALNUMBER:
                    towerColor = ConsoleColor.DarkGray;
                    break;

                // 매직 타워
                case Maps.MapState.MAGICCONSONANT:
                case Maps.MapState.MAGICWORD:
                case Maps.MapState.MAGICALPHA:
                case Maps.MapState.MAGICNUMBER:
                    towerColor = ConsoleColor.DarkGreen;
                    break;
                
                // 레어 타워
                case Maps.MapState.RARECONSONANT:
                case Maps.MapState.RAREWORD:
                case Maps.MapState.RAREALPHA:
                case Maps.MapState.RARENUMBER:
                    towerColor = ConsoleColor.DarkBlue;
                    break;

                // 에픽 타워
                case Maps.MapState.EPICCONSONANT:
                case Maps.MapState.EPICWORD:
                case Maps.MapState.EPICALPHA:
                case Maps.MapState.EPICNUMBER:
                    towerColor = ConsoleColor.DarkMagenta;
                    break;

                // 전설 타워
                case Maps.MapState.LEGENDCONSONANT:
                case Maps.MapState.LEGENDWORD:
                case Maps.MapState.LEGENDALPHA:
                case Maps.MapState.LEGENDNUMBER:
                    towerColor = ConsoleColor.DarkRed;
                    break;
                
            }

            Console.ForegroundColor = towerColor;

            switch (spawnTowerName)
            {
                // 노말 타워
                case Maps.MapState.NORMALCONSONANT:
                    towerGradeColor = "[노말] ";
                    towerName = "자음 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALWORD:
                    towerGradeColor = "[노말] ";
                    towerName = "단어 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALALPHA:
                    towerGradeColor = "[노말] ";
                    towerName = "알파벳 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALNUMBER:
                    towerGradeColor = "[노말] ";
                    towerName = "숫자 타워";
                    Input.player.Money -= 100;
                    break;

                // 매직 타워
                case Maps.MapState.MAGICCONSONANT:
                    towerGradeColor = "[매직] ";
                    towerName = "자음 타워";
                    break;
                case Maps.MapState.MAGICWORD:
                    towerGradeColor = "[매직] ";
                    towerName = "단어 타워";
                    break;
                case Maps.MapState.MAGICALPHA:
                    towerGradeColor = "[매직] ";
                    towerName = "알파벳 타워";
                    break;
                case Maps.MapState.MAGICNUMBER:
                    towerGradeColor = "[매직] ";
                    towerName = "숫자 타워";
                    break;

                // 레어 타워
                case Maps.MapState.RARECONSONANT:
                    towerGradeColor = "[레어] ";
                    towerName = "자음 타워";
                    break;
                case Maps.MapState.RAREWORD:
                    towerGradeColor = "[레어] ";
                    towerName = "단어 타워";
                    break;
                case Maps.MapState.RAREALPHA:
                    towerGradeColor = "[레어] ";
                    towerName = "알파벳 타워";
                    break;
                case Maps.MapState.RARENUMBER:
                    towerGradeColor = "[레어] ";
                    towerName = "숫자 타워";
                    break;

                // 에픽 타워
                case Maps.MapState.EPICCONSONANT:
                    towerGradeColor = "[에픽] ";
                    towerName = "자음 타워";
                    break;
                case Maps.MapState.EPICWORD:
                    towerGradeColor = "[에픽] ";
                    towerName = "단어 타워";
                    break;
                case Maps.MapState.EPICALPHA:
                    towerGradeColor = "[에픽] ";
                    towerName = "알파벳 타워";
                    break;
                case Maps.MapState.EPICNUMBER:
                    towerGradeColor = "[에픽] ";
                    towerName = "숫자 타워";
                    break;

                // 전설 타워
                case Maps.MapState.LEGENDCONSONANT:
                    towerGradeColor = "[전설] ";
                    towerName = "자음 타워";
                    break;
                case Maps.MapState.LEGENDWORD:
                    towerGradeColor = "[전설] ";
                    towerName = "단어 타워";
                    break;
                case Maps.MapState.LEGENDALPHA:
                    towerGradeColor = "[전설] ";
                    towerName = "알파벳 타워";
                    break;
                case Maps.MapState.LEGENDNUMBER:
                    towerGradeColor = "[전설] ";
                    towerName = "숫자 타워";
                    break;
            }

            UI.AlertUIPosition();
            Console.Write($"{towerGradeColor}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{towerName} ");
            Console.WriteLine("건설                       ");
        }

        public static void TowerAttack()
        {
            if (towerGroup.Count == 0 || attackTimer.Count != 0)
                return;

            List<Enemy> enemies = EnemySpawner.enemies;
            List<MissionEnemy> missionEnemies = EnemySpawner.missionEnemies;

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

                foreach (MissionEnemy missionEnemy in missionEnemies)
                {
                    int distanceX = Math.Abs(tower.X - missionEnemy.X);
                    int distanceY = Math.Abs(tower.Y - missionEnemy.Y);

                    if (distanceX <= 2 && distanceY <= 2)
                    {
                        missionEnemy.Hp -= tower.Atk;
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
                Tower firstTower = null;
                Tower secondTower = null;

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

                // 타워 소환
                switch (firstTower.TowerName)
                {
                    case Maps.MapState.NORMALCONSONANT:
                        TowerSpawn(firstTower.Atk + TowerInfo.consonantAtkUp*1, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.MAGICCONSONANT:
                        TowerSpawn(firstTower.Atk + TowerInfo.consonantAtkUp*2, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.RARECONSONANT:
                        TowerSpawn(firstTower.Atk + TowerInfo.consonantAtkUp*3, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.EPICCONSONANT:
                        TowerSpawn(firstTower.Atk + TowerInfo.consonantAtkUp*4, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.LEGENDCONSONANT:
                        TowerSpawn(firstTower.Atk + TowerInfo.consonantAtkUp*5, firstTower.Grade + 1, nextGradeTower);
                        break;

                    case Maps.MapState.NORMALWORD:
                        TowerSpawn(firstTower.Atk + TowerInfo.wordAtkUp*1, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.MAGICWORD:
                        TowerSpawn(firstTower.Atk + TowerInfo.wordAtkUp*2, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.RAREWORD:
                        TowerSpawn(firstTower.Atk + TowerInfo.wordAtkUp*3, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.EPICWORD:
                        TowerSpawn(firstTower.Atk + TowerInfo.wordAtkUp*4, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.LEGENDWORD:
                        TowerSpawn(firstTower.Atk + TowerInfo.wordAtkUp*5, firstTower.Grade + 1, nextGradeTower);
                        break;

                    case Maps.MapState.NORMALALPHA:
                        TowerSpawn(firstTower.Atk + TowerInfo.alphaAtkUp*1, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.MAGICALPHA:
                        TowerSpawn(firstTower.Atk + TowerInfo.alphaAtkUp*2, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.RAREALPHA:
                        TowerSpawn(firstTower.Atk + TowerInfo.alphaAtkUp*3, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.EPICALPHA:
                        TowerSpawn(firstTower.Atk + TowerInfo.alphaAtkUp*4, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.LEGENDALPHA:
                        TowerSpawn(firstTower.Atk + TowerInfo.alphaAtkUp*5, firstTower.Grade + 1, nextGradeTower);
                        break;

                    case Maps.MapState.NORMALNUMBER:
                        TowerSpawn(firstTower.Atk + TowerInfo.numberAtkUp*1, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.MAGICNUMBER:
                        TowerSpawn(firstTower.Atk + TowerInfo.numberAtkUp*2, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.RARENUMBER:
                        TowerSpawn(firstTower.Atk + TowerInfo.numberAtkUp*3, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.EPICNUMBER:
                        TowerSpawn(firstTower.Atk + TowerInfo.numberAtkUp*4, firstTower.Grade + 1, nextGradeTower);
                        break;
                    case Maps.MapState.LEGENDNUMBER:
                        TowerSpawn(firstTower.Atk + TowerInfo.numberAtkUp*5, firstTower.Grade + 1, nextGradeTower);
                        break;

                    default:
                        break;
                }

                return;
            }
            else
            {
                UI.AlertUIPosition();
                Console.WriteLine($"타워를 합성할 수 없습니다.                       ");
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
                UI.AlertUIPosition();
                Console.WriteLine("타워를 판매했습니다.             ");
                Input.player.Money += 50;
                sellTower.Clear();
            }

        }
    }
}
