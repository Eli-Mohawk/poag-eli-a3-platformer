/// TO-DO List
/// 
/// enter keybind in title screen
/// 
/// finish level 2
/// add spikes to level 2 and give them collision
/// add win screen
/// add life system
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

        int levelTracker = 1;

        Player player = new Player();

        List<Platform> platforms = new List<Platform>();

        List<Spike> spikeFloor = new List<Spike>();

        GameOver gameOver = new GameOver();

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

            levelTracker = player.gameLevel;
            player.Update(platforms);

            if (levelTracker == 1)
            {
                foreach (Spike spike in spikeFloor)
                {
                    spike.Update();
                }
            }

            foreach (Platform platform in platforms)
            {
                platform.Update();
            }
            platforms.Clear();
            TEMP();

            CHEAT();
        }

        void TEMP()
        {
            if (levelTracker == 1)
            {
                TEMP2();
            }

            if (levelTracker == 2)
            {
                TEMP3();
            }
        }

        void TEMP2()
        {
            platforms.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
            platforms.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
            platforms.Add(new Platform(new Vector2(150, 490), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(230, 420), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(310, 380), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(500, 540), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(550, 465), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(680, 420), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(605, 350), new Vector2(65, 20)));
            platforms.Add(new Platform(new Vector2(545, 300), new Vector2(30, 20)));
            platforms.Add(new Platform(new Vector2(430, 265), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(250, 280), new Vector2(50, 20)));
            platforms.Add(new Platform(new Vector2(100, 220), new Vector2(80, 20)));
            platforms.Add(new Platform(new Vector2(0, 155), new Vector2(50, 20)));
            platforms.Add(new Platform(new Vector2(130, 90), new Vector2(15, 15)));
            platforms.Add(new Platform(new Vector2(225, 80), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(305, 35), new Vector2(100, 20)));
        }

        void TEMP3()
        {
            platforms.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
            platforms.Add(new Platform(new Vector2(0, 155), new Vector2(50, 20)));
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
            int controlStartX = 105; // control tab
            int objectiveStartX = 480; // objective tab
            int[] xPosition = [controlStartX, objectiveStartX];

            // title
            Text.Color = titleScreenColors[1];
            Text.Size = 45;
            Text.Draw("-Ascent-", new Vector2(307, 33));
            Text.Color = titleScreenColors[0];
            Text.Draw("-Ascent-", new Vector2(304, 30));

            // headers
            Text.Color = titleScreenColors[2];
            Text.Size = 35;
            Text.Draw("Controls", new Vector2(xPosition[0], 104));
            Text.Draw("Objective", new Vector2(xPosition[1], 102));

            // info
            Text.Size = 16;
            Text.Draw("- W/Up: Jump", new Vector2(xPosition[0], 155));
            Text.Draw("- A/Left: Move Left", new Vector2(xPosition[0], 175));
            Text.Draw("- D/Right: Move Right", new Vector2(xPosition[0], 195));

            Text.Draw("- Make your way up the", new Vector2(xPosition[1], 155));
            Text.Draw("mountian to reach the long lost", new Vector2(xPosition[1], 175));
            Text.Draw("ice cream cone", new Vector2(xPosition[1], 195));

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
