using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using ConwayLifeGame.Models;

namespace ConwayLifeGame.Controllers
{
    public class GameController
    {
        private List<Cell> cells;
        private List<Cell> cellsToKill;
        private List<Cell> cellsToResurrect;
        private Task CheckRules;
        private Task ApplyRules;


        public GameController(List<Cell> seed)
        {
            cells = seed;
            FillList();
            SetNeighbours();
        }

        public void Go()
        {
            //TODO - something better with the max+2 in FillList, handle positive/negative coordinates or apply transform
            FillList();

            //TODO - something better than setting the neighbors every single time
            SetNeighbours();

            CheckRulesTask();

            ApplyRulesTask();
        }

        private void FillList()
        {
            //TODO - account for negatives
            int x_max = cells.Max(cell => cell.x);
            int y_max = cells.Max(cell => cell.y);

            for (int i = 0; i < x_max + 2; i++)
            {
                for (int j = 0; j < y_max + 2; j++)
                {
                    Cell cell = new Cell(i, j);
                    if (cells.Where(_cell => _cell.Equals(cell)).Count() == 0)
                    {
                        cells.Add(cell);
                    }
                }
            }
        }

        private void SetNeighbours()
        {
            foreach (Cell cell in cells)
            {
                List<Cell> neigbours = cells.FindAll(_cell => _cell.Neighbours(cell));
                cell.SetNeighbors(neigbours);
            }
        }

        public void PrintState()
        {
            foreach(Cell cell in cells.Where(_cell => _cell.IsAlive()))
            {
                Console.WriteLine(cell);
                //foreach(Cell neighbour in cell.neighbours)
                //{
                //    Console.WriteLine("      " + neighbour);
                //}
            }
        }


        private void CheckRulesTask()
        {
            cellsToKill = new List<Cell>();
            cellsToResurrect = new List<Cell>();

            foreach (Cell cell in cells)
            {
                int liveNeighbours = cell.neighbours.Where(_cell => _cell.IsAlive()).Count();
                if (cell.IsAlive())
                {
                    if (liveNeighbours < 2 || liveNeighbours > 3)
                    {
                        cellsToKill.Add(cell);
                    }
                }
                else
                {
                    if (liveNeighbours == 3)
                    {
                        cellsToResurrect.Add(cell);
                    }
                }
            }
        }

        private void ApplyRulesTask()
        {
            foreach (Cell cell in cellsToKill)
            {
                cells.Find(_cell => cell.Equals(_cell)).Kill();
            }

            foreach (Cell cell in cellsToResurrect)
            {
                cells.Find(_cell => cell.Equals(_cell)).Resurrect();
            }
        }

    }

}
