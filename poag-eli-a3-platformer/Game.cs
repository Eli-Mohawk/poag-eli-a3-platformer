/// TO-DO List
/// 
/// Title / readme:
/// add info button to title
/// in info screen add return screen that takes you back to title (info code over title then bool)
/// talk about object types (plat, spike, moveplat)
/// talk about detect
/// 
/// game won screen:
/// tell the player that there is a real win (secret level)
/// 
/// levels:
/// add platforms to level 7-10
/// playtest whole game
/// add level 0
/// remove leveltest
/// 
/// general:
/// FINAL CODE CLEAN
/// add info the readme (similar but more stuff than title)
/// remove cheat abilities for main branch (game.cs title screen void / game.cs cheat void / player.cs cheat void / player.cs main bool)

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
        bool isUsingDetect;

        bool isCleared = false;
        bool isDrawn = false;
        
        public int levelTracker = 0;

        Player player = new Player();

        List<Platform> platforms = new List<Platform>();
        List<MovingPlatform> movingPlatforms = new List<MovingPlatform>();
        List<Spike> spikes = new List<Spike>();

        GameOver gameOver = new GameOver();
        GameWon gameWon = new GameWon();
        SecretWin secretWin = new SecretWin();

        Level levels = new Level(1);

        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("A game about ascending");

            player.position = player.startPosition;

            levels.Setup();
        }

        public void Update()
        {
            Window.ClearBackground(Color.Gray);

            #region Menus
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

            // victory screen
            if (player.isPlayerAscended)
            {
                gameWon.Update();
                if (gameWon.isGoingToCry)
                {
                    player.gameLevel = 10;
                    player.isPlayerAscended = false;
                    player.isPlayerDescending = true;
                }
                return;
            }

            if (player.isTrueEnd)
            {
                secretWin.Update();
                return;
            }
            #endregion

            #region Background info
            if (levelTracker != player.gameLevel)
            {
                levelTracker = player.gameLevel;
                platforms.Clear(); // remove all platforms
                movingPlatforms.Clear(); // remove all moving platforms
                spikes.Clear(); // remove all spikes

                levels.currentLevel = levelTracker; // makes the display level = to the game level
                levels.Update(platforms, spikes, movingPlatforms); // run level code
            }

            player.Update(platforms, spikes, movingPlatforms); // adds collision
            DrawLevelTitle();
            #endregion

            #region Draw objects
            // makes the spikes
            foreach (Spike spike in spikes)
            {
                spike.Update();
            }
           
            // makes the platforms
            foreach (Platform platform in platforms)
            {
                platform.Update();
                
            }

            foreach (MovingPlatform movingPlatform in movingPlatforms)
            {
                movingPlatform.Update();
            }
            #endregion

            #region Detect ability
            isUsingDetect = player.isDetect;
            if (isUsingDetect)
            {
                DetectAbility(platforms, movingPlatforms);
            }
            #endregion

            //heartItem.Update();

            CHEAT();
        }

        void DrawLevelTitle()
        {
            Text.Draw(levels.levelNames[levels.currentLevel], levels.levelTitle);
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

            // Cheat
            Text.Color = Color.Green;
            Text.Size = 15;
            Text.Draw("(Cheat Addition)", new Vector2(320, 75));

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
            Text.Draw("mountian. If you fall", new Vector2(xPosition[1], 175));
            Text.Draw("you rerturn to the previous level.", new Vector2(xPosition[1], 195));
            Text.Draw("If you are on level one and fall,", new Vector2(xPosition[1], 215));
            Text.Draw("you lose a life.", new Vector2(xPosition[1], 235));

            Text.Size = 25;
            Text.Draw("Press [Enter] to start game", new Vector2(220, 401));

            // starts the game
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter))
            {
                isGameStarted = true;
            }
        }

        void DrawInfoScreen()
        {

        }

        void DetectAbility(List<Platform> platforms, List<MovingPlatform> movingPlatforms)
        {
            Draw.LineSize = 1;
            Draw.LineColor = Color.Green;

            #region Moving platform edges
            foreach (MovingPlatform movingPlatform in movingPlatforms)
            {

                if (movingPlatform.moveSpeed.Y > 0 && movingPlatform.moveSpeed.X == 0)
                {
                    Draw.Line(movingPlatform.startPos, new Vector2(movingPlatform.startPos.X + movingPlatform.size.X, movingPlatform.startPos.Y));
                    Draw.Line(movingPlatform.endPos, new Vector2(movingPlatform.endPos.X + movingPlatform.size.X, movingPlatform.endPos.Y));
                }
                if (movingPlatform.moveSpeed.X > 0 && movingPlatform.moveSpeed.Y == 0)
                {
                    Draw.Line(movingPlatform.startPos, new Vector2(movingPlatform.startPos.X, movingPlatform.startPos.Y + movingPlatform.size.Y));
                    Draw.Line(movingPlatform.endPos, new Vector2(movingPlatform.endPos.X, movingPlatform.endPos.Y + movingPlatform.size.Y));
                }
                if (movingPlatform.moveSpeed.X > 0 && movingPlatform.moveSpeed.Y > 0)
                {
                    Draw.Line(movingPlatform.startPos, new Vector2(movingPlatform.startPos.X + movingPlatform.size.X, movingPlatform.startPos.Y));
                    Draw.Line(movingPlatform.startPos, new Vector2(movingPlatform.startPos.X, movingPlatform.startPos.Y + movingPlatform.size.Y));

                    Draw.Line(movingPlatform.endPos, new Vector2(movingPlatform.endPos.X - movingPlatform.size.X, movingPlatform.endPos.Y));
                    Draw.Line(movingPlatform.endPos, new Vector2(movingPlatform.endPos.X, movingPlatform.endPos.Y - movingPlatform.size.Y));
                }
            }
            #endregion

            #region level 0 platforms
            if (levelTracker == 0)
            {
                foreach (Platform platform in platforms)
                {
                    if (platform.color == Color.Clear)
                    {
                        Draw.Rectangle(platform.position, platform.size);
                    }
                }
            }
            #endregion
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
