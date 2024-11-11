using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeMovement
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool lengthCheck(string input)
        {
            return input.Length >= 3 && input.Length <= 20; // if length is between 3 and 20 equaling em btoh
        }

        private bool pressenceCheck(string input)
        {
            return input == "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            if (pressenceCheck(username) == false)
            {
                if (lengthCheck(username))
                {
                    Maze1 Maze = new Maze1();
                    Maze.Show();
                    this.Close();
                    MessageBox.Show("Registration successful!");
                }
                else
                {
                    MessageBox.Show("Registration successful!");
                }
                usernameBox.Clear();


            }
            else
            {
                MessageBox.Show("Registration successful!");
            }

        }

    }
}
