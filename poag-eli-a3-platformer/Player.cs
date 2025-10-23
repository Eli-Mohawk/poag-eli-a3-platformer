using MohawkGame2D;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        Vector2 position;
        Vector2 size;
        Vector2 velocity = new Vector2(0, 0);
        float gravity = 0.6f;
        bool isGrounded = false;
        float friction = 0.7f;
        public bool fail = false;

        public Player(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }

        public void Update()
        {
            Physics();
            InputMovement();
        }

        public void Generate()
        {
            Draw.LineSize = 3;
            Draw.LineColor = Color.Green;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
        }

        void Physics()
        {
            if (isGrounded == false)
            {
                velocity.Y += gravity;
            }
            position += velocity;
        }

        void InputMovement()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) && isGrounded == true || Input.IsKeyboardKeyPressed(KeyboardInput.W) && isGrounded == true || Input.IsKeyboardKeyPressed(KeyboardInput.Up) && isGrounded == true)
            {
                velocity.Y = -10f;
                isGrounded = false;
            }

            // for the time that the key is down, you will move in that direction by setting your horizontal velocity to positive or negative
            // also sets your horizontal velocity to 0 when you stop pressing it
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                velocity.X = -4;
            }
            else if (Input.IsKeyboardKeyReleased(KeyboardInput.A) || Input.IsKeyboardKeyReleased(KeyboardInput.Left))
            {
                velocity.X = 0;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right))
            {
                velocity.X = 4;
            }
            else if (Input.IsKeyboardKeyReleased(KeyboardInput.D) || Input.IsKeyboardKeyReleased(KeyboardInput.Right))
            {
                velocity.X = 0;
            }
        }

        public void Collision(List<Platform> platformAll)
        {
            isGrounded = false;

            float playerTop = position.Y;
            float playerBottom = position.Y + size.Y;
            float playerLeft = position.X;
            float playerRight = position.X + size.X;

            

            foreach (Platform platformCollision in platformAll)
            {
                float platformTop = platformCollision.position.Y;
                float platformBottom = platformCollision.position.Y + platformCollision.size.Y;
                float platformLeft = platformCollision.position.X;
                float platformRight = platformCollision.position.X + platformCollision.size.X;

                // top collision
                bool isFalling = playerBottom <= platformTop && playerBottom + velocity.Y >= platformTop;
                bool isOverlappingX = playerRight > platformLeft && playerLeft < platformRight;

                if (isFalling && isOverlappingX && velocity.Y >= 0)
                {
                    position.Y = platformTop - size.Y;
                    velocity.Y = 0;
                    isGrounded = true;
                    break;
                }

                // bottom collision
                /*bool isRising = playerTop >= platformBottom;// && playerTop + velocity.Y <= platformBottom;
                bool isOverLappingX_Bottom = playerRight > platformLeft && playerLeft < platformRight;

                if (isRising) // && isOverLappingX_Bottom && velocity.Y >= 0)
                {
                    position.Y = platformBottom;
                    velocity.Y = 0;
                    break;
                }*/
            }

            // stops the player from going off the screen
            if (playerTop < 0)
            {
                position.Y = 0;
                velocity.Y = 0;
            }
            // ends the game if you fall to the bottom
            else if (playerBottom > Window.Height - 5)
            {
                fail = true;
            }
            else if (playerRight > Window.Width)
            {
                position.X = Window.Width - size.X;
                velocity.X = 0;
            }
            else if (playerLeft < 0)
            {
                position.X = 0;
                velocity.X = 0;
            }
        }
    }
}
