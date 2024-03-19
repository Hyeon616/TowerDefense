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
                case Maps.MapState.NORMALMUSIC:
                    towerName = "[노말] 음악 타워";
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
                    break;
                case Maps.MapState.MAGICMUSIC:
                    break;
                case Maps.MapState.MAGICLASOR:
                    break;

                // 레어 타워
                case Maps.MapState.RARESTAR:
                    break;
                case Maps.MapState.RARESPADE:
                    break;
                case Maps.MapState.RAREMUSIC:
                    break;
                case Maps.MapState.RARELASOR:
                    break;

                // 에픽 타워
                case Maps.MapState.EPICSTAR:
                    break;
                case Maps.MapState.EPICSPADE:
                    break;
                case Maps.MapState.EPICMUSIC:
                    break;
                case Maps.MapState.EPICLASOR:
                    break;

                // 전설 타워
                case Maps.MapState.LEGENDSTAR:
                    break;
                case Maps.MapState.LEGENDSPADE:
                    break;
                case Maps.MapState.LEGENDMUSIC:
                    break;
                case Maps.MapState.LEGENDLASOR:
                    break;
            }

            Console.SetCursorPosition(15, 16);
            Console.WriteLine($"{towerName} 건설                       ");

        }

        public static void TowerMix()
        {
            int count = 0;
            for (int i = 0; i < Maps.map.GetLength(0); i++)
            {
                for (int j = 0; j < Maps.map.GetLength(1); j++)
                {
                    Maps.MapState checkTower = (Maps.MapState)Maps.map[i, j];
                    
                    foreach (var t in towerGroup)
                    {
                        if (checkTower == Maps.MapState.NORMALMUSIC && t.Grade==1)
                        {
                            count++;

                            if(count==2)
                            {
                                if(t.Grade == 1)
                                    towerGroup.Remove(t);
                            }

                        }
                    }

                }
            }
        }
    }
}
