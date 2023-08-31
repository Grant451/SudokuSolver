using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicSquares
{
    internal class SudokuGridSection
    {

        public int[] gridSolutions { get; set; }
        
        public SudokuGridSection()
        {
            gridSolutions = new int[9];
            for(int x=0; x<gridSolutions.Length; x++)
            {
                gridSolutions[x] = x + 1;
            }
        }

        //determins if the possible solutions lists contains the solution
        public Boolean containsSolution(int searchInteger)
        {
            Boolean ans = false;
            for (int i = 0; i < gridSolutions.Length; i++)
            {
                int testInteger = gridSolutions[i];
                if (testInteger == searchInteger)
                {
                    ans = true;
                    break;
                }
            }
            return ans;
        }

        
    }
}
