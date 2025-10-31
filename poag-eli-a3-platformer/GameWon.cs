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
        float gameWonDuration = 2;
        float gameWonDurationFull = 4;

        public bool isGoingToCry = false;

        public void Setup()
        {

        }

        public void Update()
        {
            DrawGameWinScreen();

            gameWonTimer += Time.DeltaTime;
            DrawGameWinScreenTimed();
        }

        void DrawGameWinScreen()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(Window.Width, Window.Height));

            Text.Size = 50;
            Text.Color = Color.Yellow;
            Text.Draw("CONGRATULATIONS!", new Vector2(250, 100));
            Text.Draw("YOU WON!", new Vector2(130, 200));
        }

        void DrawGameWinScreenTimed()
        {
            if (gameWonTimer >= gameWonDuration)
            {
                Text.Draw("TEST", new Vector2(350, 300));
            }
            if (gameWonTimer >= gameWonDurationFull)
            {
                isGoingToCry = true;
            }
        }
    }
}
