using TowerDefense.Spawner;
using TowerDefense.Unit;

namespace TowerDefense
{
    internal class UI
    {

        public static void PlayerUI(Player player)
        {
            Console.SetCursorPosition(15, 18);
            Console.WriteLine($"플레이어 돈 : {player.Money}        ");
            Console.SetCursorPosition(15, 19);
            Console.WriteLine($"플레이어 체력 : {player.Hp}         ");
        }

        public static void EnemyHpUI(List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.SetCursorPosition(9, 20+i);
                Console.WriteLine($"{i+1}번적 체력 : {enemies[i].Hp}         ");
            }
        }

        public static void WaveTimeUI(RoundTime roundTime)
        {
            Console.SetCursorPosition(15, 25);
            Console.Write($"웨이브 시작 시간 : {roundTime.Count}         ");
        }
        



    }
}
