using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_Square
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            try // if anything else but a odd number is run it will catch it
            {
                int gridSize = int.Parse(textBox1.Text);
                int[,] gridNumbers = new int[gridSize, gridSize];

                int currentX = 0, currentY = (gridSize - 1) / 2; 
                int previousX = 0, previousY = 0;
      
                //entering first value and increasing co-ordinates
                int currentNumber = 1;
                gridNumbers[currentX, currentY] = currentNumber;

                for (currentNumber = 2; currentNumber <= gridSize * gridSize; currentNumber++) // will test and enter the next value until it reaches nxn
                {
                    //increases and saving old co-ordinate for next value
                    previousX = currentX;
                    previousY = currentY;
                    currentX--;
                    currentY++;
                    //Checking for out of Bounds
                    if (currentX == -1)
                    {
                        currentX += gridSize;
                    }
                    if (currentY == gridSize)
                    {
                        currentY -= gridSize;
                    }
                    //entering next value test               
                    if (gridNumbers[currentX, currentY] == 0)  //if availible it will place it diagonal up
                    {
                        gridNumbers[currentX, currentY] = currentNumber;
                    }
                    else //else it will place it underneath
                    {
                        currentX = previousX + 1;
                        currentY = previousY;
                        gridNumbers[currentX, currentY] = currentNumber;
                    }
                }

                //write to textbox2
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        textBox2.Text += gridNumbers[x, y].ToString() + "\t" ;
                    }
                    textBox2.Text += System.Environment.NewLine;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Entered Number was not a odd Number, try again.");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Entered Number was not a odd Number, try again.");
            }
        }
    }
}
