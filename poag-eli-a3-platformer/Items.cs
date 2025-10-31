using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Items
    {
        public Vector2 position;

        public void Setup()
        {

        }

        public void Update()
        {
            HeartItem();
            DrawHeartItem();
        }

        void HeartItem()
        {
            
        }

        void DrawHeartItem()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Red;
            Draw.Circle(position, 10);
            Draw.Circle(new Vector2(position.X + 18, position.Y), 10);
            Draw.Triangle(new Vector2(position.X + 8, position.Y + 30), new Vector2(position.X + 30, position.Y), new Vector2(position.X - 12, position.Y));
        }
    }
}
