using TowerDefense.Map;
using TowerDefense.Unit;

namespace TowerDefense.RandomTower
{
    internal class RandomTower
    {
        public const int towerWidthRange = 5;
        public const int towerHeightRange = 5;


        public static int BuildTowerNumber()
        {
            Random random = new Random();
            int randomTower = random.Next(2, 6);

            return randomTower;
        }

        public static int[,] towerRange = new int[towerWidthRange,towerHeightRange];


        public static void ShowRange()
        {



        }



    }
}
