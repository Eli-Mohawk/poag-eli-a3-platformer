using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class GameOver
    {
        // makes the game over screen display for a set amount of time
        float gameOverTimer = 0;
        float gameOverDuration = 2;

        public void Setup()
        {

        }

        public void Update()
        {
            DrawGameOverScreen();

            // closes the game when the timer gets to the duration
            gameOverTimer += Time.DeltaTime;
            if (gameOverTimer >= gameOverDuration)
            {
                Environment.Exit(0);
            }
        }
        void DrawGameOverScreen()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(800, 600));

            Text.Size = 70;
            Text.Color = Color.Red;
            Text.Draw("ERROR!!!", new Vector2(250, 100));
            Text.Draw("FAILURE", new Vector2(130, 200));
        }
    }
}
