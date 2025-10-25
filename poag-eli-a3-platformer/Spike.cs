using System;
using System.Collections.Generic;
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
            Draw.LineSize = 1;
            Draw.LineColor = Color.Red;
            Draw.FillColor = Color.Clear;
            Draw.Triangle(top, right, left);
        }
    }
}
