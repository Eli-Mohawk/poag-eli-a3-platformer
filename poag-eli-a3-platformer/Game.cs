using System;
using System.Numerics;
using System.Collections.Generic;

// lines with comments after them (*code* //) are to show that those variables might change based on play testing

/// TO-DO List
/// add textures
/// finish platforms
/// add spikes
/// add new obstacles
/// add more levels
/// add win screen
/// add lives???
/// add sound???
/// add mulitplayer???
/// add timer so player has to go fast???

namespace MohawkGame2D
{
    public class Game
    {
        Player playerMain = new Player(new Vector2(295, 525), new Vector2(10, 20)); // starting location and player size
        List<Platform> platformAll = new List<Platform>();
        Death gameOver = new Death();

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

            // if the game is over then it does the game over screen and timer and stops running everything else (players, platforms, collision, etc.)
            if (gameOver.IsGameOver())
            {
                gameOver.Update();
                return;
            }

            playerMain.Update();

            // creates and adds collision to each platform in the platformAll list
            foreach (Platform platform in platformAll)
            {
                platform.Generate();

                playerMain.Collision(platformAll);
            }

            playerMain.Generate();

            // starts the Death code
            if (playerMain.isDead)
            {
                gameOver.Start();
            }
        }
    }
}
