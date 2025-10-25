using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Level
    {
        public int currentLevel;

        public Level(int currentLevel)
        {
            this.currentLevel = currentLevel;
        }

        public void Setup()
        {

        }

        public void Update(List<Platform> platforms)
        {
            Levels(platforms);
        }

        void Levels(List<Platform> platforms)
        {
            if (currentLevel == 1)
            {
                LevelOne(platforms);
            }

            if (currentLevel == 2)
            {
                LevelTwo(platforms);
            }
        }

        void LevelOne(List<Platform> platforms)
        {
            platforms.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
            platforms.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
            platforms.Add(new Platform(new Vector2(150, 490), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(230, 420), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(310, 380), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(500, 540), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(550, 465), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(680, 420), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(605, 350), new Vector2(65, 20)));
            platforms.Add(new Platform(new Vector2(545, 300), new Vector2(30, 20)));
            platforms.Add(new Platform(new Vector2(430, 265), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(250, 280), new Vector2(50, 20)));
            platforms.Add(new Platform(new Vector2(100, 220), new Vector2(80, 20)));
            platforms.Add(new Platform(new Vector2(0, 155), new Vector2(50, 20)));
            platforms.Add(new Platform(new Vector2(130, 90), new Vector2(15, 15)));
            platforms.Add(new Platform(new Vector2(225, 80), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(305, 35), new Vector2(100, 20)));
        }

        void LevelTwo(List<Platform> platforms)
        {
            platforms.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20)));
            platforms.Add(new Platform(new Vector2(0, 155), new Vector2(50, 20)));
        }
    }
}
