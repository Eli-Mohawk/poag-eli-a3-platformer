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
        public Vector2 size = new Vector2(10, 20);

        public Vector2 velocity = new Vector2(0, 0);
        float gravity = 0.6f;
        public bool isPlayerGrounded = false;

        public int gameLevel = 1;

        public bool isPlayerDead;
        public bool isPlayerAscended;

        int lives = 3;

        public void Setup()
        {

        }

        public void Update(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            Physics(platforms, spikes, movingPlatforms);
            PlayerInputs();
            DrawPlayer();
            LifeSystem();

            CHEATS();
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
                 new Color(255, 255, 0),
                 new Color(245, 137, 0),
                 new Color(255, 0, 0),
            };
            if (lives >= 3)
            {
                Draw.LineColor = healthColor[0];
            }
            else if (lives == 2)
            {
                Draw.LineColor = healthColor[1];
            }
            else if (lives == 1)
            {
                Draw.LineColor= healthColor[2];
            }
            // player
            Draw.LineSize = 3;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
        }

        void Physics(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
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
                if (CollisionDetection.CheckCollision(position, size, movingPlatform.startPosition, movingPlatform.size))
                {
                    if (velocity.X > 0) // moving right
                    {
                        position.X = movingPlatform.startPosition.X - size.X;
                    }
                    else if (velocity.X < 0) // moving left
                    {
                        position.X = movingPlatform.startPosition.X + movingPlatform.size.X;
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
                if (CollisionDetection.CheckCollision(position, size, movingPlatform.startPosition, movingPlatform.size))
                {
                    if (velocity.Y > 0) // falling
                    {
                        position.Y = movingPlatform.startPosition.Y - size.Y;
                        velocity.Y = 0;
                        isPlayerGrounded = true;
                    }
                    else if (velocity.Y < 0) // jumping
                    {
                        position.Y = movingPlatform.startPosition.Y + movingPlatform.size.Y;
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
                    lives -= 1;
                    position = startPosition;
                    velocity = new Vector2(0, 0);
                    break;
                }
            }
            #endregion

            #region Edge collision & level changing
            if (position.X < 0)
            {
                position.X = 0;
                velocity.X = 0;
            }
            else if (position.X + size.X > Window.Width)
            {
                position.X = Window.Width - size.X;
                velocity.X = 0;
            }

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
                    lives -= 1;
                    position = startPosition;
                    velocity.Y = 0;
                }
            }

            // next level
            if (position.Y + size.Y <= 0)
            {
                gameLevel += 1;
                position = startPosition;
            }

            // win the game
            if (gameLevel > 10)
            {
                isPlayerAscended = true;
            }
            #endregion
        }

        void PlayerInputs()
        {
            bool isPlayerJumping = Input.IsKeyboardKeyPressed(KeyboardInput.W) || Input.IsKeyboardKeyPressed(KeyboardInput.Up);

            bool isPlayerMovingLeft = Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left);
            bool isPlayerStopLeft = Input.IsKeyboardKeyReleased(KeyboardInput.A) || Input.IsKeyboardKeyReleased(KeyboardInput.Left);

            bool isPlayerMovingRight = Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right);
            bool isPlayerStopRight = Input.IsKeyboardKeyReleased(KeyboardInput.D) || Input.IsKeyboardKeyReleased(KeyboardInput.Right);

            // jump / cancel
            if (isPlayerJumping && isPlayerGrounded)
            {
                velocity.Y = -10f;
            }

            // move left
            if (isPlayerMovingLeft)
            {
                velocity.X = -4;
            }
            else if (isPlayerStopLeft)
            {
                velocity.X = 0;
            }

            // move right
            if (isPlayerMovingRight)
            {
                velocity.X = 4;
            }
            else if (isPlayerStopRight)
            {
                velocity.X = 0;
            }

            // stop with both
            if (isPlayerMovingLeft && isPlayerMovingRight)
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

        void CHEATS()
        {
            #region Flight
            if (Input.IsKeyboardKeyPressed(KeyboardInput.H))
            {
                isFlyCheat = true;
            }
            if (isFlyCheat && Input.IsKeyboardKeyPressed(KeyboardInput.J))
            {
                isFlyCheat = false;
                gravity = 0.6f;
            }
            if (isFlyCheat)
            {
                gravity = 0;
                if (Input.IsKeyboardKeyDown(KeyboardInput.S))
                {
                    velocity.Y = 10;
                }
                else if (Input.IsKeyboardKeyReleased(KeyboardInput.S))
                {
                    velocity.Y = 0;
                }

                if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
                {
                    velocity.Y = -10;
                }
                else if (Input.IsKeyboardKeyReleased(KeyboardInput.Space))
                {
                    velocity.Y = 0;
                }

                if (Input.IsKeyboardKeyDown(KeyboardInput.A))
                {
                    velocity.X = -10;
                }
                else if (Input.IsKeyboardKeyReleased(KeyboardInput.A))
                {
                    velocity.X = 0;
                }

                if (Input.IsKeyboardKeyDown(KeyboardInput.D))
                {
                    velocity.X = 10;
                }
                else if (Input.IsKeyboardKeyReleased(KeyboardInput.D))
                {
                    velocity.X = 0;
                }
            }
            #endregion

            if (Input.IsKeyboardKeyPressed(KeyboardInput.S) && !isFlyCheat)
            {
                velocity.Y = -10;
            }

            if (Input.IsKeyboardKeyPressed(KeyboardInput.L))
            {
                if (gameLevel > 1)
                {
                    gameLevel -= 1;
                }
            }

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Y))
            {
                lives += 10;
            }
        }
    }
}
