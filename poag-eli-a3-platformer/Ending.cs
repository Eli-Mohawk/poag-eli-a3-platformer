using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Death
    {
        bool gameOver = false;
        float gameOverTimer = 0;
        float gameOverDuration = 2; // length of game over screen

        public void Start()
        {
            gameOverTimer = 0;
            gameOver = true;
        }

        public void Update()
        {
            // stops running the update code here unless gameOver is true
            if (!gameOver)
            {
                return;
            }

            gameOverTimer += Time.DeltaTime;

            GameOverScreen();

            // if the timer gets to the max duration then the program closes
            if (gameOverTimer >= gameOverDuration)
            {
                Environment.Exit(0);
            }
        }

        void GameOverScreen()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(800, 600));

            Text.Size = 70;
            Text.Color = Color.Red;
            Text.Draw("ERROR!!!", new Vector2(250, 100));
            Text.Draw("FAILURE", new Vector2(30, 200));
        }

        public bool IsGameOver()
        {
            return gameOver;
        }
    }

    public class Win
    {
        bool gameWon = false;

        public void Start()
        {

        }

        public void Update()
        {

        }

        void WinScreen()
        {

        }

        public bool IsGameWon()
        {
            return gameWon;
        }
    }
}
