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

        public void Setup()
        {

        }

        public void Update()
        {
            DrawGameWinScreen();

            gameWonTimer += Time.DeltaTime;
            if (gameWonTimer >= gameWonDuration)
            {
                Environment.Exit(0);
            }
        }
        void DrawGameWinScreen()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(Window.Width, Window.Height));

            Text.Size = 70;
            Text.Color = Color.Red;
            Text.Draw("ERROR!!!", new Vector2(250, 100));
            Text.Draw("FAILURE", new Vector2(130, 200));
        }
    }
}
