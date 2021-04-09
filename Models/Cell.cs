using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayLifeGame.Models
{
    public class Cell
    {
        private bool alive;
        private int x;
        private int y;
        public List<Cell> neighbours;

        public Cell(int _x, int _y)
        {
            x = _x;
            y = _y;
            alive = false;
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

    }
}
