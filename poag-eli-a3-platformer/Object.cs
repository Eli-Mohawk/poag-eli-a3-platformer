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

        public Platform(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }

        public void Generate()
        {
            Draw.LineSize = 3;
            Draw.LineColor = Color.Blue;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
        }
    }

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

        public void Generate()
        {
            for (int spikeCount = 0; spikeCount < 100; spikeCount++)
            {
                int spikeGap = spikeCount * 8;

                Draw.LineSize = 1;
                Draw.LineColor = Color.Red;
                Draw.FillColor = Color.Clear;
                Draw.Triangle(new Vector2(top.X + spikeGap, top.Y), new Vector2(right.X + spikeGap, right.Y), new Vector2(left.X + spikeGap, left.Y));
            }



            





        }
    }
}
