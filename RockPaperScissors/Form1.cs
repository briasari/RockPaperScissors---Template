using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        public Form1()
        {
            InitializeComponent();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            playerImage.Image = rockImage;
            cpuHand();
            jabPlayer.Play();
            Refresh();

            Thread.Sleep(choicePause);

            DetermineWinner();
            Reset();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.Image = paperImage;
            cpuHand();
            jabPlayer.Play();
            Refresh();

            Thread.Sleep(choicePause);

            DetermineWinner();
            Refresh();

            Reset();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissors";
            playerImage.Image = scissorImage;
            cpuHand();
            jabPlayer.Play();
            Refresh();

            Thread.Sleep(choicePause);

            DetermineWinner();
            Refresh();
            Reset();
        }

        private void cpuHand()
        {
            int randValue = randGen.Next(1, 4);

            switch (randValue)
            {
                case 1:
                    cpuChoice = "rock";
                    cpuImage.Image = rockImage;
                    break;
                case 2:
                    cpuChoice = "paper";
                    cpuImage.Image = paperImage;
                    break;
                case 3:
                    cpuChoice = "scissors";
                    cpuImage.Image = scissorImage;
                    break;
            }
        }
        private void Reset()
        {
            gongPlayer.Play();
            Refresh();
            Thread.Sleep(outcomePause);

            playerImage.Image = null;
            cpuImage.Image = null;
            resultImage.Image = null;
        }
        private void DetermineWinner()
        {
            if (playerChoice == cpuChoice)
            {
                resultImage.Image = tieImage;
                ties++;
                tiesLabel.Text = $"Ties: {ties}";

            }
            else if ((playerChoice == "rock" && cpuChoice == "scissors") || (playerChoice == "paper" && cpuChoice == "rock") || (playerChoice == "scissors" && cpuChoice == "paper"))
            {
                resultImage.Image = winImage;
                wins++;
                winsLabel.Text = $"Wins: {wins}";
            }
            else if ((playerChoice == "scissors" && cpuChoice == "rock") || (playerChoice == "rock" && cpuChoice == "paper") || (playerChoice == "paper" && cpuChoice == "scissors"))
            {
                resultImage.Image = loseImage;
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
            }
        }
    }
}