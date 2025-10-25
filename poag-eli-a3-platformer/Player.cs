using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 startPosition = new Vector2(295, 525);
        public Vector2 position;
        public Vector2 size = new Vector2(10, 20);

        public Vector2 velocity = new Vector2(0, 0);
        float gravity = 0.6f;
        public bool isPlayerGrounded = false;

        public int gameLevel = 1;

        public bool isPlayerDead;
        public bool isPlayerAscended;

        public void Setup()
        {

        }

        public void Update(List<Platform> platforms)
        {
            Physics(platforms);
            PlayerInputs();
            DrawPlayer();

            CHEATS();
        }

        void DrawPlayer()
        {
            Draw.LineSize = 3;
            Draw.LineColor = Color.Yellow;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
        }

        void Physics(List<Platform> platforms)
        {
            velocity.Y += gravity;
            position.X += velocity.X;

            #region horizontal collision detection
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
            #endregion

            position.Y += velocity.Y;
            isPlayerGrounded = false;

            #region vertical collision detection
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

            if (position.Y + size.Y >= Window.Height - 10)
            {
                // previous level
                if (gameLevel > 1)
                {
                    gameLevel -= 1;
                    position = startPosition;
                }
                // lose the game
                else
                {
                    isPlayerDead = true;
                }
            }

            // next level
            if (position.Y + size.Y <= 0)
            {
                gameLevel += 1;
                position = startPosition;
            }

            // win the game
            if (gameLevel >= 10)
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

            // jump
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

        void CHEATS()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.S))
            {
                velocity.Y = -10f;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.L))
            {
                if (gameLevel > 1)
                {
                    gameLevel -= 1;
                }
            }
        }
    }
}
