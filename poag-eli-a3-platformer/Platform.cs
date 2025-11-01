using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Platform
    {
        public Vector2 position;
        public Vector2 size;
        public Color color;

        // makes the platform list work
        public Platform(Vector2 position, Vector2 size, Color color)
        {
            this.position = position;
            this.size = size;
            this.color = color;
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
            Draw.LineColor = color;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
        }
    }
}
