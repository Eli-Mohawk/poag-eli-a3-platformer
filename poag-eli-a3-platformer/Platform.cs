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

        // makes the platform list work
        public Platform(Vector2 position, Vector2 size)
        {
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
        }
    }
}
