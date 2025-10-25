using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public static class CollisionDetection
    {
        public static bool CheckCollision(Vector2 playerPosition, Vector2 playerSize, Vector2 platformPosition, Vector2 platformSize)
        {
            return (playerPosition.X < platformPosition.X + platformSize.X && // left collision
                    playerPosition.X + playerSize.X > platformPosition.X && // right collision
                    playerPosition.Y < platformPosition.Y + platformSize.Y && // top collision
                    playerPosition.Y + playerSize.Y > platformPosition.Y); // bottom collision
        }
    }
}
