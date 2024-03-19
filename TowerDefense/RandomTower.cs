using TowerDefense.Control;
using TowerDefense.Map;
using TowerDefense.Unit;

namespace TowerDefense.TowerManager
{
    internal class RandomTower
    {

        public const int towerWidthRange = 5;
        public const int towerHeightRange = 5;

        public static List<Tower> towerGroup = new List<Tower>();

        public static int BuildTowerNumber()
        {
            Random random = new Random();
            int randomTower = random.Next(2, 6);

            return randomTower;
        }
        public static void SpawnTower(Maps.MapState towerState, int towerAtkDamage, int towerAtkSpeed, int towerGrade)
        {
            Maps.map[Input.player.X, Input.player.Y] = (int)towerState;
            towerGroup.Add(new Tower(Input.player.X, Input.player.Y, towerAtkDamage, towerAtkSpeed, towerGrade));

            string towerName = "";

            switch (towerState)
            {
                // 노말 타워
                case Maps.MapState.NORMALSTAR:
                    towerName = "[노말] 별 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALSPADE:
                    towerName = "[노말] 스페이드 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALHEART:
                    towerName = "[노말] 하트 타워";
                    Input.player.Money -= 100;
                    break;
                case Maps.MapState.NORMALLASOR:
                    towerName = "[노말] 레이저 타워";
                    Input.player.Money -= 100;
                    break;

                // 매직 타워
                case Maps.MapState.MAGICSTAR:
                    towerName = "[매직] 별 타워";
                    break;
                case Maps.MapState.MAGICSPADE:
                    towerName = "[매직] 스페이드 타워";
                    break;
                case Maps.MapState.MAGICHEART:
                    towerName = "[매직] 하트 타워";
                    break;
                case Maps.MapState.MAGICLASOR:
                    towerName = "[매직] 레이저 타워";
                    break;

                // 레어 타워
                case Maps.MapState.RARESTAR:
                    towerName = "[레어] 별 타워";
                    break;
                case Maps.MapState.RARESPADE:
                    towerName = "[레어] 스페이드 타워";
                    break;
                case Maps.MapState.RAREHEART:
                    towerName = "[레어] 하트 타워";
                    break;
                case Maps.MapState.RARELASOR:
                    towerName = "[레어] 레이저 타워";
                    break;

                // 에픽 타워
                case Maps.MapState.EPICSTAR:
                    towerName = "[에픽] 별 타워";
                    break;
                case Maps.MapState.EPICSPADE:
                    towerName = "[에픽] 스페이드 타워";
                    break;
                case Maps.MapState.EPICHEART:
                    towerName = "[에픽] 하트 타워";
                    break;
                case Maps.MapState.EPICLASOR:
                    towerName = "[에픽] 레이저 타워";
                    break;

                // 전설 타워
                case Maps.MapState.LEGENDSTAR:
                    towerName = "[전설] 별 타워";
                    break;
                case Maps.MapState.LEGENDSPADE:
                    towerName = "[전설] 스페이드 타워";
                    break;
                case Maps.MapState.LEGENDHEART:
                    towerName = "[전설] 하트 타워";
                    break;
                case Maps.MapState.LEGENDLASOR:
                    towerName = "[전설] 레이저 타워";
                    break;
            }

            Console.SetCursorPosition(15, 16);
            Console.WriteLine($"{towerName} 건설                       ");

        }

        public static void TowerMix(int grade, Maps.MapState currentGrageTower, Maps.MapState nextGrageTower)
        {

            List<Tower> gradeUpTower = new List<Tower>();
            for (int i = 0; i < Maps.map.GetLength(0); i++)
            {
                for (int j = 0; j < Maps.map.GetLength(1); j++)
                {
                    Maps.MapState checkTower = (Maps.MapState)Maps.map[i, j];

                    foreach (var tower in towerGroup)
                    {
                        if (checkTower == currentGrageTower && tower.Grade == grade)
                        {
                            gradeUpTower.Add(tower);

                            if (gradeUpTower.Count > 1)
                                break;

                        }
                    }

                    if (gradeUpTower.Count > 1)
                    {
                        foreach (var tower in gradeUpTower)
                        {
                            //Maps.map[Input.player.X, Input.player.Y] = (int)nextGrageTower;
                            //SpawnTower();
                        }

                    }
                }
            }



        }
    }
}
