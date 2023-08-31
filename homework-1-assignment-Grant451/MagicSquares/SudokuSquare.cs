using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares
{
    class SudokuSquare
    {
        //represents the solution of the cell, if 0, no solution has been found yet.
        //possible solutions are 1-9
        public int value { get; set; }

        public int[] possibleSolutions { get; set; }//represents the possible numbers for a given cell.


        public SudokuSquare()
        {
            possibleSolutions = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            value = 0;
        }
        
    }
}
