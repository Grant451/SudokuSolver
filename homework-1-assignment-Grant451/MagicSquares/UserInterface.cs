//Grant Clothier
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicSquares
{
    public partial class UserInterface : Form
    {

        /// <summary>
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();

        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleUserInput(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxSolve_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxHint_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxCheck_Click(object sender, EventArgs e)
        {

        }

        

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxNewGame_Click(object sender, EventArgs e)
        {
        }

        private void btnSolveSuduku_Click(object sender, EventArgs e)
        {
            //pull current text box values
            //pass the text box values as arrays to the constructor for the sudoku solver
            int[,] values = new int[9, 9] {
                { Convert.ToInt32(txt11.Text), Convert.ToInt32(txt12.Text), Convert.ToInt32(txt13.Text), Convert.ToInt32(txt14.Text), Convert.ToInt32(txt15.Text), Convert.ToInt32(txt16.Text), Convert.ToInt32(txt17.Text), Convert.ToInt32(txt18.Text), Convert.ToInt32(txt19.Text) } ,
                { Convert.ToInt32(txt21.Text), Convert.ToInt32(txt22.Text), Convert.ToInt32(txt23.Text), Convert.ToInt32(txt24.Text), Convert.ToInt32(txt25.Text), Convert.ToInt32(txt26.Text), Convert.ToInt32(txt27.Text), Convert.ToInt32(txt28.Text), Convert.ToInt32(txt29.Text) } ,
                { Convert.ToInt32(txt31.Text), Convert.ToInt32(txt32.Text), Convert.ToInt32(txt33.Text), Convert.ToInt32(txt34.Text), Convert.ToInt32(txt35.Text), Convert.ToInt32(txt36.Text), Convert.ToInt32(txt37.Text), Convert.ToInt32(txt38.Text), Convert.ToInt32(txt39.Text) } ,
                { Convert.ToInt32(txt41.Text), Convert.ToInt32(txt42.Text), Convert.ToInt32(txt43.Text), Convert.ToInt32(txt44.Text), Convert.ToInt32(txt45.Text), Convert.ToInt32(txt46.Text), Convert.ToInt32(txt47.Text), Convert.ToInt32(txt48.Text), Convert.ToInt32(txt49.Text) } ,
                { Convert.ToInt32(txt51.Text), Convert.ToInt32(txt52.Text), Convert.ToInt32(txt53.Text), Convert.ToInt32(txt54.Text), Convert.ToInt32(txt55.Text), Convert.ToInt32(txt56.Text), Convert.ToInt32(txt57.Text), Convert.ToInt32(txt58.Text), Convert.ToInt32(txt59.Text) } ,
                { Convert.ToInt32(txt61.Text), Convert.ToInt32(txt62.Text), Convert.ToInt32(txt63.Text), Convert.ToInt32(txt64.Text), Convert.ToInt32(txt65.Text), Convert.ToInt32(txt66.Text), Convert.ToInt32(txt67.Text), Convert.ToInt32(txt68.Text), Convert.ToInt32(txt69.Text) } ,
                { Convert.ToInt32(txt71.Text), Convert.ToInt32(txt72.Text), Convert.ToInt32(txt73.Text), Convert.ToInt32(txt74.Text), Convert.ToInt32(txt75.Text), Convert.ToInt32(txt76.Text), Convert.ToInt32(txt77.Text), Convert.ToInt32(txt78.Text), Convert.ToInt32(txt79.Text) } ,
                { Convert.ToInt32(txt81.Text), Convert.ToInt32(txt82.Text), Convert.ToInt32(txt83.Text), Convert.ToInt32(txt84.Text), Convert.ToInt32(txt85.Text), Convert.ToInt32(txt86.Text), Convert.ToInt32(txt87.Text), Convert.ToInt32(txt88.Text), Convert.ToInt32(txt89.Text) } ,
                { Convert.ToInt32(txt91.Text), Convert.ToInt32(txt92.Text), Convert.ToInt32(txt93.Text), Convert.ToInt32(txt94.Text), Convert.ToInt32(txt95.Text), Convert.ToInt32(txt96.Text), Convert.ToInt32(txt97.Text), Convert.ToInt32(txt98.Text), Convert.ToInt32(txt99.Text) } ,
            };
            var x = new SudokuSolver(values);
            //MessageBox.Show(x.GetType().ToString());
            var answers = x.Solve();
            txt11.Text = answers[0, 0].ToString();
            txt12.Text = answers[0, 1].ToString();
            txt13.Text = answers[0, 2].ToString();
            txt14.Text = answers[0, 3].ToString();
            txt15.Text = answers[0, 4].ToString();
            txt16.Text = answers[0, 5].ToString();
            txt17.Text = answers[0, 6].ToString();
            txt18.Text = answers[0, 7].ToString();
            txt19.Text = answers[0, 8].ToString();

            txt21.Text = answers[1, 0].ToString();
            txt22.Text = answers[1, 1].ToString();
            txt23.Text = answers[1, 2].ToString();
            txt24.Text = answers[1, 3].ToString();
            txt25.Text = answers[1, 4].ToString();
            txt26.Text = answers[1, 5].ToString();
            txt27.Text = answers[1, 6].ToString();
            txt28.Text = answers[1, 7].ToString();
            txt29.Text = answers[1, 8].ToString();

            txt31.Text = answers[2, 0].ToString();
            txt32.Text = answers[2, 1].ToString();
            txt33.Text = answers[2, 2].ToString();
            txt34.Text = answers[2, 3].ToString();
            txt35.Text = answers[2, 4].ToString();
            txt36.Text = answers[2, 5].ToString();
            txt37.Text = answers[2, 6].ToString();
            txt38.Text = answers[2, 7].ToString();
            txt39.Text = answers[2, 8].ToString();

            txt41.Text = answers[3, 0].ToString();
            txt42.Text = answers[3, 1].ToString();
            txt43.Text = answers[3, 2].ToString();
            txt44.Text = answers[3, 3].ToString();
            txt45.Text = answers[3, 4].ToString();
            txt46.Text = answers[3, 5].ToString();
            txt47.Text = answers[3, 6].ToString();
            txt48.Text = answers[3, 7].ToString();
            txt49.Text = answers[3, 8].ToString();

            txt51.Text = answers[4, 0].ToString();
            txt52.Text = answers[4, 1].ToString();
            txt53.Text = answers[4, 2].ToString();
            txt54.Text = answers[4, 3].ToString();
            txt55.Text = answers[4, 4].ToString();
            txt56.Text = answers[4, 5].ToString();
            txt57.Text = answers[4, 6].ToString();
            txt58.Text = answers[4, 7].ToString();
            txt59.Text = answers[4, 8].ToString();

            txt61.Text = answers[5, 0].ToString();
            txt62.Text = answers[5, 1].ToString();
            txt63.Text = answers[5, 2].ToString();
            txt64.Text = answers[5, 3].ToString();
            txt65.Text = answers[5, 4].ToString();
            txt66.Text = answers[5, 5].ToString();
            txt67.Text = answers[5, 6].ToString();
            txt68.Text = answers[5, 7].ToString();
            txt69.Text = answers[5, 8].ToString();

            txt71.Text = answers[6, 0].ToString();
            txt72.Text = answers[6, 1].ToString();
            txt73.Text = answers[6, 2].ToString();
            txt74.Text = answers[6, 3].ToString();
            txt75.Text = answers[6, 4].ToString();
            txt76.Text = answers[6, 5].ToString();
            txt77.Text = answers[6, 6].ToString();
            txt78.Text = answers[6, 7].ToString();
            txt79.Text = answers[6, 8].ToString();

            txt81.Text = answers[7, 0].ToString();
            txt82.Text = answers[7, 1].ToString();
            txt83.Text = answers[7, 2].ToString();
            txt84.Text = answers[7, 3].ToString();
            txt85.Text = answers[7, 4].ToString();
            txt86.Text = answers[7, 5].ToString();
            txt87.Text = answers[7, 6].ToString();
            txt88.Text = answers[7, 7].ToString();
            txt89.Text = answers[7, 8].ToString();

            txt91.Text = answers[8, 0].ToString();
            txt92.Text = answers[8, 1].ToString();
            txt93.Text = answers[8, 2].ToString();
            txt94.Text = answers[8, 3].ToString();
            txt95.Text = answers[8, 4].ToString();
            txt96.Text = answers[8, 5].ToString();
            txt97.Text = answers[8, 6].ToString();
            txt98.Text = answers[8, 7].ToString();
            txt99.Text = answers[8, 8].ToString();
        }

        private void template1ToolStripMenuItem_Click(object sender, EventArgs e)
        {//puzzle number 23 in the book
            txt11.Text = 5.ToString(); txt12.Text = 1.ToString(); txt13.Text = 6.ToString(); txt14.Text = 4.ToString(); txt15.Text = 0.ToString(); txt16.Text = 0.ToString(); txt17.Text = 0.ToString(); txt18.Text = 0.ToString(); txt19.Text = 3.ToString();
            txt21.Text = 0.ToString(); txt22.Text = 0.ToString(); txt23.Text = 7.ToString(); txt24.Text = 0.ToString(); txt25.Text = 8.ToString(); txt26.Text = 9.ToString(); txt27.Text = 0.ToString(); txt28.Text = 6.ToString(); txt29.Text = 5.ToString();
            txt31.Text = 2.ToString(); txt32.Text = 0.ToString(); txt33.Text = 0.ToString(); txt34.Text = 3.ToString(); txt35.Text = 5.ToString(); txt36.Text = 0.ToString(); txt37.Text = 0.ToString(); txt38.Text = 0.ToString(); txt39.Text = 0.ToString();

            txt41.Text = 0.ToString(); txt42.Text = 0.ToString(); txt43.Text = 2.ToString(); txt44.Text = 0.ToString(); txt45.Text = 0.ToString(); txt46.Text = 7.ToString(); txt47.Text = 0.ToString(); txt48.Text = 4.ToString(); txt49.Text = 0.ToString();
            txt51.Text = 0.ToString(); txt52.Text = 0.ToString(); txt53.Text = 5.ToString(); txt54.Text = 2.ToString(); txt55.Text = 0.ToString(); txt56.Text = 8.ToString(); txt57.Text = 6.ToString(); txt58.Text = 0.ToString(); txt59.Text = 0.ToString();
            txt61.Text = 0.ToString(); txt62.Text = 3.ToString(); txt63.Text = 0.ToString(); txt64.Text = 9.ToString(); txt65.Text = 0.ToString(); txt66.Text = 0.ToString(); txt67.Text = 5.ToString(); txt68.Text = 0.ToString(); txt69.Text = 0.ToString();

            txt71.Text = 0.ToString(); txt72.Text = 0.ToString(); txt73.Text = 0.ToString(); txt74.Text = 0.ToString(); txt75.Text = 4.ToString(); txt76.Text = 3.ToString(); txt77.Text = 0.ToString(); txt78.Text = 0.ToString(); txt79.Text = 2.ToString();
            txt81.Text = 8.ToString(); txt82.Text = 9.ToString(); txt83.Text = 0.ToString(); txt84.Text = 7.ToString(); txt85.Text = 2.ToString(); txt86.Text = 0.ToString(); txt87.Text = 1.ToString(); txt88.Text = 0.ToString(); txt89.Text = 0.ToString();
            txt91.Text = 7.ToString(); txt92.Text = 0.ToString(); txt93.Text = 0.ToString(); txt94.Text = 0.ToString(); txt95.Text = 0.ToString(); txt96.Text = 1.ToString(); txt97.Text = 8.ToString(); txt98.Text = 5.ToString(); txt99.Text = 4.ToString();
        }

        private void template24ToolStripMenuItem_Click(object sender, EventArgs e)
        {//puzzle number 24 in the book
            txt11.Text = 0.ToString(); txt12.Text = 3.ToString(); txt13.Text = 0.ToString(); txt14.Text = 0.ToString(); txt15.Text = 0.ToString(); txt16.Text = 0.ToString(); txt17.Text = 6.ToString(); txt18.Text = 0.ToString(); txt19.Text = 0.ToString();
            txt21.Text = 2.ToString(); txt22.Text = 0.ToString(); txt23.Text = 0.ToString(); txt24.Text = 0.ToString(); txt25.Text = 1.ToString(); txt26.Text = 9.ToString(); txt27.Text = 7.ToString(); txt28.Text = 0.ToString(); txt29.Text = 0.ToString();
            txt31.Text = 8.ToString(); txt32.Text = 0.ToString(); txt33.Text = 9.ToString(); txt34.Text = 3.ToString(); txt35.Text = 0.ToString(); txt36.Text = 0.ToString(); txt37.Text = 0.ToString(); txt38.Text = 2.ToString(); txt39.Text = 1.ToString();

            txt41.Text = 0.ToString(); txt42.Text = 1.ToString(); txt43.Text = 0.ToString(); txt44.Text = 0.ToString(); txt45.Text = 6.ToString(); txt46.Text = 0.ToString(); txt47.Text = 0.ToString(); txt48.Text = 9.ToString(); txt49.Text = 4.ToString();
            txt51.Text = 0.ToString(); txt52.Text = 8.ToString(); txt53.Text = 0.ToString(); txt54.Text = 7.ToString(); txt55.Text = 9.ToString(); txt56.Text = 2.ToString(); txt57.Text = 0.ToString(); txt58.Text = 6.ToString(); txt59.Text = 0.ToString();
            txt61.Text = 6.ToString(); txt62.Text = 9.ToString(); txt63.Text = 0.ToString(); txt64.Text = 0.ToString(); txt65.Text = 3.ToString(); txt66.Text = 0.ToString(); txt67.Text = 0.ToString(); txt68.Text = 5.ToString(); txt69.Text = 0.ToString();

            txt71.Text = 9.ToString(); txt72.Text = 5.ToString(); txt73.Text = 0.ToString(); txt74.Text = 0.ToString(); txt75.Text = 0.ToString(); txt76.Text = 1.ToString(); txt77.Text = 3.ToString(); txt78.Text = 0.ToString(); txt79.Text = 2.ToString();
            txt81.Text = 0.ToString(); txt82.Text = 0.ToString(); txt83.Text = 3.ToString(); txt84.Text = 2.ToString(); txt85.Text = 4.ToString(); txt86.Text = 0.ToString(); txt87.Text = 0.ToString(); txt88.Text = 0.ToString(); txt89.Text = 8.ToString();
            txt91.Text = 0.ToString(); txt92.Text = 0.ToString(); txt93.Text = 1.ToString(); txt94.Text = 0.ToString(); txt95.Text = 0.ToString(); txt96.Text = 0.ToString(); txt97.Text = 0.ToString(); txt98.Text = 7.ToString(); txt99.Text = 0.ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int[,] values = new int[9, 9] {
                { Convert.ToInt32(txt11.Text), Convert.ToInt32(txt12.Text), Convert.ToInt32(txt13.Text), Convert.ToInt32(txt14.Text), Convert.ToInt32(txt15.Text), Convert.ToInt32(txt16.Text), Convert.ToInt32(txt17.Text), Convert.ToInt32(txt18.Text), Convert.ToInt32(txt19.Text) } ,
                { Convert.ToInt32(txt21.Text), Convert.ToInt32(txt22.Text), Convert.ToInt32(txt23.Text), Convert.ToInt32(txt24.Text), Convert.ToInt32(txt25.Text), Convert.ToInt32(txt26.Text), Convert.ToInt32(txt27.Text), Convert.ToInt32(txt28.Text), Convert.ToInt32(txt29.Text) } ,
                { Convert.ToInt32(txt31.Text), Convert.ToInt32(txt32.Text), Convert.ToInt32(txt33.Text), Convert.ToInt32(txt34.Text), Convert.ToInt32(txt35.Text), Convert.ToInt32(txt36.Text), Convert.ToInt32(txt37.Text), Convert.ToInt32(txt38.Text), Convert.ToInt32(txt39.Text) } ,
                { Convert.ToInt32(txt41.Text), Convert.ToInt32(txt42.Text), Convert.ToInt32(txt43.Text), Convert.ToInt32(txt44.Text), Convert.ToInt32(txt45.Text), Convert.ToInt32(txt46.Text), Convert.ToInt32(txt47.Text), Convert.ToInt32(txt48.Text), Convert.ToInt32(txt49.Text) } ,
                { Convert.ToInt32(txt51.Text), Convert.ToInt32(txt52.Text), Convert.ToInt32(txt53.Text), Convert.ToInt32(txt54.Text), Convert.ToInt32(txt55.Text), Convert.ToInt32(txt56.Text), Convert.ToInt32(txt57.Text), Convert.ToInt32(txt58.Text), Convert.ToInt32(txt59.Text) } ,
                { Convert.ToInt32(txt61.Text), Convert.ToInt32(txt62.Text), Convert.ToInt32(txt63.Text), Convert.ToInt32(txt64.Text), Convert.ToInt32(txt65.Text), Convert.ToInt32(txt66.Text), Convert.ToInt32(txt67.Text), Convert.ToInt32(txt68.Text), Convert.ToInt32(txt69.Text) } ,
                { Convert.ToInt32(txt71.Text), Convert.ToInt32(txt72.Text), Convert.ToInt32(txt73.Text), Convert.ToInt32(txt74.Text), Convert.ToInt32(txt75.Text), Convert.ToInt32(txt76.Text), Convert.ToInt32(txt77.Text), Convert.ToInt32(txt78.Text), Convert.ToInt32(txt79.Text) } ,
                { Convert.ToInt32(txt81.Text), Convert.ToInt32(txt82.Text), Convert.ToInt32(txt83.Text), Convert.ToInt32(txt84.Text), Convert.ToInt32(txt85.Text), Convert.ToInt32(txt86.Text), Convert.ToInt32(txt87.Text), Convert.ToInt32(txt88.Text), Convert.ToInt32(txt89.Text) } ,
                { Convert.ToInt32(txt91.Text), Convert.ToInt32(txt92.Text), Convert.ToInt32(txt93.Text), Convert.ToInt32(txt94.Text), Convert.ToInt32(txt95.Text), Convert.ToInt32(txt96.Text), Convert.ToInt32(txt97.Text), Convert.ToInt32(txt98.Text), Convert.ToInt32(txt99.Text) } ,
            };
            var x = new SudokuSolver(values);
            if (x.checkForSolution())
            {
                MessageBox.Show("This should be a solution");
            }
            else
            {
                MessageBox.Show("This should not be a solution");
            }
        }
    }
}
