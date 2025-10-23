using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Ending
    {
        bool gameLose = false;
        float gameLoseTimer = 0;
        float gameLoseTimerDuration = 2;

        public void Start()
        {
            gameLoseTimer = 0;
            gameLose = true;
        }

        public void Update()
        {
            if (!gameLose) return;

            gameLoseTimer += Time.DeltaTime;

            GameOverScreen();

            if (gameLoseTimer >= gameLoseTimerDuration)
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
            Text.Draw("TOTAL SYSTEM FAILURE DETECTED", new Vector2(30, 200));
        }

        public bool GameLose()
        {
            return gameLose;
        }
    }
}
