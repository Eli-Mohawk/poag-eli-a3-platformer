using System;
using System.Numerics;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

// lines with comments after them (*code* //) are to show that those variables might change based on play testing

/// TO-DO List
/// add textures
/// finish platforms
/// add new obstacles
/// add more levels
/// add win screen
/// add lives???
/// add sound???
/// add mulitplayer???
/// add timer so player has to go fast???
/// coyote time

namespace MohawkGame2D
{
    public class Game
    {
        Player playerMain = new Player(new Vector2(295, 525), new Vector2(10, 20)); // starting location and player size

        List<Platform> platformLevelAll = new List<Platform>();

   



        List<Spike> spikeLevel2 = new List<Spike>();

        Spike spikeFloor = new Spike(new Vector2(4, 600 - 10), new Vector2(8, 600), new Vector2(0, 600));
        Death gameOver = new Death();


        public static int levelTracker = 1;

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("");
            

        }

        public void Update()
        {
            Window.ClearBackground(Color.Gray);


            levelTracker = playerMain.level;

            // if the game is over then it does the game over screen and timer and stops running everything else (players, platforms, collision, etc.)
            if (gameOver.IsGameOver())
            {
                gameOver.Update();
                return;
            }

            playerMain.Update();

            // creates and adds collision to each platform in the platformLevelAll list\

            foreach (Platform platform in platformLevelAll)
            {
                platform.Generate();

                playerMain.Collision(platformLevelAll);
            }


            playerMain.Generate();

            spikeFloor.Generate();

            // starts the Death code
            if (playerMain.isDead)
            {
                gameOver.Start();
            }

            if (playerMain.isWin)
            {

            }

            //clears level so it goes up
            platformLevelAll.Clear();

            LevelHandling();
        }
        //is level up
        public void LevelHandling()
        {
            if (levelTracker == 1)
            {
                #region Level 1
                platformLevelAll.Add(new Platform(new Vector2(260, 550), new Vector2(80, 20))); // starting platform
                platformLevelAll.Add(new Platform(new Vector2(150, 490), new Vector2(60, 20))); // 1
                platformLevelAll.Add(new Platform(new Vector2(230, 420), new Vector2(35, 20))); // 2
                platformLevelAll.Add(new Platform(new Vector2(310, 380), new Vector2(35, 20))); // 3
                platformLevelAll.Add(new Platform(new Vector2(490, 540), new Vector2(50, 20))); // 4
                platformLevelAll.Add(new Platform(new Vector2(550, 465), new Vector2(60, 20))); // 5
                platformLevelAll.Add(new Platform(new Vector2(680, 420), new Vector2(40, 20))); // 6
                platformLevelAll.Add(new Platform(new Vector2(605, 350), new Vector2(65, 20))); // 7
                platformLevelAll.Add(new Platform(new Vector2(545, 300), new Vector2(30, 20))); // 8
                platformLevelAll.Add(new Platform(new Vector2(420, 265), new Vector2(10, 10))); // 9
                platformLevelAll.Add(new Platform(new Vector2(250, 280), new Vector2(50, 20))); // 10
                platformLevelAll.Add(new Platform(new Vector2(100, 220), new Vector2(80, 20))); // 11
                platformLevelAll.Add(new Platform(new Vector2(0, 155), new Vector2(50, 20))); // 12
                platformLevelAll.Add(new Platform(new Vector2(130, 90), new Vector2(15, 15))); // 14
                platformLevelAll.Add(new Platform(new Vector2(225, 80), new Vector2(10, 10))); // 15
                platformLevelAll.Add(new Platform(new Vector2(305, 35), new Vector2(100, 20))); // 16
                #endregion
                
                    
            }

            else if (levelTracker == 2)
            {

                platformLevelAll.Add(new Platform(new Vector2(100, 100), new Vector2(100, 100))); // 11

                foreach (Platform platform in platformLevelAll)
                {
                    platform.Generate();

                    playerMain.Collision(platformLevelAll);
                }
            }

            
        }
    }
}
