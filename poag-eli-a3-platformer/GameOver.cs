using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class GameOver
    {
        float gameOverTimer = 0;
        float gameOverDuration = 5;

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
            // background
            Draw.LineSize = 5;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(Window.Width, Window.Height));

            // text
            Text.Size = 70;
            Text.Color = Color.Red;
            Text.Draw("Game Over!", new Vector2(217.5f, 20));

            // sub text
            Text.Size = 30;
            Text.Draw("System self destruct", new Vector2(237.5f, 270));
            Text.Draw($"will occur in {Math.Round(gameOverDuration - gameOverTimer)}", new Vector2(237.5f, 300));
        }
    }
}
