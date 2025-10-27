using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Spike
    {
        Vector2 top;
        Vector2 right;
        Vector2 left;

        public Spike(Vector2 top, Vector2 right, Vector2 left)
        {
            this.top = top;
            this.right = right;
            this.left = left;
        }

        public void Setup()
        {

        }

        public void Update()
        {
            DrawSpike();
        }

        void DrawSpike()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.Clear;
            Draw.Triangle(top, right, left);
        }

        public RectangleF GetHitbox()
        {
            float minX = Math.Min(top.X, Math.Min(left.X, right.X));
            float maxX = Math.Max(top.X, Math.Max(left.X, right.X));
            float minY = Math.Min(top.Y, Math.Min(left.Y, right.Y));
            float maxY = Math.Max(top.Y, Math.Max(left.Y, right.Y));

            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }
    }
}
