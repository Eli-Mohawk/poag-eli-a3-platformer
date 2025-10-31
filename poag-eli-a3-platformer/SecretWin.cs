using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class SecretWin
    {
        // makes the game over screen display for a set amount of time
        float secretWinTimer = 0;
        float secretWinDuration = 5;

        public void Setup()
        {

        }

        public void Update()
        {
            DrawSecretWinScreen();

            // closes the game when the timer gets to the duration
            secretWinTimer += Time.DeltaTime;
            if (secretWinTimer >= secretWinDuration)
            {
                Environment.Exit(0);
            }
        }

        void DrawSecretWinScreen()
        {
            Draw.LineSize = 5;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(Window.Width, Window.Height));

            Text.Size = 70;
            Text.Color = Color.Green;
            Text.Draw("TRUE  ENDING", new Vector2(217.5f, 20));
        }
    }

}
