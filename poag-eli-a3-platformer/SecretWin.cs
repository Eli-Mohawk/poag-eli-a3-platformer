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
        float secretWinTimer = 0;
        float secretWinDuration = 5;

        public void Setup()
        {

        }

        public void Update()
        {
            DrawSecretWinScreen();

            secretWinTimer += Time.DeltaTime;
            if (secretWinTimer >= secretWinDuration)
            {
                Environment.Exit(0);
            }
        }

        void DrawSecretWinScreen()
        {
            Draw.LineSize = 5;
            Draw.LineColor = Color.Magenta;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(Window.Width, Window.Height));

            Text.Size = 70;
            Text.Color = Color.Magenta;
            Text.Draw("TRUE ENDING", new Vector2(190, 20));
            Text.Size = 50;
            Text.Draw("GOOD JOB!", new Vector2(282.5f, 90));
        }
    }
}
