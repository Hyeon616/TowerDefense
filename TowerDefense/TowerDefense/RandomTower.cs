namespace Tower
{
    internal class RandomTower
    {
        public static int BuildTowerNumber()
        {
            Random random = new Random();
            int randomTower = random.Next(2, 5);

            return randomTower;
        }




    }
}
