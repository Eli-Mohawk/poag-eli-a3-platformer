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
        public Vector2 position;
        Vector2 size;

        Vector2 velocity = new Vector2(0, 0);
        float gravity = 0.6f; // how fast you fall

        bool isGrounded = false;

        public bool isDead = false;
        public bool isWin = false;

        public int level = 1;

        // lets you change the size outside of this area and makes the pos and size in here the same as it
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
            Draw.LineColor = Color.Yellow;
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

            // makes you stand still if you hold any combo of both left and right directions
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) && Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Left) && Input.IsKeyboardKeyDown(KeyboardInput.Right) || Input.IsKeyboardKeyDown(KeyboardInput.A) && Input.IsKeyboardKeyDown(KeyboardInput.Right) || Input.IsKeyboardKeyDown(KeyboardInput.Left) && Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                velocity.X = 0;
            }






            // TEMP DEBUG INPUTS
            // TEMP DEBUG INPUTS
            // TEMP DEBUG INPUTS


            if (Input.IsKeyboardKeyPressed(KeyboardInput.S))
            {
                velocity.Y = -10f;
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.L))
            {
                if (level > 1)
                {
                    level -= 1;
                }
            }







        }

        // applies collision to every platform in the platformAll list
        public void Collision(List<Platform> platformLevelAll)
        {
            isGrounded = false;

            float playerTop = position.Y;
            float playerBottom = position.Y + size.Y;
            float playerLeft = position.X;
            float playerRight = position.X + size.X;

            foreach (Platform platformCollision in platformLevelAll)
            {
                float platformTop = platformCollision.position.Y;
                float platformBottom = platformCollision.position.Y + platformCollision.size.Y;
                float platformLeft = platformCollision.position.X;
                float platformRight = platformCollision.position.X + platformCollision.size.X;

                // checks if the player is above the platform and if they will be in the platform next frame
                // if true, it means that last frame you were over the platform but next frame you will be under / in it
                bool isFalling = playerBottom <= platformTop && playerBottom + velocity.Y >= platformTop;
                // checks if the player is within the horizontal space of the platform so that it doesnt span the entire game width
                bool isOverlappingX = playerRight > platformLeft && playerLeft < platformRight;

                // requires both of the previous things to be true AND for you to be moving down
                if (isFalling && isOverlappingX && velocity.Y >= 0)
                {
                    position.Y = platformTop - size.Y;
                    velocity.Y = 0;
                    isGrounded = true;
                    break;
                }
            }

            if (playerBottom < 0)
            {
                level += 1;
                position = new Vector2(295, 525);

                if (level >= 11)
                {
                    isWin = true;
                }
            }

            // ends the game if you fall to the bottom
            if (playerBottom >= Window.Height - 10)
            {
                isDead = true;
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
