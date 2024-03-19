using TowerDefense.Unit;
using TowerDefense.Cooldown;
using TowerDefense.Map;

namespace TowerDefense.DisplayMenu
{
    internal class UI
    {

        public static void PlayerUI(Player player)
        {
            Console.SetCursorPosition(30, 5);
            Console.WriteLine($"플레이어 돈 : {player.Money}        ");
            Console.SetCursorPosition(30, 6);
            Console.WriteLine($"플레이어 체력 : {player.Hp}         ");
            
        }

        public static void EnemyHpUI(List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.SetCursorPosition(9, 20+i);
                Console.WriteLine($"{enemies[i].ID}번적 체력 : {enemies[i].Hp}         ");
                
            }
        }

        public static void WaveTimeUI(WaveTimer waveTimer)
        {
            Console.SetCursorPosition(30, 1);
            Console.Write($"웨이브 시작 시간 : {waveTimer.Count}         ");
        }

        
        

    }
}
