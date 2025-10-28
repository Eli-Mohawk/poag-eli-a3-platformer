using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class MovingPlatform
    {
        public Vector2 startPosition;
        public Vector2 endPosition;
        public Vector2 size;
        public Vector2 moveSpeed;

        // makes the platform list work
        public MovingPlatform(Vector2 startPosition, Vector2 endPosition, Vector2 size, Vector2 moveSpeed)
        {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.size = size;
            this.moveSpeed = moveSpeed;


        }

        public void Setup()
        {

        }

        public void Update()
        {
            DrawPlatform();
        }

        void DrawPlatform()
        {
            bool isMovingRight = false;

            if (isMovingRight)
            {
                startPosition += moveSpeed;

                if (startPosition.X >= endPosition.X || startPosition.Y >= endPosition.Y)
                {
                    isMovingRight = false;
                }
            }
            else
            {
                startPosition -= moveSpeed;

                if (startPosition.X <= endPosition.X - (endPosition.X - startPosition.X) || startPosition.Y <= endPosition.Y - (endPosition.Y - startPosition.Y))
                {
                    isMovingRight = true;
                }
            }

            Draw.LineSize = 3;
            Draw.LineColor = Color.Blue;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(startPosition, size);

        }
    }
}
