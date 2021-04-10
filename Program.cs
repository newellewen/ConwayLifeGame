using System;
using System.Linq;
using System.Collections.Generic;
using ConwayLifeGame.Controllers;
using ConwayLifeGame.Models;


namespace ConwayLifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cell> cells = new List<Cell>();

            cells.Add(new Cell(3, 2, true));
            cells.Add(new Cell(3, 3, true));
            cells.Add(new Cell(3, 4, true));
            cells.Add(new Cell(3, 5, true));

            GameController game = new GameController(cells);


            //TODO - Iterations!
            game.PrintState();
            game.Go();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            game.PrintState();
            game.Go();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            game.PrintState();
            game.Go();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            game.PrintState();

        }
    }
}
