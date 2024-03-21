using TowerDefense.Unit;
using TowerDefense.Cooldown;
using TowerDefense.Map;

namespace TowerDefense.DisplayMenu
{
    internal class UI
    {
        public static void MainMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string title = @"
______                    _                     
| ___ \                  | |                    
| |_/ /  __ _  _ __    __| |  ___   _ __ ___    
|    /  / _` || '_ \  / _` | / _ \ | '_ ` _ \   
| |\ \ | (_| || | | || (_| || (_) || | | | | |  
\_| \_| \__,_||_| |_| \__,_| \___/ |_| |_| |_|  
 _____                              
|_   _|                             
  | |    ___  __      __  ___  _ __ 
  | |   / _ \ \ \ /\ / / / _ \| '__|
  | |  | (_) | \ V  V / |  __/| |   
  \_/   \___/   \_/\_/   \___||_|   
 
______         __                         
|  _  \       / _|                        
| | | |  ___ | |_   ___  _ __   ___   ___ 
| | | | / _ \|  _| / _ \| '_ \ / __| / _ \
| |/ / |  __/| |  |  __/| | | |\__ \|  __/
|___/   \___||_|   \___||_| |_||___/ \___|
        
";
            Console.WriteLine(title);
            Console.ReadKey();
        }


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
