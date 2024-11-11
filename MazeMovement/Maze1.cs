using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;  

namespace MazeMovement
{
    // Partial class for the Maze1 form, inheriting from Form
    public partial class Maze1 : Form
    {
        // below are the instances of individual objects and list of objects.
        Player Player = new Player();
        block block = new block();
        List<block> blocks = new List<block>();
        List<Enemy> enemies = new List<Enemy>();
        List<Node> Nodes = new List<Node>();


        //List to say which types of objects are collsion  blocks
        List<string> CollsionItemList = new List<string> { "Wall"};

        // Directory path for the current working directory
        string path = Directory.GetCurrentDirectory();

        // File name for the maze data
        string filename = @"\data.txt";

        //Indicate which movement keys are pressed
        bool moveUp, moveDown, moveRight, moveLeft;

        // Speed of the player movement
        int speed = 3;

        // Image to store the map
        Image mapImage;

        // EndZone
        Rectangle endZone;

        // Stopwatch to track the time taken
        Stopwatch timer = new Stopwatch();

        // Constructor for the Maze1 form
        public Maze1()
        {
            InitializeComponent(); // Initialize form components
            Loader(); // Load the map
            Player.PlayerImage = Image.FromFile(@"chrcter.png"); // Load player image
            timer.Start();  // Start tracking time
        }

        // Method to set up the end zone based on map coordinates
        private void EndZone(int x, int y)
        {
            int ZoneSize = 32;
            endZone = new Rectangle(x * ZoneSize, y * ZoneSize, ZoneSize, ZoneSize);
        }

        // Method to load the maze from a text file and create blocks
        private void Loader()
        {

            // Add each node as a new Node object with the current position
            Nodes.Add(new Node(block.PositionX, block.PositionY));

            // Create a new bitmap with the dimensions of the form
            mapImage = new Bitmap(this.Width, this.Height);

            // Full path to the data file
            var file = path + filename;

            // Read all lines from the file
            var lines = File.ReadAllLines(file);

            // Clear existing blocks
            blocks.Clear();

            // Reset enemy list
            enemies.Clear();

            // Reset all nodes
            Nodes.Clear();

            // Use Graphics to draw the map on the bitmap
            using (Graphics graphics = Graphics.FromImage(mapImage))
            {
                // Initialize block's starting Y position
                block.PositionY = 0;

                // Variable for random number generation
                Random random = new Random();

                // Iterate through each line in the file
                foreach (var line in lines)
                {
                    // Split line into block types
                    string[] blocktypes = line.Split(',');

                    // Initialize block's starting X position
                    block.PositionX = 0;

                    // Iterate through each block type in the line
                    foreach (var blocktype in blocktypes)
                    {
                        // Create a new block instance
                        block newblock = new block();

                        // Determine the block type and load image onto the enemy
                        switch (blocktype)
                        {
                            case "#":
                                newblock.BlockImage = Image.FromFile(@"Brick.png");
                                newblock.type = "Wall";
                                break;

                            case " ":
                                newblock.BlockImage = null;
                                newblock.type = "Null";
                                break;

                            case "E":
                                newblock.BlockImage = Image.FromFile(@"Endzone.png");
                                newblock.type = "End";
                            
                                EndZone(block.PositionX / block.SizeWidth, block.PositionY / block.SizeHeight);
                                break;

                            case "N":
                                if (true)
                                {

                                    Enemy newEnemy = new Enemy(block.PositionX, block.PositionY, Image.FromFile(@"enemy.png"), Nodes)
                                    { 
                                        SizeWidth = block.SizeWidth,
                                        SizeHeight = block.SizeHeight
                                    };
                                    enemies.Add(newEnemy);
                                }
                                break;

                            case "f":
                                newblock.type = "Node";
                                Nodes.Add(new Node(block.PositionX, block.PositionY));
                                break;
                        }

                        // Set the position and size for the new block
                        newblock.PositionX = block.PositionX;
                        newblock.PositionY = block.PositionY;
                        newblock.SizeWidth = block.SizeWidth;
                        newblock.SizeHeight = block.SizeHeight;

                        // Add the new block to the blocks list
                        blocks.Add(newblock);

                        // If the block has an image, draw it on the map
                        if (newblock.BlockImage != null)
                        {
                            graphics.DrawImage(newblock.BlockImage, newblock.PositionX, newblock.PositionY, newblock.SizeWidth, newblock.SizeHeight);
                            // Dispose image after drawing
                            newblock.BlockImage.Dispose();
                        }

                        // Move to the next block position
                        block.PositionX += block.SizeWidth;
                    }

                    // Move to the next line position
                    block.PositionY += block.SizeHeight;
                }
            }
        }

