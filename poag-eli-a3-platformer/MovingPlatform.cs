using MohawkGame2D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class MovingPlatform
    {
        public Vector2 position;
        public Vector2 size;
        public Vector2 startPos;
        public Vector2 endPos;
        public Vector2 moveSpeed;

        bool isMovingRight;
        bool isMovingDown;

        public Vector2 distance { get; private set; }

        public MovingPlatform(Vector2 position, Vector2 size, Vector2 startPos, Vector2 endPos, Vector2 moveSpeed)
        {
            this.position = position;
            this.size = size;
            this.startPos = startPos;
            this.endPos = endPos;
            this.moveSpeed = moveSpeed;
        }

        public void Update()
        {
            MovePlatform();
            DrawPlatform();
        }

        void MovePlatform()
        {
            Vector2 pastPosition = position;

            if (isMovingRight)
            {
                if (position.X + size.X < endPos.X)
                {
                    position.X += moveSpeed.X;
                }
                if (position.X + size.X >= endPos.X)
                {
                    isMovingRight = false;
                    position.X = endPos.X - size.X;
                }
            }
            if (isMovingDown)
            {
                if (position.Y + size.Y < endPos.Y)
                {
                    position.Y += moveSpeed.Y;
                }
                if (position.Y + size.Y >= endPos.Y)
                {
                    isMovingDown = false;
                    position.Y = endPos.Y - size.Y;
                }
            }
            if (!isMovingRight)
            {
                if (position.X > startPos.X)
                {
                    position.X -= moveSpeed.X;
                }
                if (position.X <= startPos.X)
                {
                    isMovingRight = true;
                    position.X = startPos.X;
                }
            }
            if (!isMovingDown)
            {
                if (position.Y > startPos.Y)
                {
                    position.Y -= moveSpeed.Y;
                }
                if (position.Y <= startPos.Y)
                {
                    isMovingDown = true;
                    position.Y = startPos.Y;
                }
            }

            distance = position - pastPosition;
        }

        void DrawPlatform()
        {
            Draw.LineSize = 3;
            Draw.LineColor = Color.Blue;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
        }
    }
}
