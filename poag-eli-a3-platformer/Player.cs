using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        bool isFlyCheat = false; // CHEAT

        public Vector2 startPosition = new Vector2(295, 525);
        public Vector2 position;
        Vector2 size = new Vector2(10, 20);

        public Vector2 velocity = new Vector2(0, 0);
        float gravity;
        bool isPlayerGrounded;

        public int gameLevel = 1;

        public bool isDetect;

        public bool isPlayerDead; // game over
        public bool isPlayerAscended; // fake win
        public bool isPlayerDescending; // fake win cutscene
        public bool isTrueEnd; // true win

        public bool isSecondChance; // has player fake won
        bool isHiddenDone; // has player unlocked real win

        int lives = 5;

        public void Update(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            if (isPlayerDescending)
            {
                CutscenePhysics();
            }
            if (!isPlayerDescending)
            {
                Physics(platforms, spikes, movingPlatforms);
                PlayerInputs();
            }
            DrawPlayer();
            LifeSystem();
        }

        void DrawPlayer()
        {
            // player health
            Text.Size = 17;
            Text.Color = Color.White;
            Text.Draw($"{lives}", new Vector2(position.X, position.Y - 20));

            // player color changes based on health
            Color[] healthColor = new Color[]
            {
                new Color(165, 48, 219),
                new Color(48, 219, 57),
                new Color(255, 255, 0),
                new Color(245, 137, 0),
                new Color(255, 0, 0),
            };

            if (lives >= 5)
            {
                Draw.LineColor = healthColor[0];
            }
            else if (lives == 4)
            {
                Draw.LineColor = healthColor[1];
            }
            else if (lives == 3)
            {
                Draw.LineColor = healthColor[2];
            }
            else if (lives == 2)
            {
                Draw.LineColor = healthColor[3];
            }
            else if (lives == 1)
            {
                Draw.LineColor = healthColor[4];
            }
            
            // player
            Draw.LineSize = 3;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
        }

        void Physics(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            gravity = 0.6f;
            velocity.Y += gravity;
            position.X += velocity.X;

            #region horizontal platform collision detection
            foreach (Platform platform in platforms)
            {
                if (CollisionDetection.CheckCollision(position, size, platform.position, platform.size))
                {
                    if (velocity.X > 0) // moving right
                    {
                        position.X = platform.position.X - size.X;
                    }
                    else if (velocity.X < 0) // moving left
                    {
                        position.X = platform.position.X + platform.size.X;
                    }

                    velocity.X = 0;
                }
            }

            foreach (MovingPlatform movingPlatform in movingPlatforms)
            {
                if (CollisionDetection.CheckCollision(position, size, movingPlatform.position, movingPlatform.size))
                {
                    if (velocity.X > 0) // moving right
                    {
                        position.X = movingPlatform.position.X - size.X;
                    }
                    else if (velocity.X < 0) // moving left
                    {
                        position.X = movingPlatform.position.X + movingPlatform.size.X;
                    }

                    velocity.X = 0;
                }
            }
            #endregion

            position.Y += velocity.Y;
            isPlayerGrounded = false;

            #region vertical platform collision detection
            foreach (Platform platform in platforms)
            {
                if (CollisionDetection.CheckCollision(position, size, platform.position, platform.size))
                {
                    if (velocity.Y > 0) // falling
                    {
                        position.Y = platform.position.Y - size.Y;
                        velocity.Y = 0;
                        isPlayerGrounded = true;
                    }
                    else if (velocity.Y < 0) // jumping
                    {
                        position.Y = platform.position.Y + platform.size.Y;
                        velocity.Y = 0;
                    }
                }
            }

            foreach (MovingPlatform movingPlatform in movingPlatforms)
            {
                if (CollisionDetection.CheckCollision(position, size, movingPlatform.position, movingPlatform.size))
                {
                    if (velocity.Y > 0) // falling
                    {
                        position.Y = movingPlatform.position.Y - size.Y;
                        velocity.Y = 0;
                        isPlayerGrounded = true;

                        position += movingPlatform.distance;
                    }
                    else if (velocity.Y < 0) // jumping
                    {
                        position.Y = movingPlatform.position.Y + movingPlatform.size.Y;
                        velocity.Y = 0;
                    }
                }
            }
            #endregion

            #region spike collision detection
            foreach (Spike spike in spikes)
            {
                RectangleF spikeHitbox = spike.GetHitbox();
                if (CollisionDetection.CheckCollision(position, size, new Vector2(spikeHitbox.X, spikeHitbox.Y), new Vector2(spikeHitbox.Width, spikeHitbox.Height)))
                {
                    if (gameLevel == 0)
                    {
                        isPlayerDead = true;
                    }
                    lives -= 1;
                    position = startPosition;
                    velocity = new Vector2(0, 0);
                }
            }
            #endregion

            #region left/right screen collision
            // left
            if (position.X <= 0)
            {
                if (gameLevel == 7 && position.Y <= 150 && position.Y >= 130) // level 0
                {
                    gameLevel = 0;
                    position = new Vector2(770, 535);
                    velocity.X = 0;
                }
                else // level 1+
                {
                    position.X = 0;
                    velocity.X = 0;
                }
            }
            // right
            if (position.X + size.X > Window.Width)
            {
                position.X = Window.Width - size.X;
                velocity.X = 0;
            }
            #endregion

            #region bottom collision / level undo
            // bottom
            if (position.Y + size.Y >= Window.Height)
            {
                // previous level
                if (gameLevel > 1)
                {
                    gameLevel -= 1;
                    position = startPosition;
                    velocity.Y = 0;
                }

                // lose a life
                else
                {
                    if (gameLevel == 0)
                    {
                        isPlayerDead = true;
                    }
                    else
                    {
                        lives -= 1;
                        position = startPosition;
                        velocity.Y = 0;
                    }
                }
            }
            #endregion

            #region top collision / next level
            // top
            if (position.Y + size.Y <= 0)
            {
                if (gameLevel == 0)
                {
                    gameLevel = 7;
                    position = startPosition;
                    isHiddenDone = true;
                }
                else
                {
                    gameLevel += 1;
                    position = startPosition;
                }
            }

            // fake win
            if (gameLevel > 10 && !isHiddenDone)
            {
                isPlayerAscended = true;

                if (isPlayerAscended && isSecondChance) // fake win 2
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR 672: PLAYER FAILED TO FIND AND COMPLETE LEVEL 0");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(0);
                }
            }

            // win
            if (gameLevel > 10 && isHiddenDone)
            {
                isTrueEnd = true;
            }
            #endregion
        }

        void CutscenePhysics()
        {
            gravity = 0.4f;
            velocity.Y += gravity;
            position += velocity;

            // moves player to top middle of level 10
            if (gameLevel == 10 && position.X != 300)
            {
                velocity.Y = 0;
                position.Y = 0;
                position.X = 300;
            }

            // moves player to the top of each level as they fall
            if (position.Y < 0)
            {
                velocity.Y = 0;
                position.Y = 0;
            }

            // reduces level as the player falss
            if (position.Y >= Window.Height)
            {
                gameLevel -= 1;
                velocity.Y = 0;
                position.Y = 0;
            }

            // re-enables normal physics / disables "cutscene"
            if (gameLevel == 1 && position.Y >= 500)
            {
                lives = 5;
                isPlayerDescending = false;
                isSecondChance = true;
            }
        }

        void PlayerInputs()
        {
            bool isPlayerJumping = Input.IsKeyboardKeyPressed(KeyboardInput.W) || Input.IsKeyboardKeyPressed(KeyboardInput.Up);

            bool isPlayerMovingLeft = Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left);
            bool isPlayerMovingRight = Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right);
            bool isPlayerMoving = false;

            isDetect = Input.IsKeyboardKeyDown(KeyboardInput.Space);

            if (!isDetect) // i tried to make it the same way as movingX but it didnt stop jumps unless i did this
            {
                // jump
                if (isPlayerJumping && isPlayerGrounded)
                {
                    velocity.Y = -10f;
                }

                // move left
                if (isPlayerMovingLeft)
                {
                    isPlayerMoving = true;
                    velocity.X = -4;
                }

                // move right
                if (isPlayerMovingRight)
                {
                    isPlayerMoving = true;
                    velocity.X = 4;
                }

                // stop with both
                if (isPlayerMovingLeft && isPlayerMovingRight)
                {
                    isPlayerMoving = false;
                }

                // stop moving when you let go
                if (!isPlayerMoving)
                {
                    velocity.X = 0;
                }
            }
            // stop inputs when using detect
            else
            {
                velocity.X = 0;
            }
        }

        void LifeSystem()
        {
            if (lives <= 0)
            {
                isPlayerDead = true;
            }
        }
    }
}
