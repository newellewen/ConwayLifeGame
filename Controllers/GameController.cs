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
            CheckRulesTask();
            //CheckRules.Wait();

            ApplyRulesTask();
            //ApplyRules.Wait();
        }

        private void FillList()
        {
            //TODO - account for negatives
            int x_max = cells.Max(cell => cell.x);
            int y_max = cells.Max(cell => cell.y);

            for (int i = 0; i < x_max; i++)
            {
                for (int j = 0; j < y_max; j++)
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
            foreach(Cell cell in cells)
            {
                Console.WriteLine(cell);
                foreach(Cell neighbour in cell.neighbours)
                {
                    Console.WriteLine("      " + neighbour);
                }
            }
        }


        private void CheckRulesTask()
        {
            cellsToKill = new List<Cell>();
            cellsToResurrect = new List<Cell>();

            foreach (Cell cell in cells)
            {
                int liveNeighbours = cell.neighbours.Where(cell => cell.IsAlive()).Count();
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


    //    private Task CheckRulesTask()
    //    {
    //        return Task.Factory.StartNew(delegate ()
    //        {
    //            cellsToKill = new List<Cell>();
    //            cellsToResurrect = new List<Cell>();

    //            foreach (Cell cell in cells)
    //            {
    //                int liveNeighbours = cell.neighbours.Where(cell => cell.IsAlive()).Count();
    //                if (cell.IsAlive())
    //                {
    //                    if (liveNeighbours < 2 || liveNeighbours > 3)
    //                    {
    //                        cellsToKill.Add(cell);
    //                    }
    //                } else
    //                {
    //                    if (liveNeighbours == 3)
    //                    {
    //                        cellsToResurrect.Add(cell);
    //                    }
    //                }
    //            }
    //        });
    //    }

    //    private Task ApplyRulesTask()
    //    {
    //        return Task.Factory.StartNew(delegate ()
    //        {
    //            foreach (Cell cell in cellsToKill)
    //            {
    //                cells.Find(_cell => cell.Equals(cell)).Kill();
    //            }

    //            foreach (Cell cell in cellsToResurrect)
    //            {
    //                cells.Find(_cell => cell.Equals(cell)).Resurrect();
    //            }
    //        });
    //    }

    //}
}
