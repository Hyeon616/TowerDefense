using System.Threading;
using System.Timers;
using TowerDefense.Map;
using TowerDefense.Spawner;
using TowerDefense.Unit;

namespace TowerDefense.RandomTower
{
    internal class SetTower
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

        

    }
}
