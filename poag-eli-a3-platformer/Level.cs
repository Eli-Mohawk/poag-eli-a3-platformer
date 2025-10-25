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
                LevelTest(platforms);
                //LevelOne(platforms);
            }
            if (currentLevel == 2)
            {
                LevelTwo(platforms);
            }
            if (currentLevel == 3)
            {
                LevelThree(platforms);
            }
            if (currentLevel == 4)
            {
                LevelFour(platforms);
            }
            if (currentLevel == 5)
            {
                LevelFive(platforms);
            }
            if (currentLevel == 6)
            {
                LevelSix(platforms);
            }
            if (currentLevel == 7)
            {
                LevelSeven(platforms);
            }
            if (currentLevel == 8)
            {
                LevelEight(platforms);
            }
            if (currentLevel == 9)
            {
                LevelNine(platforms);
            }
            if (currentLevel == 10)
            {
                LevelTen(platforms);
            }
        }

        void LevelTest(List<Platform> platforms)
        {
            platforms.Add(new Platform(new Vector2(0, 0), new Vector2(0, 0)));

        }

        #region Levels
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
            platforms.Add(new Platform(new Vector2(440, 495), new Vector2(30, 10)));
            platforms.Add(new Platform(new Vector2(470, 370), new Vector2(20, 135)));
            platforms.Add(new Platform(new Vector2(440, 425), new Vector2(30, 10)));
            platforms.Add(new Platform(new Vector2(535, 345), new Vector2(45, 15)));
            platforms.Add(new Platform(new Vector2(580, 235), new Vector2(15, 125)));
            platforms.Add(new Platform(new Vector2(425, 290), new Vector2(100, 15)));
            platforms.Add(new Platform(new Vector2(450, 235), new Vector2(130, 15)));
            platforms.Add(new Platform(new Vector2(410, 190), new Vector2(15, 115)));
            platforms.Add(new Platform(new Vector2(260, 200), new Vector2(15, 170)));
            platforms.Add(new Platform(new Vector2(240, 240), new Vector2(20, 10)));
            platforms.Add(new Platform(new Vector2(240, 290), new Vector2(20, 10)));
            platforms.Add(new Platform(new Vector2(240, 360), new Vector2(20, 10)));
            platforms.Add(new Platform(new Vector2(175, 120), new Vector2(15, 145)));
            platforms.Add(new Platform(new Vector2(135, 315), new Vector2(15, 10)));
            platforms.Add(new Platform(new Vector2(120, 205), new Vector2(15, 120)));
            platforms.Add(new Platform(new Vector2(135, 270), new Vector2(15, 10)));
            platforms.Add(new Platform(new Vector2(40, 150), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(190, 50), new Vector2(45, 20)));
            platforms.Add(new Platform(new Vector2(170, -1), new Vector2(85, 5)));
            platforms.Add(new Platform(new Vector2(280, 85), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(400, 85), new Vector2(75, 20)));
            platforms.Add(new Platform(new Vector2(555, 50), new Vector2(100, 20)));
        }

        void LevelThree(List<Platform> platforms)
        {

        }

        void LevelFour(List<Platform> platforms)
        {

        }

        void LevelFive(List<Platform> platforms)
        {

        }

        void LevelSix(List<Platform> platforms)
        {

        }

        void LevelSeven(List<Platform> platforms)
        {

        }

        void LevelEight(List<Platform> platforms)
        {

        }

        void LevelNine(List<Platform> platforms)
        {

        }

        void LevelTen(List<Platform> platforms)
        {

        }
        #endregion
    }
}
