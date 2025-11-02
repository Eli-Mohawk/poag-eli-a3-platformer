using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class GameWon
    {
        float gameWonTimer = 0;
        float gameWonDurationJoke = 2;
        float gameWonDurationTip = 3;
        float gameWonDurationFull = 5;

        public bool isGoingToCry = false; // starts fake win cutscene

        public void Update()
        {
            DrawGameWinScreen();

            gameWonTimer += Time.DeltaTime;
        }

        void DrawGameWinScreen()
        {
            // background
            Draw.LineSize = 5;
            Draw.LineColor = Color.Yellow;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(Window.Width, Window.Height));

            // main text
            Text.Size = 70;
            Text.Color = Color.Yellow;
            Text.Draw("CONGRATULATIONS!", new Vector2(105, 20));
            Text.Size = 50;
            Text.Draw("YOU WON!", new Vector2(297.5f, 90));

            // delayed text
            Text.Size = 30;
            Text.Color = Color.Red;
            if (gameWonTimer >= gameWonDurationJoke)
            {
                Text.Draw("Just Kidding!", new Vector2(297.5f, 300));
            }
            if (gameWonTimer >= gameWonDurationTip)
            {
                Text.Draw("This time, finish EVERY level.", new Vector2(162.5f, 340));
            }

            // starts the cutscene
            if (gameWonTimer >= gameWonDurationFull)
            {
                isGoingToCry = true;
            }
        }
    }
}
