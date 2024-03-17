using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman
{
    public partial class Form1 : Form
    {
        bool goup, godown, goleft, goright, isGameOver;

        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;


        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pacman_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void yellowGhost_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            txtScore.Text ="Điểm: " + score;

            if(goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;
            }
            if(goright == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;
            }
            if (goup == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }
            if(godown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;
            }

            if(pacman.Left < -10)
            {
                pacman.Left = 680;
            }
            if (pacman.Left > 680)
            {
                pacman.Left = -10;
            }
            if(pacman.Top < -10)
            {
                pacman.Top = 550;
            }
            if(pacman.Top > 550)
            {
                pacman.Top = 0;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {


                    if ((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }
                    if ((string)x.Tag == "wall")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Thất bại!");
                        }
                        if (pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }
                    }
                    if ((string)x.Tag == "ghost")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Thất bại! ");
                        }
                    }

                }
            }
            // ma di chuyen
            redGhost.Left += redGhostSpeed;

            if (redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowGhost.Left -= yellowGhostSpeed;

            if (yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }


            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;
            if(pinkGhost.Top < 0|| pinkGhost.Top > 520)
            {
                pinkGhostY = -pinkGhostY;
            }
            if(pinkGhost.Left < 0 || pinkGhost.Left > 620)
            {
                pinkGhostX = -pinkGhostX;
            }









            if ( score == 49)
            {
                gameOver("Bạn thắng");
            }

        }


       



        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }

        }


        private void resetGame()
        {
            txtScore.Text ="Điểm: 0";
            score = 0;

            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 8;

            isGameOver = false;

            pacman.Left = 31;
            pacman.Top = 46;

            redGhost.Left = 245;
            redGhost.Top = 78;

            yellowGhost.Left = 431;
            yellowGhost.Top = 441;

            pinkGhost.Left = 552;
            pinkGhost.Top = 256;

            foreach(Control  x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gameTimer.Start();

        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text ="Điểm: " + score + Environment.NewLine + message;
        }
    }
}
