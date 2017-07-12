namespace TurtleGraphics
{
    partial class TurtleGraphics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonShowHideTurtle = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonHexagon = new System.Windows.Forms.Button();
            this.buttonStar = new System.Windows.Forms.Button();
            this.buttonSpiral = new System.Windows.Forms.Button();
            this.buttonSun = new System.Windows.Forms.Button();
            this.buttonTriangles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(12, 41);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonShowHideTurtle
            // 
            this.buttonShowHideTurtle.Location = new System.Drawing.Point(93, 12);
            this.buttonShowHideTurtle.Name = "buttonShowHideTurtle";
            this.buttonShowHideTurtle.Size = new System.Drawing.Size(75, 23);
            this.buttonShowHideTurtle.TabIndex = 1;
            this.buttonShowHideTurtle.Text = "Hide Turtle";
            this.buttonShowHideTurtle.UseVisualStyleBackColor = true;
            this.buttonShowHideTurtle.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonHexagon
            // 
            this.buttonHexagon.Location = new System.Drawing.Point(12, 70);
            this.buttonHexagon.Name = "buttonHexagon";
            this.buttonHexagon.Size = new System.Drawing.Size(75, 23);
            this.buttonHexagon.TabIndex = 3;
            this.buttonHexagon.Text = "Hexagon";
            this.buttonHexagon.UseVisualStyleBackColor = true;
            this.buttonHexagon.Click += new System.EventHandler(this.buttonHexagon_Click);
            // 
            // buttonStar
            // 
            this.buttonStar.Location = new System.Drawing.Point(12, 99);
            this.buttonStar.Name = "buttonStar";
            this.buttonStar.Size = new System.Drawing.Size(75, 23);
            this.buttonStar.TabIndex = 4;
            this.buttonStar.Text = "Star";
            this.buttonStar.UseVisualStyleBackColor = true;
            this.buttonStar.Click += new System.EventHandler(this.buttonStar_Click);
            // 
            // buttonSpiral
            // 
            this.buttonSpiral.Location = new System.Drawing.Point(12, 128);
            this.buttonSpiral.Name = "buttonSpiral";
            this.buttonSpiral.Size = new System.Drawing.Size(75, 23);
            this.buttonSpiral.TabIndex = 5;
            this.buttonSpiral.Text = "Spiral";
            this.buttonSpiral.UseVisualStyleBackColor = true;
            this.buttonSpiral.Click += new System.EventHandler(this.buttonSpiral_Click);
            // 
            // buttonSun
            // 
            this.buttonSun.Location = new System.Drawing.Point(12, 157);
            this.buttonSun.Name = "buttonSun";
            this.buttonSun.Size = new System.Drawing.Size(75, 23);
            this.buttonSun.TabIndex = 6;
            this.buttonSun.Text = "Sun";
            this.buttonSun.UseVisualStyleBackColor = true;
            this.buttonSun.Click += new System.EventHandler(this.buttonSun_Click);
            // 
            // buttonTriangles
            // 
            this.buttonTriangles.Location = new System.Drawing.Point(12, 186);
            this.buttonTriangles.Name = "buttonTriangles";
            this.buttonTriangles.Size = new System.Drawing.Size(75, 23);
            this.buttonTriangles.TabIndex = 7;
            this.buttonTriangles.Text = "3 Triangles";
            this.buttonTriangles.UseVisualStyleBackColor = true;
            this.buttonTriangles.Click += new System.EventHandler(this.buttonTriangles_Click);
            // 
            // TurtleGraphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.buttonTriangles);
            this.Controls.Add(this.buttonSun);
            this.Controls.Add(this.buttonSpiral);
            this.Controls.Add(this.buttonStar);
            this.Controls.Add(this.buttonHexagon);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonShowHideTurtle);
            this.Controls.Add(this.buttonDraw);
            this.Name = "TurtleGraphics";
            this.Text = "Turtle Graphics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TurtleGraphics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonShowHideTurtle;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonHexagon;
        private System.Windows.Forms.Button buttonStar;
        private System.Windows.Forms.Button buttonSpiral;
        private System.Windows.Forms.Button buttonSun;
        private System.Windows.Forms.Button buttonTriangles;
    }
}

