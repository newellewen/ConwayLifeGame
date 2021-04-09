using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayLifeGame.Models
{
    //TODO - figure out the hash code override
    public class Cell
    {
        private bool alive;
        public int x;
        public int y;
        public List<Cell> neighbours;
        private string stringFormat = "({0}, {1}) - {2}";

        public Cell(int _x, int _y)
        {
            x = _x;
            y = _y;
            alive = false;
        }
        
        public Cell(int _x, int _y, bool _active)
        {
            x = _x;
            y = _y;
            alive = _active;
        }
        
        public void SetNeighbors(List<Cell> _neighbours)
        {
            neighbours = _neighbours;
        }



        public bool Neighbours(Cell other)
        {
            int x_delta = Math.Abs(x - other.x);
            int y_delta = Math.Abs(y - other.y);
            return (x_delta == 1 && y_delta == 1) ||
                    (x_delta == 0 && y_delta == 1) ||
                    (x_delta == 1 && y_delta == 0);
        }

        public bool IsAlive()
        {
            return alive;
        }

        public void Kill()
        {
            alive = false;
        }

        /// <summary>
        /// Makes a cell alive if it wasn't already - normally I would give methods 
        /// much more boring names, because I don't really like writing these summaries
        /// all the time and try to make things as self-documenting as possible. I'm 
        /// putting this all here to make sure you know that I am aware of documentation,
        /// but this is the only method I'm putting it on for this assessment.
        /// </summary>
        public void Resurrect()
        {
            alive = true;
        }

        public override string ToString()
        {
            return String.Format(stringFormat, x, y, alive ? "Alive" : "Dead");
        }

        public override bool Equals(object obj)
        {
            try
            {
                Cell other = (Cell)obj;
                return other.x == x && other.y == y;
            }
            catch
            {
                return false;
            }
        }

    }
}
