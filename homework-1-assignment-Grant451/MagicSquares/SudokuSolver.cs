using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace MagicSquares
{
    internal class SudokuSolver
    {
        //zero represents a number that has not been found yet
        //-1 represents a number that is not a possiblity

        int[,] game { get; set; }//the game board as an array (final result to be returned)

        //the game board as a set of Soduku Squares
        //this is used to represent the possible solutions in a cell
        SudokuSquare[,] sudokuCells { get; set; }

        //represents the different grids 1-9
        //1,2,3
        //4,5,6
        //7,8,9
        int[] grids { get; set; }

        //the different grids that represent the sudoku board.
        SudokuGridSection[] sudokuGrids { get; set; }

        public SudokuSolver(int[,] StartingNumbers)
        {
            grids = new int[9];
            sudokuGrids = new SudokuGridSection[9];//set the number of grids to 9
            sudokuCells = new SudokuSquare[9, 9];
            for (int i=0; i< grids.Length; i++)
            {
                grids[i] = i + 1;
            }//initialize grids 1-9
            game = StartingNumbers;
            InitializeGridSolutions();
            
        }

        //Solve the Sudoku game
        public int[,] Solve()
        {
            for (int x = 0; x < game.GetLength(0); x ++)
            {
                for (int y = 0; y < game.GetLength(1); y ++)
                {   
                    var existingNum = game[x, y];
                    SudokuSquare temp = new SudokuSquare();
                    //remove the initial Duplicates and init. the sudokuCells array
                    if (existingNum != 0)
                    {
                        sudokuCells[x, y] = RemoveInitialDuplicates(temp, existingNum);
                    }
                    else
                    {
                        sudokuCells[x, y] = temp;
                    }
                    
                }
            }
            Boolean updated;
            int strikes = 0;
            while(checkForSolution() == false){
                updated = false;
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        int currentGrid = GetGridFromCords(x, y);
                        if (grids[currentGrid-1] == -1) { break; }
                        var currentCell = sudokuCells[x, y];
                        if (currentCell.value == 0 && grids[currentGrid-1] != -1) {//if the cell hasn't been solved and the grid hasn't been solved
                            sudokuCells[x, y] = RemoveGridDuplicatesFromSodokuCell(currentCell, currentGrid);
                            int solAfterGridCleanup = sudokuCells[x, y].value;
                            if (solAfterGridCleanup != 0)
                            {
                                game[x, y] = solAfterGridCleanup;
                                updated = true;
                                break;
                            }
                            else
                            {
                                sudokuCells[x, y] = RemoveRowDuplicates(sudokuCells[x,y], x);
                                int solAfterRowCleanup = sudokuCells[x, y].value;
                                if (solAfterRowCleanup != 0)
                                {
                                    game[x,y] = solAfterRowCleanup;
                                    updated = true;
                                    break;
                                }
                                else
                                {
                                    //Remove the column Duplicates
                                    sudokuCells[x, y] = RemoveColumnDuplicates(sudokuCells[x,y], y);
                                    int solAfterColumnCleanUp = sudokuCells[x, y].value;
                                    if (solAfterColumnCleanUp != 0)
                                    {
                                        game[x, y] = solAfterColumnCleanUp;
                                        updated = true;
                                        break;
                                    }
                                }
                            }
                        }
                    
                    }
                }

                if (updated == false || strikes == 10)
                {
                    MessageBox.Show("Suspect no solution, please change start values");
                    break;
                }
                else
                {
                    strikes++;
                }
            }


            return game;
        }

        //if the puzzle is solved return true
        public Boolean checkForSolution()
        {
            Boolean ans = true;
            //check for blanks
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (game[x,y] == 0)
                    {
                        ans = false;
                    }
                }
            }

            int[] rowCheck = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] rowCheckSave = rowCheck;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    int testVal = game[x,y];
                    if (rowCheck.Contains<int>(testVal))
                    {
                        rowCheck[testVal - 1] = -1;
                    }
                }
                for (int index = 0; index< 9; index++) {
                    if (rowCheck[index] != -1) {
                        ans = false; 
                        break; 
                    } 
                }
                rowCheck = rowCheckSave;
            }

            int[] columnCheck = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] columnCheckSave = columnCheck;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    int testVal = game[y, x];
                    if (columnCheck.Contains<int>(testVal))
                    {
                        columnCheck[testVal - 1] = -1;
                    }
                }
                for (int index = 0; index < 9; index++)
                {
                    if (columnCheck[index] != -1)
                    {
                        ans = false;
                        break;
                    }
                }
                columnCheck = columnCheckSave;
            }

            return ans;
        }

        //remove any duplicates in the corrisponding column
        private SudokuSquare RemoveColumnDuplicates(SudokuSquare x, int column)
        {
            for (int i = 0; i < game.GetLength(0); i++)
            {
                int testInt = game[i, column];
                if (testInt != 0)
                {
                    for (int j = 0; j < sudokuCells.GetLength(0); j++)
                    {
                        if (sudokuCells[j, column].value == 0)
                        {
                            if (sudokuCells[j, column].possibleSolutions[testInt - 1] != -1)
                            {
                                sudokuCells[j, column].possibleSolutions[testInt - 1] = -1;
                            }

                        }
                    }
                }
            }

            //if the sudoku cell has been solved, set it's cell value.
            int solutionCount = 0;
            int ans = 0;
            Boolean solutionFound = false;
            for (int k = 0; k < 9; k++)
            {
                var thing = x;
                int possibleAns = x.possibleSolutions[k];
                if (possibleAns != -1)
                {
                    solutionFound = true;
                    ans = possibleAns;
                    solutionCount++;
                }
                if (solutionCount > 1)
                {
                    solutionFound = false;
                    break;
                }//no solution found
            }
            if (solutionFound)
            {
                x.value = ans;
            }

            return x;
        }

        //remove any duplicates in the corrisponding row.
        //If the cell contains only one solution, set the solution of the cell
        private SudokuSquare RemoveRowDuplicates(SudokuSquare x, int row)
        {
            for (int i = 0; i < game.GetLength(0); i++)
            {
                int testInt = game[row, i];
                if (testInt != 0)
                {
                    for (int j = 0; j < sudokuCells.GetLength(0); j++)
                    {
                        if (sudokuCells[row, j].value == 0)
                        {
                            if (sudokuCells[row,j].possibleSolutions[testInt-1] != -1)
                            {
                                sudokuCells[row, j].possibleSolutions[testInt-1] = -1;
                            }
                        }
                        
                    }
                }
            }

            //if the sudoku cell has been solved, set it's cell value.
            int solutionCount = 0;
            int ans = 0;
            Boolean solutionFound = false;
            for (int k = 0; k < 9; k++)
            {
                int possibleAns = x.possibleSolutions[k];
                if (possibleAns != -1)
                {
                    solutionFound = true;
                    ans = possibleAns;
                    solutionCount++;
                }
                if (solutionCount > 1)
                {
                    solutionFound = false;
                    break;
                }//no solution found
            }
            if (solutionFound)
            {
                x.value = ans;
            }

            return x;
        }

        //take in x,y coordinates, return the integer representing the grid number
        //if zero is returned a match could not be found.
        private int GetGridFromCords(int x, int y)
        {
            int ans = 0;
            if (x >= 0 && x < 3 && y >= 0 && y < 3)
            {
                ans = 1;
            }
            else if (x >= 0 && x < 3 && y >= 3 && y < 6)
            {
                ans = 2;
            }
            else if (x >= 0 && x < 3 && y >= 6 && y < 9)
            {
                ans = 3;
            }
            else if (x >= 3 && x < 6 && y >= 0 && y < 3)
            {
                ans = 4;
            }
            else if (x >= 3 && x < 6 && y >= 3 && y < 6)
            {
                ans = 5;
            }
            else if (x >= 3 && x < 6 && y >= 6 && y < 9)
            {
                ans = 6;
            }
            else if (x >= 6 && x < 9 && y >= 0 && y < 3)
            {
                ans = 7;
            }
            else if (x >= 6 && x < 9 && y >= 3 && y < 6)
            {
                ans = 8;
            }
            else if (x >= 6 && x < 9 && y >= 6 && y < 9)
            {
                ans = 9;
            }

            if (ans == 0)
            {
                MessageBox.Show("Error, no Grid detected");
            }
            return ans;
        }

        //take in a SudokuSquare, and a grid number
        //remove any grid duplicates not found in the SudokuSquare
        //if the sudoku cell has been solved, set it's grid position in "grids" to -1
        private SudokuSquare RemoveGridDuplicatesFromSodokuCell(SudokuSquare x, int grid)
        {
            int gridIndex = grid - 1;
            SudokuGridSection currentGridOBJ = sudokuGrids[gridIndex];//subtract 1 to represent the array position
            for (int i=0; i < currentGridOBJ.gridSolutions.Length; i++)
            {
                //if they match, set the position in the square to -1
                int testInt = currentGridOBJ.gridSolutions[i];
                if (testInt == -1)
                {
                    x.possibleSolutions[i] = -1;
                }
            }

            //if the sudoku cell has been solved, set it's cell value.
            int solutionCount = 0;
            int ans = 0;
            Boolean solutionFound = false;
            for (int j =0; j<9; j++)
            {
                int possibleAns = x.possibleSolutions[j];
                if (possibleAns != -1)
                {
                    solutionFound = true;
                    ans = possibleAns;
                    solutionCount++;
                }
                if (solutionCount > 1)
                {
                    solutionFound = false;
                    break;
                }//no solution found
            }
            if (solutionFound) { 
                x.value = ans;
            }


            return x;

        }

        //loop through the game and initialize all the possible values for the grid solutions
        private void InitializeGridSolutions()
        {
            for (int x = 0; x < grids.GetLength(0); x++)
            {
                //make a new grid section
                var temp = new SudokuGridSection();
                RemoveGrid(temp,x);//loop through the given grid and update the remaining values to fill in.
                sudokuGrids[x] = temp;
            }
        }

        //loop through a given grid and update the possible solutions in it.
        //if the given grid is marked as -1 in grids, it is complete.
        public void RemoveGrid(SudokuGridSection section, int grid)
        {
            grid++;//add 1 to grid to account for the array starting at 0
            var test = section;
            int startX, stopX, startY, stopY;
            if (grid == 1)
            {
                startX = 0; stopX = 3; startY = 0; stopY = 3;
            }
            else if (grid == 2)
            {
                startX = 0; stopX = 3; startY = 3; stopY = 6;
            }
            else if (grid == 3)
            {
                startX = 0; stopX = 3; startY = 6; stopY = 9;
            }
            else if (grid == 4)
            {
                startX = 3; stopX = 6; startY = 0; stopY = 3;
            }
            else if (grid == 5)
            {
                startX = 3; stopX = 6; startY = 3; stopY = 6;
            }
            else if (grid == 6)
            {
                startX = 3; stopX = 6; startY = 6; stopY = 9;
            }
            else if (grid == 7)
            {
                startX = 6; stopX = 9; startY = 0; stopY = 3;
            }
            else if (grid == 8)
            {
                startX = 6; stopX = 9; startY = 3; stopY = 6;
            }
            else if (grid == 9)
            {
                startX = 6; stopX = 9; startY = 6; stopY = 9;
            }
            else
            {
                startX = 0;
                stopX = 0;
                startY = 0;
                stopY = 0;
            }
            int startYHold = startY;
            while (startX < stopX )
            {
                while (startY < stopY)
                {
                    int testInt = game[startX,startY];
                    if (section.containsSolution(testInt) == true)
                    {
                        int[] sections = section.gridSolutions;
                        section.gridSolutions[testInt-1] = -1;
                    }

                    startY++;
                }
                startY = startYHold;//reset startY after each go round.
                startX++;
            }
        }

        //when creating grid squares remove the duplicate numbers
        //x represents the square to modify
        //itemsToRemove represents the numbers that need to be removed from the squares possible solutions.
        private SudokuSquare RemoveInitialDuplicates(SudokuSquare x, int itemToRemove)
        {
            x.value = itemToRemove;
            for (int i=0; i<x.possibleSolutions.Length; i++)
            {
                if (i == itemToRemove-1) {}
                else
                {
                    x.possibleSolutions[i] = -1;
                }
            }

            return x;
        }

        

    }
}
