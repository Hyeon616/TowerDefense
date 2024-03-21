﻿using TowerDefense.Control;
using TowerDefense.DisplayMenu;
using TowerDefense.Map;
using TowerDefense.Spawner;
using TowerDefense.TowerManager;

namespace TowerDefense
{
    internal class GameManager
    {
        public static void Menu()
        {
            while (true)
            {

                Console.SetCursorPosition(0, 0);
                UI.MainMenu();
                Input.GameMenuInput();

                if (Input.gameStart > 0)
                {
                    Console.Clear();
                    break;
                }
                    

            }

        }


        public static void GameStart()
        {

            while (true)
            {

                
                Maps.PrintMap(Input.player, EnemySpawner.enemies,EnemySpawner.missionEnemies);

                UI.DrawLine();
                UI.PlayerUI(Input.player);
                UI.EnemyHpUI(EnemySpawner.enemies);
                UI.EnemyHpUI(EnemySpawner.missionEnemies);
                UI.WaveTimeUI(EnemySpawner.waveTimer);
                UI.MissionTimeUI(EnemySpawner.missionTimer);


                EnemySpawner.AddEnemy();

                Input.GamePlayInput(Input.player);
                
                RandomTower.TowerAttack();

                EnemyMovement.EnemyMove(EnemySpawner.enemies, EnemySpawner.missionEnemies);

            }


        }


    }
}
