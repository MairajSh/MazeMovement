
namespace MazeMovement
{
    partial class Maze1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maze1));
            this.PlayerMover = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PlayerMover
            // 
            this.PlayerMover.Enabled = true;
            this.PlayerMover.Interval = 5;
            this.PlayerMover.Tick += new System.EventHandler(this.MovePlayerEvent);
            // 
            // Maze1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(568, 466);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Maze1";
            this.Text = "Maze1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.mapLoader);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyisDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyisUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer PlayerMover;
    }
}