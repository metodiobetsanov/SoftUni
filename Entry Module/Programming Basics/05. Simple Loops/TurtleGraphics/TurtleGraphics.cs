using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nakov.TurtleGraphics;

namespace TurtleGraphics
{
    public partial class TurtleGraphics : Form
    {
        public TurtleGraphics()
        {
            InitializeComponent();
        }

        private void TurtleGraphics_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assign a delay to visualize the drawing process
            Turtle.Delay = 200;

            // Draw a equilateral triangle
            Turtle.Rotate(30);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);
            Turtle.Rotate(120);
            Turtle.Forward(200);

            // Draw a line in the triangle
            Turtle.Rotate(-30);
            Turtle.PenUp();
            Turtle.Backward(50);
            Turtle.PenDown();
            Turtle.Backward(100);
            Turtle.PenUp();
            Turtle.Forward(150);
            Turtle.PenDown();
            Turtle.Rotate(30);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Turtle.ShowTurtle)
            {
                Turtle.ShowTurtle = false;
                this.buttonShowHideTurtle.Text = "Show Turtle";
            }
            else
            {
                Turtle.ShowTurtle = true;
                this.buttonShowHideTurtle.Text = "Hide Turtle";
            }

        }

        private void buttonHexagon_Click(object sender, EventArgs e)
        {
            // Assign a delay to visualize the drawing process
            Turtle.Delay = 200;

            // Draw a hexagon
            for (int i = 0; i < 6; i++)
            {
                Turtle.Rotate(60);
                Turtle.Forward(200);
            }          
        }

        private void buttonStar_Click(object sender, EventArgs e)
        {
            // Assign a delay to visualize the drawing process
            Turtle.Delay = 200;

            //Change the pen color
            Turtle.PenColor = Color.Green;

            // Draw a star
            for (int i = 0; i < 5; i++)
            {
                Turtle.Rotate(144);
                Turtle.Forward(200);
            }
        }

        private void buttonSpiral_Click(object sender, EventArgs e)
        {
            // Assign a delay to visualize the drawing process
            Turtle.Delay = 200;

            // Draw a spiral
            for (int i = 0; i < 20; i++)
            {
                Turtle.Forward(10 * i);
                Turtle.Rotate(60);
            }
        }

        private void buttonSun_Click(object sender, EventArgs e)
        {
            // Assign a delay to visualize the drawing process
            Turtle.Delay = 200;

            // Draw a sun
            for (int i = 0; i < 18; i++)
            {
                Turtle.Forward(250);
                Turtle.Rotate(170);
                Turtle.Forward(250);
                Turtle.Rotate(170);
            }
        }

        private void buttonTriangles_Click(object sender, EventArgs e)
        {
            // Assign a delay to visualize the drawing process
            Turtle.Delay = 200;

            //Change the pen color
            Turtle.PenColor = Color.Red;

            // Draw 3 triangles
            var len = 10;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    Turtle.Forward(len);
                    Turtle.Rotate(120);
                    len += 10;
                }
                len = 10;
                Turtle.Rotate(120);
            }
        }
    }
}
