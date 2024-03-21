
namespace TowerDefense
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            Console.SetWindowSize(80, 40);


            GameManager.Menu();

            GameManager.GameStart();
            
        }
    }
}
