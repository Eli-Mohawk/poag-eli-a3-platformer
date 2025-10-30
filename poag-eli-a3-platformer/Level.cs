using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Level
    {
        public int currentLevel;

        Vector2 startPosition = new Vector2(260, 550);
        Vector2 startSize = new Vector2(90, 20);

        // what the numbers mean-
        // platforms.Add(new Platform(position, size));
        // movingPlatforms.Add(new MovingPlatform(position, size, left edge, right edge, speed));
        // spikes.Add(new Spike(top position, right position, left position));


        #region Level titles
        public String[] levelNames;
        String levelOne = "Level 1: The Base";
        String levelTwo = "Level 2: First Hurdle";
        String levelThree = "Level 3: The Pillars";
        String levelFour = "Level 4: False Peak";
        String levelFive = "Level 5: True Start";
        String levelSix = "Level 6: Second Hurdle";
        String levelSeven = "Level 7: Shifting Holds";
        String levelEight = "Level 8: Third Hurdle";
        String levelNine = "Level 9: The Final Strech";
        String levelTen = "Level 10: The Peak";

        public Vector2 levelTitle = new Vector2(5, 10);
        #endregion

        public Level(int currentLevel)
        {
            this.currentLevel = currentLevel;
        }

        public void Setup()
        {
            levelNames = [levelOne, levelTwo, levelThree, levelFour, levelFive, levelSix, levelSeven, levelEight, levelNine, levelTen];
        }

        public void Update(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            Levels(platforms, spikes, movingPlatforms);
        }

        void Levels(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            if (currentLevel == 1)
            {
                LevelTest(platforms, spikes, movingPlatforms);
                //LevelOne(platforms, spikes);
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
                LevelFive(platforms, spikes);
            }
            if (currentLevel == 6)
            {
                LevelSix(platforms, spikes);
            }
            if (currentLevel == 7)
            {
                LevelSeven(platforms, spikes, movingPlatforms);
            }
            if (currentLevel == 8)
            {
                LevelEight(platforms, spikes, movingPlatforms);
            }
            if (currentLevel == 9)
            {
                LevelNine(platforms, spikes, movingPlatforms);
            }
            if (currentLevel == 10)
            {
                LevelTen(spikes, movingPlatforms);
            }
        }

        void LevelTest(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            platforms.Add(new Platform(new Vector2(0, 0), new Vector2(0, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)));
            spikes.Add(new Spike(new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)));
            //LevelOne(platforms, spikes);

            
        }

        void DrawSpikeFloor(List<Spike> spikes)
        {
            Vector2 top = new Vector2(4, 590);
            Vector2 right = new Vector2(8, 600);
            Vector2 left = new Vector2(0, 600);

            for (int spikeCount = 0; spikeCount < 100; spikeCount++)
            {
                int spikeGap = spikeCount * 8;

                Spike newSpike = new Spike(new Vector2(top.X + spikeGap, top.Y), new Vector2(right.X + spikeGap, right.Y), new Vector2(left.X + spikeGap, left.Y));

                spikes.Add(newSpike);
            }
        }

        #region Levels
        void LevelOne(List<Platform> platforms, List<Spike> spikes)
        {
            platforms.Add(new Platform(startPosition, startSize));
            platforms.Add(new Platform(new Vector2(440, 490), new Vector2(70, 20)));
            platforms.Add(new Platform(new Vector2(585, 420), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(475, 365), new Vector2(55, 20)));
            platforms.Add(new Platform(new Vector2(345, 390), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(220, 395), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(160, 325), new Vector2(30, 20)));
            platforms.Add(new Platform(new Vector2(65, 250), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(180, 190), new Vector2(25, 20)));
            platforms.Add(new Platform(new Vector2(100, 120), new Vector2(15, 20)));
            platforms.Add(new Platform(new Vector2(0, 80), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(140, 25), new Vector2(100, 20)));

            DrawSpikeFloor(spikes);
        }

        void LevelTwo(List<Platform> platforms)
        {
            platforms.Add(new Platform(startPosition, startSize));
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

        void LevelThree(List<Platform> platforms)
        {
            platforms.Add(new Platform(startPosition, startSize));
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
            platforms.Add(new Platform(new Vector2(175, 120), new Vector2(15, 140)));
            platforms.Add(new Platform(new Vector2(135, 315), new Vector2(15, 10)));
            platforms.Add(new Platform(new Vector2(120, 205), new Vector2(15, 120)));
            platforms.Add(new Platform(new Vector2(135, 270), new Vector2(15, 10)));
            platforms.Add(new Platform(new Vector2(40, 150), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(190, 50), new Vector2(45, 20)));
            platforms.Add(new Platform(new Vector2(170, 0), new Vector2(85, 5)));
            platforms.Add(new Platform(new Vector2(280, 85), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(400, 85), new Vector2(75, 20)));
            platforms.Add(new Platform(new Vector2(555, 50), new Vector2(100, 20)));
        }

        void LevelFour(List<Platform> platforms)
        {
            platforms.Add(new Platform(startPosition, startSize));
            platforms.Add(new Platform(new Vector2(150, 500), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(45, 445), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(140, 410), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(215, 350), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(345, 350), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(470, 310), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(560, 235), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(500, 160), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(350, 180), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(235, 145), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(125, 105), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(25, 75), new Vector2(10, 10)));
        }

        void LevelFive(List<Platform> platforms, List<Spike> spikes)
        {
            platforms.Add(new Platform(startPosition, startSize));
            platforms.Add(new Platform(new Vector2(410, 500), new Vector2(60, 10)));
            platforms.Add(new Platform(new Vector2(540, 440), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(655, 395), new Vector2(145, 20)));
            platforms.Add(new Platform(new Vector2(660, 320), new Vector2(80, 20)));
            platforms.Add(new Platform(new Vector2(580, 265), new Vector2(10, 10)));
            platforms.Add(new Platform(new Vector2(520, 320), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(380, 270), new Vector2(50, 10)));
            platforms.Add(new Platform(new Vector2(220, 250), new Vector2(70, 20)));
            platforms.Add(new Platform(new Vector2(60, 195), new Vector2(90, 20)));
            platforms.Add(new Platform(new Vector2(30, 40), new Vector2(20, 120))); // wall
            platforms.Add(new Platform(new Vector2(230, 130), new Vector2(55, 20)));
            platforms.Add(new Platform(new Vector2(230, 0), new Vector2(40, 25))); // block
            platforms.Add(new Platform(new Vector2(370, 90), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(510, 70), new Vector2(130, 15)));

            spikes.Add(new Spike(new Vector2(410, 500), new Vector2(410, 510), new Vector2(390, 505))); // p1 L
            spikes.Add(new Spike(new Vector2(440, 480), new Vector2(445, 500), new Vector2(435, 500))); // p1 T
            spikes.Add(new Spike(new Vector2(540, 440), new Vector2(540, 450), new Vector2(520, 445))); // p2 L
            spikes.Add(new Spike(new Vector2(545, 470), new Vector2(550, 450), new Vector2(540, 450))); // p2 B
            spikes.Add(new Spike(new Vector2(550, 440), new Vector2(570, 445), new Vector2(550, 450))); // p2 R
            spikes.Add(new Spike(new Vector2(675, 375), new Vector2(670, 395), new Vector2(680, 395))); // p3 T
            spikes.Add(new Spike(new Vector2(800, 375), new Vector2(800, 395), new Vector2(760, 385))); // p3 WB
            spikes.Add(new Spike(new Vector2(800, 355), new Vector2(800, 375), new Vector2(760, 365))); // p3 WT
            spikes.Add(new Spike(new Vector2(585, 295), new Vector2(590, 275), new Vector2(580, 275))); // p5 B
            spikes.Add(new Spike(new Vector2(555, 300), new Vector2(560, 320), new Vector2(550, 320))); // p6 T
            spikes.Add(new Spike(new Vector2(430, 270), new Vector2(450, 275), new Vector2(430, 280))); // p7 R
            spikes.Add(new Spike(new Vector2(225, 230), new Vector2(230, 250), new Vector2(220, 250))); // p8 TL
            spikes.Add(new Spike(new Vector2(285, 230), new Vector2(290, 250), new Vector2(280, 250))); // p8 TR
            spikes.Add(new Spike(new Vector2(50, 140), new Vector2(90, 150), new Vector2(50, 160))); // pW B
            spikes.Add(new Spike(new Vector2(50, 120), new Vector2(90, 130), new Vector2(50, 140))); // pW BT
            spikes.Add(new Spike(new Vector2(50, 100), new Vector2(90, 110), new Vector2(50, 120))); // pW MB
            spikes.Add(new Spike(new Vector2(50, 80), new Vector2(90, 90), new Vector2(50, 100))); // pW M
            spikes.Add(new Spike(new Vector2(50, 60), new Vector2(90, 70), new Vector2(50, 80))); // pW MT
            spikes.Add(new Spike(new Vector2(50, 40), new Vector2(90, 50), new Vector2(50, 60))); // pW T
            spikes.Add(new Spike(new Vector2(240, 63), new Vector2(230, 23), new Vector2(250, 23))); // pB L
            spikes.Add(new Spike(new Vector2(260, 63), new Vector2(250, 23), new Vector2(270, 23))); // pB R
            spikes.Add(new Spike(new Vector2(515, 50), new Vector2(520, 70), new Vector2(510, 70))); // p14 L
        }

        void LevelSix(List<Platform> platforms, List<Spike> spikes)
        {
            platforms.Add(new Platform(startPosition, startSize));
            platforms.Add(new Platform(new Vector2(410, 490), new Vector2(70, 20)));
            platforms.Add(new Platform(new Vector2(560, 450), new Vector2(50, 20)));
            platforms.Add(new Platform(new Vector2(400, 390), new Vector2(90, 10)));
            platforms.Add(new Platform(new Vector2(310, 350), new Vector2(45, 20)));
            platforms.Add(new Platform(new Vector2(150, 465), new Vector2(45, 20)));
            platforms.Add(new Platform(new Vector2(0, 410), new Vector2(85, 10)));
            platforms.Add(new Platform(new Vector2(130, 350), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(0, 300), new Vector2(85, 10)));
            platforms.Add(new Platform(new Vector2(150, 235), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(260, 190), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(395, 140), new Vector2(80, 10)));
            platforms.Add(new Platform(new Vector2(530, 75), new Vector2(40, 10)));

            spikes.Add(new Spike(new Vector2(445, 470), new Vector2(450, 490), new Vector2(440, 490))); // p1
            spikes.Add(new Spike(new Vector2(565, 430), new Vector2(570, 450), new Vector2(560, 450))); // p2
            spikes.Add(new Spike(new Vector2(405, 420), new Vector2(410, 400), new Vector2(400, 400))); // p3 B
            spikes.Add(new Spike(new Vector2(490, 390), new Vector2(490, 400), new Vector2(510, 395))); // p3 S
            spikes.Add(new Spike(new Vector2(405, 370), new Vector2(410, 390), new Vector2(400, 390))); // p3 T
            spikes.Add(new Spike(new Vector2(350, 330), new Vector2(355, 350), new Vector2(345, 350))); // p4
            spikes.Add(new Spike(new Vector2(155, 445), new Vector2(160, 465), new Vector2(150, 465))); // p5 T L
            spikes.Add(new Spike(new Vector2(190, 445), new Vector2(185, 465), new Vector2(195, 465))); // p5 T R
            spikes.Add(new Spike(new Vector2(5, 390), new Vector2(10, 410), new Vector2(0, 410))); // p6 T
            spikes.Add(new Spike(new Vector2(85, 410), new Vector2(105, 415), new Vector2(85, 420))); // p6 S
            spikes.Add(new Spike(new Vector2(160, 330), new Vector2(155, 350), new Vector2(165, 350))); // p7 T
            spikes.Add(new Spike(new Vector2(5, 330), new Vector2(10, 310), new Vector2(0, 310))); // p8 B
            spikes.Add(new Spike(new Vector2(85, 300), new Vector2(105, 305), new Vector2(85, 310))); // p8 S
            spikes.Add(new Spike(new Vector2(180, 215), new Vector2(185, 235), new Vector2(175, 235))); // p9 T
            spikes.Add(new Spike(new Vector2(280, 170), new Vector2(275, 190), new Vector2(285, 190))); // p10 T
            spikes.Add(new Spike(new Vector2(395, 140), new Vector2(395, 150), new Vector2(375, 145))); // p11 S L
            spikes.Add(new Spike(new Vector2(475, 140), new Vector2(495, 145), new Vector2(475, 150))); // p11 S R
            spikes.Add(new Spike(new Vector2(530, 75), new Vector2(530, 85), new Vector2(510, 80))); // p12 S L
            spikes.Add(new Spike(new Vector2(570, 75), new Vector2(590, 80), new Vector2(570, 85))); // p12 S R
            spikes.Add(new Spike(new Vector2(540, 125), new Vector2(530, 85), new Vector2(550, 85))); // p12 B L
            spikes.Add(new Spike(new Vector2(560, 125), new Vector2(550, 85), new Vector2(570, 85))); // p12 B R
            spikes.Add(new Spike(new Vector2(565, 55), new Vector2(570, 75), new Vector2(560, 75))); // p12 T
        }

        void LevelSeven(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            platforms.Add(new Platform(startPosition, startSize));
            platforms.Add(new Platform(new Vector2(670, 450), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(650, 325), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(305, 265), new Vector2(35, 20)));
            platforms.Add(new Platform(new Vector2(0, 210), new Vector2(115, 20)));
            platforms.Add(new Platform(new Vector2(710, 180), new Vector2(50, 20)));
            platforms.Add(new Platform(new Vector2(770, 140), new Vector2(30, 20)));

            movingPlatforms.Add(new MovingPlatform(new Vector2(415, 490), new Vector2(65, 20), new Vector2(415, 490), new Vector2(590, 490), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(750, 370), new Vector2(50, 20), new Vector2(750, 350), new Vector2(750, 420), new Vector2(0, 0.5f)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(450, 325), new Vector2(55, 20), new Vector2(400, 325), new Vector2(595, 325), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(210, 230), new Vector2(40, 20), new Vector2(210, 230), new Vector2(210, 450), new Vector2(0, 3)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(210, 170), new Vector2(80, 20), new Vector2(210, 170), new Vector2(610, 170), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(680, 0), new Vector2(35, 20), new Vector2(680, 0), new Vector2(680, 110), new Vector2(0, 0.6f)));
        }

        void LevelEight(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            platforms.Add(new Platform(startPosition, startSize));
            platforms.Add(new Platform(new Vector2(110, 490), new Vector2(80, 20)));
            platforms.Add(new Platform(new Vector2(110, 270), new Vector2(60, 20)));
            platforms.Add(new Platform(new Vector2(260, 320), new Vector2(50, 20)));
            platforms.Add(new Platform(new Vector2(410, 470), new Vector2(70, 20)));
            platforms.Add(new Platform(new Vector2(540, 500), new Vector2(40, 20)));
            platforms.Add(new Platform(new Vector2(480, 170), new Vector2(45, 20)));

            movingPlatforms.Add(new MovingPlatform(new Vector2(-1, 200), new Vector2(25, 20), new Vector2(-1, 200), new Vector2(1, 480), new Vector2(0, 1)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(610, 205), new Vector2(30, 20), new Vector2(610, 205), new Vector2(610, 460), new Vector2(0, 1)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(390, 60), new Vector2(15, 20), new Vector2(390, 60), new Vector2(390, 220), new Vector2(0, 2)));

            spikes.Add(new Spike(new Vector2(15, 360), new Vector2(20, 380), new Vector2(10, 380))); // m1 r1
            spikes.Add(new Spike(new Vector2(5, 300), new Vector2(10, 320), new Vector2(0, 320))); // m1 l1
            spikes.Add(new Spike(new Vector2(15, 240), new Vector2(20, 260), new Vector2(10, 260))); // m1 r2
            spikes.Add(new Spike(new Vector2(5, 180), new Vector2(10, 200), new Vector2(0, 200))); // m1 l2
            spikes.Add(new Spike(new Vector2(115, 250), new Vector2(120, 270), new Vector2(110, 270))); // p1
            spikes.Add(new Spike(new Vector2(285, 300), new Vector2(290, 320), new Vector2(280, 320))); // p2
            spikes.Add(new Spike(new Vector2(415, 450), new Vector2(420, 470), new Vector2(410, 470))); // p3 l
            spikes.Add(new Spike(new Vector2(475, 450), new Vector2(480, 470), new Vector2(470, 470))); // p3 r
            spikes.Add(new Spike(new Vector2(630, 420), new Vector2(635, 440), new Vector2(625, 440))); // m2 r1
            spikes.Add(new Spike(new Vector2(620, 360), new Vector2(625, 380), new Vector2(615, 380))); // m2 l2
            spikes.Add(new Spike(new Vector2(630, 300), new Vector2(635, 320), new Vector2(625, 320))); // m2 r2
        }

        void LevelNine(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {

        }

        void LevelTen(List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {

        }
        #endregion
    }
}
