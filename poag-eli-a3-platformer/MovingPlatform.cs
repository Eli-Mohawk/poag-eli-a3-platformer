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
        public Vector2 position;
        public Vector2 size;
        public Vector2 moveSpeed;

        // makes the platform list work
        public MovingPlatform(Vector2 position, Vector2 size, Vector2 moveSpeed)
        {
            if (moveSpeed.X > 0 || moveSpeed.Y > 0)
            {
                this.position += moveSpeed;
            }
            else if (moveSpeed.X < 0 || moveSpeed.Y < 0)
            {
                this.position += moveSpeed;

            }
            this.position = position;
            this.size = size;
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
            Draw.LineSize = 3;
            Draw.LineColor = Color.Blue;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
            Draw.Line(new Vector2(position.X + (size.X * 0.5f), position.Y), new Vector2(position.X + (size.X * 0.5f), position.Y + size.Y)); // vertical line
            Draw.Line(new Vector2(position.X, position.Y + (size.Y * 0.5f)), new Vector2(position.X + size.X, position.Y + (size.Y * 0.5f))); // horizontal line
        }
    }
}
