using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpsgame2
{
    public partial class Form2 : Form
    {
        public int rounds = 3;
        public int timePerRound = 6;
        string[] AIchoice = { "rock", "paper", "scissor", "rock", "scissor", "paper" };
        public int randomNumber;
        string command;
        Random rnd = new Random();
        string playerChoice;
        int playerWins = 0;
        int AIwins = 0;
        public Form2()
        {
            InitializeComponent();
            playerChoice = "none";
        }

        private void Btn_rock_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(timePerRound);
            if (timePerRound < 1)
            {

                timer1.Enabled = false;

                timePerRound = 6;
                randomNumber = rnd.Next(0, 5);
                command = AIchoice[randomNumber];



                switch (command)

                {

                    case "rock":
                        pictureBox2.Image = Properties.Resources.rock;
                        break;

                    case "paper":
                        pictureBox2.Image = Properties.Resources.paper;
                        break;

                    case "scissor":
                        pictureBox2.Image = Properties.Resources.scissors;
                        break;

                    default:
                        break;

                }


                if (rounds > 1)
                {
                    checkGame();
                }
                else
                {
                    decisionEngine();
                }
            }
        }
        private void checkGame()
        {
            if (playerChoice == "rock" && command == "paper")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "paper" && command == "rock")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "paper" && command == "scissor")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "scissor" && command == "paper")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "scissor" && command == "rock")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "rock" && command == "scissor")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "none")
            {
                MessageBox.Show(label1.Text + " Make a choice");
                nextRound();
            }
            else
            {
                MessageBox.Show("Draw");
                nextRound();
            }
        }
        private void decisionEngine()
        {
            if (playerWins > AIwins)
            {
                label9.Text = label1.Text + " Wins the game";
            }
            else
            {
                label9.Text = "AI Wins the game";
            }
        }
        private void nextRound()
        {
            playerChoice = "none";
            pictureBox1.Image = Properties.Resources.quest;
            timer1.Enabled = true;
            pictureBox2.Image = Properties.Resources.quest;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            pictureBox1.Image = Properties.Resources.rock;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            pictureBox1.Image = Properties.Resources.paper;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            pictureBox1.Image = Properties.Resources.scissors;
        }
    }
}