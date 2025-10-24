using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

// lines with comments after them (*code* //) are to show that those variables might change based on play testing

/// TO-DO List
/// 
/// fix TitleScreen code
/// finish level 2
/// add spikes to level 2 and give them collision
/// add all side collision
/// add win screen
/// add life system
/// add more levels
/// add new objects and give them collision
/// add textures
/// 
/// 
/// add mulitplayer???
/// add coyote time???
/// 
/// 
/// remove debug keybinds (character.cs > S / L) (game.cs > L)
/// 
/// 


namespace MohawkGame2D
{
    public class Game
    {
        Player playerMain = new Player(new Vector2(295, 525), new Vector2(10, 20)); // starting location and player size

        List<Platform> platformLevelAll = new List<Platform>();
        List<Spike> spikes = new List<Spike>();

        Spike spikeFloor = new Spike(new Vector2(4, 600 - 10), new Vector2(8, 600), new Vector2(0, 600));

        Death gameOver = new Death();

        // controls the current level
        public static int levelTracker = 1;

        bool isTitleShown = true; 

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("A game about ascending");
        }

        public void Update()
        {
            Window.ClearBackground(Color.Gray);




            // DEBUGGING
            // DEBUGGING
            // DEBUGGING
            if (Input.IsKeyboardKeyPressed(KeyboardInput.L) && playerMain.level == 1)
            {
                isTitleShown = true;
            }






            if (isTitleShown)
            {
                Window.ClearBackground(Color.Black);
                TitleScreen();
                return;
            }


            // if the game is over then it does the game over screen and timer and stops running everything else (players, platforms, collision, etc.)
            if (gameOver.IsGameOver())
            {
                gameOver.Update();
                return;
            }

            levelTracker = playerMain.level;
            playerMain.Update();

            // creates and adds collision to each platform in the platformLevelAll list
            foreach (Platform platform in platformLevelAll)
            {
                platform.Generate();

                playerMain.Collision(platformLevelAll);
            }
           
            playerMain.Generate();

            // starts the Death code
            if (playerMain.isDead)
            {
                gameOver.Start();
            }

            if (playerMain.isWin)
            {

            }

            //clears and draws the level
            platformLevelAll.Clear();
            GameLevels();

            spikeFloor.Generate();
        }

        void GameLevels()
        {
            if (levelTracker == 1)
            {
                LevelOne();
            }

            if (levelTracker == 2)
            {
                LevelTwo();
            }
        }

        void LevelOne()
        {
            platformLevelAll.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
            platformLevelAll.Add(new Platform(new Vector2(150, 490), new Vector2(60, 20)));
            platformLevelAll.Add(new Platform(new Vector2(230, 420), new Vector2(35, 20)));
            platformLevelAll.Add(new Platform(new Vector2(310, 380), new Vector2(35, 20)));
            platformLevelAll.Add(new Platform(new Vector2(500, 540), new Vector2(40, 20)));
            platformLevelAll.Add(new Platform(new Vector2(550, 465), new Vector2(60, 20)));
            platformLevelAll.Add(new Platform(new Vector2(680, 420), new Vector2(40, 20)));
            platformLevelAll.Add(new Platform(new Vector2(605, 350), new Vector2(65, 20)));
            platformLevelAll.Add(new Platform(new Vector2(545, 300), new Vector2(30, 20)));
            platformLevelAll.Add(new Platform(new Vector2(430, 265), new Vector2(10, 10)));
            platformLevelAll.Add(new Platform(new Vector2(250, 280), new Vector2(50, 20)));
            platformLevelAll.Add(new Platform(new Vector2(100, 220), new Vector2(80, 20)));
            platformLevelAll.Add(new Platform(new Vector2(0, 155), new Vector2(50, 20)));
            platformLevelAll.Add(new Platform(new Vector2(130, 90), new Vector2(15, 15)));
            platformLevelAll.Add(new Platform(new Vector2(225, 80), new Vector2(10, 10)));
            platformLevelAll.Add(new Platform(new Vector2(305, 35), new Vector2(100, 20)));
        }

        void LevelTwo()
        {
            platformLevelAll.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
        }

        void TitleScreen()
        {
            // title colors for reusablility purposes
            Color[] textColors = new Color[]
            {
                new Color(240, 124, 120),
                new Color(186, 73, 69)
            };

            Vector2[] text = new Vector2[]
            {
                new Vector2(300, 25),
                new Vector2(200, 50),

                new Vector2(100, 100),
                new Vector2(225, 35),

                new Vector2(100, 145),
                new Vector2(225, 250),

                new Vector2(475, 100),
                new Vector2(275, 35),

                new Vector2(475, 145),
                new Vector2(275, 250),
            };

            Draw.LineSize = 1;
            Draw.LineColor = Color.White;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(text[0], text[1]); // Title
            Draw.Rectangle(text[2], text[3]); // control name
            Draw.Rectangle(text[4], text[5]); // controls
            Draw.Rectangle(text[6], text[7]); // objective name
            Draw.Rectangle(text[8], text[9]); // objectives

            int controls = 105;
            int objectives = 480;

            int[] tT = [controls, objectives];



            


            Text.Color = textColors[1];
            Text.Size = 45;
            Text.Draw("-Ascent-", new Vector2(307, 33));
            Text.Color = textColors[0];
            Text.Draw("-Ascent-", new Vector2(304, 30));


            Text.Color = Color.White;
            Text.Size = 35;
            Text.Draw("Controls", new Vector2(tT[0], 104));
            Text.Draw("Objective", new Vector2(tT[1], 102));

            Text.Size = 16;
            Text.Draw("- W/Up: Jump", new Vector2(tT[0], 155));
            Text.Draw("- A/Left: Move Left", new Vector2(tT[0], 175));
            Text.Draw("- D/Right: Move Right", new Vector2(tT[0], 195));

            Text.Draw("- go up", new Vector2(tT[1], 153));



            // starts the game
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter))
            {
                isTitleShown = false;
            }
        }

        void Pause()
        {
            System.Threading.Thread.Sleep(1000000000);
        }
    }
}
