using System.Drawing;
using System;
using System.Collections.Generic;
using MazeMovement;

class Enemy
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int SizeHeight { get; set; } = 20;
    public int SizeWidth { get; set; } = 20;
    public Image EnemyImage { get; set; }
    public List<Node> NodeList { get; set; }
    public Point TargetNode; // The target location (player's position)

    // Constructor for Enemy, taking position and image
    public Enemy(int newPositionX, int newPositionY, Image newEnemyImage, List<Node> nodeList)
    {
        PositionX = newPositionX;
        PositionY = newPositionY;
        EnemyImage = newEnemyImage;
        NodeList = nodeList;
    }

    // Method to update the target position toward the player
    public void AssignTargetToPlayer(Point playerPosition)
    {
        TargetNode = playerPosition;
    }

    // Method to move the enemy toward the current target node (player)
    public void MoveTowardsPlayer()
    {
        if (TargetNode != null)
        {
            // Move horizontally towards the target node
            if (PositionX < TargetNode.X) PositionX++;
            else if (PositionX > TargetNode.X) PositionX--;

            // Move vertically towards the target node
            if (PositionY < TargetNode.Y) PositionY++;
            else if (PositionY > TargetNode.Y) PositionY--;

            Console.WriteLine($"Enemy moving to X: {PositionX}, Y: {PositionY}");
        }
    }
}
