using System;
using System.Numerics;
using System.Collections.Generic;

namespace MohawkGame2D
{
    public class Game
    {
        Player player = new Player(new Vector2(395, 100), new Vector2(10, 20));
        List<Platform> platformAll = new List<Platform>();
        Ending gameOver = new Ending();

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("");

            platformAll.Add(new Platform(new Vector2(340, 350), new Vector2(100, 30)));
            platformAll.Add(new Platform(new Vector2(100, 480), new Vector2(100, 30)));
            platformAll.Add(new Platform(new Vector2(300, 380), new Vector2(100, 30)));
        }

        public void Update()
        {
            Window.ClearBackground(Color.Black);

            if (gameOver.GameLose())
            {
                gameOver.Update();
                return;
            }

            player.Update();


            foreach (Platform platform in platformAll)
            {
                platform.Generate();

                player.Collision(platformAll);
            }

            player.Generate();

            if (player.fail)
            {
                gameOver.Start();
            }
        }
    }
}
