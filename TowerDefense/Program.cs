﻿
using System;
using System.Diagnostics;

namespace TowerDefense
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(82, 40);

            GameManager.Menu();

            GameManager.GameStart();

            
        }
    }
}
