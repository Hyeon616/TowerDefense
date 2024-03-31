using TowerDefense.Cooldown;
using TowerDefense.Drawing;
using TowerDefense.Unit;

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

            string[] lines = title.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (i < 7)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (i > 6 && i < 9)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else if (i > 8 && i < 15)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                Console.WriteLine(lines[i]);
                //Thread.Sleep(200);
            }

            Console.SetCursorPosition(20, 30);
            Console.WriteLine("방향키 ↑ ↓로 고르고 Enter를 눌러주세요.");

        }
        public void DrawLine()
        {
            DrawingUI.TestMain();

        }

        public static void PlayerUI(Player player)
        {

            Console.SetCursorPosition(8, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"♥ ");
            Console.ResetColor();
            Console.SetCursorPosition(10, 3);
            Console.WriteLine($" : {player.Hp}");

            Console.SetCursorPosition(8, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"$ ");
            Console.ResetColor();
            Console.SetCursorPosition(10, 5);
            Console.WriteLine($" : {player.Money}");

        }

        public static void EnemyHpUI(List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.SetCursorPosition(2, 16 + i);
                Console.WriteLine($"{enemies[i].ID}번적 체력 : {enemies[i].Hp}    ");
                Console.WriteLine();

            }
        }

        public static void EnemyHpUI(List<MissionEnemy> missionEnemies)
        {
            for (int i = 0; i < missionEnemies.Count; i++)
            {
                Console.SetCursorPosition(2, 14 + i);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($" 적 체력 : {missionEnemies[i].Hp} ");
                Console.ResetColor();

                Console.SetCursorPosition(33,29);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{missionEnemies[i].MissionEnemyName} 시작");
                Console.ResetColor();
            }

        }
        public static void WaveTimeUI(WaveTimer waveTimer)
        {
            Console.SetCursorPosition(30, 3);
            Console.Write($"웨이브 시작 시간 : {waveTimer.Count}   ");
        }

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        public static void MissionTimeUI(MissionTimer missionTimer)
        {
            Console.SetCursorPosition(31, 5);
            Console.Write($"미션 시작 시간 : {missionTimer.Count}   ");
        }


        public static void AlertUIPosition()
        {
            Console.SetCursorPosition(29, 27);
        }

        public static void UpdateEnemyHpUI()
        {
            for (int i = 14; i < 21; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("                        ");
            }
        }

<<<<<<< Updated upstream
=======
        public static void ProcessUI()
        {
            
            Process currentProcess = Process.GetCurrentProcess();
            Console.SetCursorPosition(2, 26);
            Console.WriteLine("메모리 사용량: {0} KB", currentProcess.WorkingSet64 / 1024);

            // 필요한 경우 기타 속성도 출력 가능
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("가상 메모리 사용량: {0} KB", currentProcess.VirtualMemorySize64 / 1024);
            Console.SetCursorPosition(2, 28);
            Console.WriteLine("페이지 파일 사용량: {0} KB", currentProcess.PagedMemorySize64 / 1024);

            // 프로세스 객체를 사용한 후에는 반드시 리소스를 해제해야 합니다.
            currentProcess.Dispose();
        }












>>>>>>> Stashed changes
    }
}