        // Method to check for collisions between the player and blocks
        private bool Collision()
        {
            //for loop to iterate through list
            //Checks if the block with which the player collides is in the list 
            // then compares X and Y values if collsion is detected then returns true else false
            
            foreach (var block in blocks)
            {
                
                if (CollsionItemList.Contains(block.type))
                {
                    
                    if (Player.PositionX < block.PositionX + block.SizeWidth &&
                        Player.PositionX + Player.SizeWidth > block.PositionX &&
                        Player.PositionY < block.PositionY + block.SizeHeight &&
                        Player.PositionY + Player.SizeHeight > block.PositionY)
                    {
                        return true; 
                    }
                }
            }
            return false; 
        }

        // Event handler for painting the map and player on the form
        private void mapLoader(object sender, PaintEventArgs e)
        {
            // Get the graphics object from the event arguments
            Graphics g = e.Graphics;

            // Draw the map image if it exists
            if (mapImage != null)
            {
                g.DrawImage(mapImage, 0, 0, this.Width, this.Height);
            }

            // Draw the player image at the player's position
            g.DrawImage(Player.PlayerImage, Player.PositionX, Player.PositionY, Player.SizeWidth, Player.SizeHeight);

            // Draw all enemies from the enemies list
            foreach (var enemy in enemies)
            {
                if (enemy.EnemyImage != null) // Ensure the enemy has an image
                {
                    g.DrawImage(enemy.EnemyImage, enemy.PositionX, enemy.PositionY, enemy.SizeWidth, enemy.SizeHeight);
                }
            }
        }

        // Event handler for moving the player
        private void MovePlayerEvent(object sender, EventArgs e)

        {
            

            // Store the player's current position in case of collision
            int previousPlayerX = Player.PositionX;
            int previousPlayerY = Player.PositionY;

            // Move player left if 'moveLeft' is true and the player is not at the left edge
            if (moveLeft == true && Player.PositionX > 0)
            {
                Player.PositionX -= speed;
            }

            // Move player right if 'moveRight' is true and the player is not at the right edge
            if (moveRight == true && Player.PositionX < 1216)
            {
                Player.PositionX += speed;
            }

            // Move player up if 'moveUp' is true and the player is not at the top edge
            if (moveUp == true && Player.PositionY > 0)
            {
                Player.PositionY -= speed;
            }

            // Move player down if 'moveDown' is true and the player is not at the bottom edge
            if (moveDown == true && Player.PositionY < 640)
            {
                Player.PositionY += speed;
            }

            // Check for collision after moving the player
            if (Collision())
            {
                // If collision detected, revert player to previous position
                Player.PositionX = previousPlayerX;
                Player.PositionY = previousPlayerY;
            }

            // when the player touches the rectangle then End(); method is called which then identifies that the level is comeplte
            if (new Rectangle(Player.PositionX, Player.PositionY, Player.SizeWidth, Player.SizeHeight).IntersectsWith(endZone))
            {
                End(); 
            }

            EnemyMovesBetweenNodes();
            // Repaints form which then shows players updates postions
            this.Invalidate();
        }
        //method that stops the stopwatch timer and displaysmessage that level is complelete then exits the form
        private void End()
        {     
            timer.Stop();
            PlayerMover.Stop();
            MessageBox.Show($"Congratualtions you finsihed the level in {timer.Elapsed.TotalSeconds:F2} seconds!", "Level 1 Complete!");
            
            Application.Exit(); 
        }
        // method for each enemy to be given a random node seprately
        private void EnemyMovesBetweenNodes()
        {
            foreach (var enemy in enemies)
            {
                // Assign the current player position as the enemy's target
                enemy.AssignTargetToPlayer(new Point(Player.PositionX, Player.PositionY));

                // Move the enemy toward the player
                enemy.MoveTowardsPlayer();
            }
        }


        // Event for key down events
        private void KeyisDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
        }

        // Event for key up events
        private void KeyisUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
        }
    }
}
