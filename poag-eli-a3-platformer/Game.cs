using System;
using System.Numerics;
using System.Collections.Generic;

namespace MohawkGame2D
{
    public class Game
    {
        Player player = new Player(new Vector2(295, 525), new Vector2(10, 20));
        List<Platform> platformAll = new List<Platform>();
        Ending gameOver = new Ending();

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Ultimate Parkour Master");

            platformAll.Add(new Platform(new Vector2(260, 550), new Vector2(80, 20))); // starting platform
            platformAll.Add(new Platform(new Vector2(150, 490), new Vector2(60, 20))); // 1
            platformAll.Add(new Platform(new Vector2(230, 420), new Vector2(35, 20))); // 2
            platformAll.Add(new Platform(new Vector2(310, 380), new Vector2(35, 20))); // 3
            platformAll.Add(new Platform(new Vector2(490, 540), new Vector2(50, 20))); // 4
        }

        public void Update()
        {
            Window.ClearBackground(Color.Gray);

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
