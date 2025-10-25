/// TO-DO List
///
/// finish level 2
/// add spikes to level 2 and give them collision
/// add win screen !!!
/// add more levels
/// add new objects and give them collision
/// add textures
/// add level select
/// add restart
/// 
/// 
/// add mulitplayer???
/// 
/// 
/// remove debug keybinds (character.cs > S / L) (game.cs > L)
/// 
/// 
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace MohawkGame2D
{
    public class Game
    {
        bool isGameStarted = false;

        public int levelTracker = 1;

        Player player = new Player();

        List<Platform> platforms = new List<Platform>();

        List<Spike> spikeFloor = new List<Spike>();

        GameOver gameOver = new GameOver();

        Level levels = new Level(1);

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("A game about ascending");

            player.position = player.startPosition;

            SpikeFloor();
        }

        public void Update()
        {
            Window.ClearBackground(Color.Gray);

            // title screen
            if (!isGameStarted)
            {
                Window.ClearBackground(Color.Black);
                DrawTitleScreen();
                return;
            }

            // game over screen
            if (player.isPlayerDead)
            {
                gameOver.Update();
                return;
            }

            // if for game win

            levelTracker = player.gameLevel; // tracks the players current level
            player.Update(platforms); // adds collision
            levels.currentLevel = levelTracker; // makes the display level = to the game level
            platforms.Clear(); // remove all platforms
            levels.Update(platforms); // run level code

            // makes floor spikes when on level one
            if (levelTracker == 1)
            {
                foreach (Spike spike in spikeFloor)
                {
                    spike.Update();
                }
            }

            // makes the platforms
            foreach (Platform platform in platforms)
            {
                platform.Update();
            }


            CHEAT();
        }

        void DrawTitleScreen()
        {
            // array for title colors
            Color[] titleScreenColors = new Color[]
            {
                new Color(240, 124, 120), // main title color
                new Color(186, 73, 69), // background title color
                new Color(255, 255, 255) // header color
            };

            // array for x allignment
            int controlStartX = 45; // control tab
            int objectiveStartX = 480; // objective tab
            int[] xPosition = [controlStartX, objectiveStartX];

            // title 
            Text.Color = titleScreenColors[1];
            Text.Size = 45;
            Text.Draw("-Ascent-", new Vector2(305.5f, 33));
            Text.Color = titleScreenColors[0];
            Text.Draw("-Ascent-", new Vector2(302.5f, 30));

            // headers
            Text.Color = titleScreenColors[2];
            Text.Size = 35;
            Text.Draw("Controls", new Vector2(xPosition[0] + 62.5f, 104));
            Text.Draw("Objective", new Vector2(xPosition[1] + 52.5f, 102));

            // info
            Text.Size = 16;
            Text.Draw("- W/Up: Jump", new Vector2(xPosition[0], 155));
            Text.Draw("- A/Left: Move Left", new Vector2(xPosition[0], 175));
            Text.Draw("- D/Right: Move Right", new Vector2(xPosition[0], 195));

            Text.Draw("- Make your way up the", new Vector2(xPosition[1], 155));
            Text.Draw("mountian to reach the long lost", new Vector2(xPosition[1], 175));
            Text.Draw("ice cream cone", new Vector2(xPosition[1], 195));

            Text.Size = 25;
            Text.Draw("Press [Enter] to start game", new Vector2(220, 401));

            // starts the game
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter))
            {
                isGameStarted = true;
            }
        }

        void SpikeFloor()
        {
            Vector2 top = new Vector2(4, 590);
            Vector2 right = new Vector2(8, 600);
            Vector2 left = new Vector2(0, 600);

            for (int spikeCount = 0; spikeCount < 100; spikeCount++)
            {
                int spikeGap = spikeCount * 8;

                Spike newSpike = new Spike(new Vector2(top.X + spikeGap, top.Y), new Vector2(right.X + spikeGap, right.Y), new Vector2(left.X + spikeGap, left.Y));

                spikeFloor.Add(newSpike);
            }
        }

        void CHEAT()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.L) && player.gameLevel == 1)
            {
                isGameStarted = false;
            }
        }
    }
}
