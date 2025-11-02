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

        // platforms = position, size
        // movingPlatforms = position, size, max left, max right, speed
        // spikes = top position, right position, left position

        #region Level titles
        public String[] levelNames;

        String levelZero = "&%@!^ &: #!@*^ #&$%"; // Level 0: Total Void
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
            levelNames = [levelZero, levelOne, levelTwo, levelThree, levelFour, levelFive, levelSix, levelSeven, levelEight, levelNine, levelTen];
        }

        public void Update(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            Levels(platforms, spikes, movingPlatforms);
        }

        void Levels(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            // start platfoem
            if (currentLevel < 10 && currentLevel > 0)
            {
                platforms.Add(new Platform(startPosition, startSize, Color.Blue));
            }

            if (currentLevel == 0)
            {
                LevelZero(platforms, spikes);
            }
            if (currentLevel == 1)
            {
                LevelOne(platforms, spikes);
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
                LevelSeven(platforms, movingPlatforms);
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
                LevelTen(platforms, movingPlatforms);
            }
        }

        void DrawSpikeFloor(List<Spike> spikes)
        {
            Vector2 top = new Vector2(4, 590);
            Vector2 right = new Vector2(8, 600);
            Vector2 left = new Vector2(0, 600);

            for (int spikeCount = 0; spikeCount < 100; spikeCount++)
            {
                int spikeGap = spikeCount * 8;

                Spike newSpike = new Spike(new Vector2(top.X + spikeGap, top.Y), new Vector2(right.X + spikeGap, right.Y), new Vector2(left.X + spikeGap, left.Y), Color.Red);

                spikes.Add(newSpike);
            }
        }

        #region Levels
        void LevelZero(List<Platform> platforms, List<Spike> spikes)
        {
            platforms.Add(new Platform(new Vector2(700, 550), new Vector2(100, 20), Color.Blue));

            platforms.Add(new Platform(new Vector2(), new Vector2(), Color.Clear));
            spikes.Add(new Spike(new Vector2(), new Vector2(), new Vector2(), Color.Clear));

            platforms.Add(new Platform(new Vector2(545, 505), new Vector2(60, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(400, 470), new Vector2(40, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(510, 400), new Vector2(30, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(590, 360), new Vector2(15, 10), Color.Clear));
            platforms.Add(new Platform(new Vector2(705, 310), new Vector2(35, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(550, 265), new Vector2(60, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(415, 205), new Vector2(40, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(265, 170), new Vector2(50, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(110, 125), new Vector2(50, 20), Color.Clear));
            platforms.Add(new Platform(new Vector2(200, 50), new Vector2(80, 20), Color.Clear));

            spikes.Add(new Spike(new Vector2(405, 450), new Vector2(410, 470), new Vector2(400, 470), Color.Clear));
            spikes.Add(new Spike(new Vector2(535, 380), new Vector2(540, 400), new Vector2(530, 400), Color.Clear));
            spikes.Add(new Spike(new Vector2(735, 290), new Vector2(740, 310), new Vector2(730, 310), Color.Clear));
            spikes.Add(new Spike(new Vector2(580, 245), new Vector2(585, 265), new Vector2(575, 265), Color.Clear));
            spikes.Add(new Spike(new Vector2(435, 185), new Vector2(440, 205), new Vector2(430, 205), Color.Clear));
            spikes.Add(new Spike(new Vector2(290, 150), new Vector2(295, 170), new Vector2(285, 170), Color.Clear));
            spikes.Add(new Spike(new Vector2(135, 105), new Vector2(140, 125), new Vector2(130, 125), Color.Clear));
        }

        void LevelOne(List<Platform> platforms, List<Spike> spikes)
        {
            platforms.Add(new Platform(new Vector2(440, 490), new Vector2(70, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(585, 420), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(475, 365), new Vector2(55, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(345, 390), new Vector2(35, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(220, 395), new Vector2(60, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(160, 325), new Vector2(30, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(65, 250), new Vector2(60, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(180, 190), new Vector2(25, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(100, 120), new Vector2(15, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(0, 80), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(140, 25), new Vector2(100, 20), Color.Blue));

            DrawSpikeFloor(spikes);
        }

        void LevelTwo(List<Platform> platforms)
        {
            platforms.Add(new Platform(new Vector2(260, 550), new Vector2(90, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(150, 490), new Vector2(60, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(230, 420), new Vector2(35, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(310, 380), new Vector2(35, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(500, 540), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(550, 465), new Vector2(60, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(680, 420), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(605, 350), new Vector2(65, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(545, 300), new Vector2(30, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(430, 265), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(250, 280), new Vector2(50, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(100, 220), new Vector2(80, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(0, 155), new Vector2(50, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(130, 90), new Vector2(15, 15), Color.Blue));
            platforms.Add(new Platform(new Vector2(225, 80), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(305, 35), new Vector2(100, 20), Color.Blue));
        }

        void LevelThree(List<Platform> platforms)
        {
            platforms.Add(new Platform(new Vector2(440, 495), new Vector2(30, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(470, 370), new Vector2(20, 135), Color.Blue));
            platforms.Add(new Platform(new Vector2(440, 425), new Vector2(30, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(535, 345), new Vector2(45, 15), Color.Blue));
            platforms.Add(new Platform(new Vector2(580, 235), new Vector2(15, 125), Color.Blue));
            platforms.Add(new Platform(new Vector2(425, 290), new Vector2(100, 15), Color.Blue));
            platforms.Add(new Platform(new Vector2(450, 235), new Vector2(130, 15), Color.Blue));
            platforms.Add(new Platform(new Vector2(410, 190), new Vector2(15, 115), Color.Blue));
            platforms.Add(new Platform(new Vector2(260, 200), new Vector2(15, 170), Color.Blue));
            platforms.Add(new Platform(new Vector2(240, 240), new Vector2(20, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(240, 290), new Vector2(20, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(240, 360), new Vector2(20, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(175, 120), new Vector2(15, 140), Color.Blue));
            platforms.Add(new Platform(new Vector2(135, 315), new Vector2(15, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(120, 205), new Vector2(15, 120), Color.Blue));
            platforms.Add(new Platform(new Vector2(135, 270), new Vector2(15, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(40, 150), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(190, 50), new Vector2(45, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(170, 0), new Vector2(85, 5), Color.Blue));
            platforms.Add(new Platform(new Vector2(280, 85), new Vector2(35, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(400, 85), new Vector2(75, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(555, 50), new Vector2(100, 20), Color.Blue));
        }

        void LevelFour(List<Platform> platforms)
        {
            platforms.Add(new Platform(new Vector2(150, 500), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(45, 445), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(140, 410), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(215, 350), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(345, 350), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(470, 310), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(560, 235), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(500, 160), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(350, 180), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(235, 145), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(125, 105), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(25, 75), new Vector2(10, 10), Color.Blue));
        }

        void LevelFive(List<Platform> platforms, List<Spike> spikes)
        {
            platforms.Add(new Platform(new Vector2(410, 500), new Vector2(60, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(540, 440), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(655, 395), new Vector2(145, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(660, 320), new Vector2(80, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(580, 265), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(520, 320), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(380, 270), new Vector2(50, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(220, 250), new Vector2(70, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(60, 195), new Vector2(90, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(30, 40), new Vector2(20, 120), Color.Blue)); // wall
            platforms.Add(new Platform(new Vector2(230, 130), new Vector2(55, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(230, 0), new Vector2(40, 25), Color.Blue)); // block
            platforms.Add(new Platform(new Vector2(370, 90), new Vector2(60, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(510, 70), new Vector2(130, 15), Color.Blue));

            spikes.Add(new Spike(new Vector2(410, 500), new Vector2(410, 510), new Vector2(390, 505), Color.Red)); // p1 L
            spikes.Add(new Spike(new Vector2(440, 480), new Vector2(445, 500), new Vector2(435, 500), Color.Red)); // p1 T
            spikes.Add(new Spike(new Vector2(540, 440), new Vector2(540, 450), new Vector2(520, 445), Color.Red)); // p2 L
            spikes.Add(new Spike(new Vector2(545, 470), new Vector2(550, 450), new Vector2(540, 450), Color.Red)); // p2 B
            spikes.Add(new Spike(new Vector2(550, 440), new Vector2(570, 445), new Vector2(550, 450), Color.Red)); // p2 R
            spikes.Add(new Spike(new Vector2(675, 375), new Vector2(670, 395), new Vector2(680, 395), Color.Red)); // p3 T
            spikes.Add(new Spike(new Vector2(800, 375), new Vector2(800, 395), new Vector2(760, 385), Color.Red)); // p3 WB
            spikes.Add(new Spike(new Vector2(800, 355), new Vector2(800, 375), new Vector2(760, 365), Color.Red)); // p3 WT
            spikes.Add(new Spike(new Vector2(585, 295), new Vector2(590, 275), new Vector2(580, 275), Color.Red)); // p5 B
            spikes.Add(new Spike(new Vector2(555, 300), new Vector2(560, 320), new Vector2(550, 320), Color.Red)); // p6 T
            spikes.Add(new Spike(new Vector2(430, 270), new Vector2(450, 275), new Vector2(430, 280), Color.Red)); // p7 R
            spikes.Add(new Spike(new Vector2(225, 230), new Vector2(230, 250), new Vector2(220, 250), Color.Red)); // p8 TL
            spikes.Add(new Spike(new Vector2(285, 230), new Vector2(290, 250), new Vector2(280, 250), Color.Red)); // p8 TR
            spikes.Add(new Spike(new Vector2(50, 140), new Vector2(90, 150), new Vector2(50, 160), Color.Red)); // pW B
            spikes.Add(new Spike(new Vector2(50, 120), new Vector2(90, 130), new Vector2(50, 140), Color.Red)); // pW BT
            spikes.Add(new Spike(new Vector2(50, 100), new Vector2(90, 110), new Vector2(50, 120), Color.Red)); // pW MB
            spikes.Add(new Spike(new Vector2(50, 80), new Vector2(90, 90), new Vector2(50, 100), Color.Red)); // pW M
            spikes.Add(new Spike(new Vector2(50, 60), new Vector2(90, 70), new Vector2(50, 80), Color.Red)); // pW MT
            spikes.Add(new Spike(new Vector2(50, 40), new Vector2(90, 50), new Vector2(50, 60), Color.Red)); // pW T
            spikes.Add(new Spike(new Vector2(240, 63), new Vector2(230, 23), new Vector2(250, 23), Color.Red)); // pB L
            spikes.Add(new Spike(new Vector2(260, 63), new Vector2(250, 23), new Vector2(270, 23), Color.Red)); // pB R
            spikes.Add(new Spike(new Vector2(515, 50), new Vector2(520, 70), new Vector2(510, 70), Color.Red)); // p14 L
        }

        void LevelSix(List<Platform> platforms, List<Spike> spikes)
        {
            platforms.Add(new Platform(new Vector2(410, 490), new Vector2(70, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(560, 450), new Vector2(50, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(400, 390), new Vector2(90, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(310, 350), new Vector2(45, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(150, 465), new Vector2(45, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(0, 410), new Vector2(85, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(130, 350), new Vector2(35, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(0, 300), new Vector2(85, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(150, 235), new Vector2(35, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(260, 190), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(395, 140), new Vector2(80, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(530, 75), new Vector2(40, 10), Color.Blue));

            spikes.Add(new Spike(new Vector2(445, 470), new Vector2(450, 490), new Vector2(440, 490), Color.Red)); // p1
            spikes.Add(new Spike(new Vector2(565, 430), new Vector2(570, 450), new Vector2(560, 450), Color.Red)); // p2
            spikes.Add(new Spike(new Vector2(405, 420), new Vector2(410, 400), new Vector2(400, 400), Color.Red)); // p3 B
            spikes.Add(new Spike(new Vector2(490, 390), new Vector2(490, 400), new Vector2(510, 395), Color.Red)); // p3 S
            spikes.Add(new Spike(new Vector2(405, 370), new Vector2(410, 390), new Vector2(400, 390), Color.Red)); // p3 T
            spikes.Add(new Spike(new Vector2(350, 330), new Vector2(355, 350), new Vector2(345, 350), Color.Red)); // p4
            spikes.Add(new Spike(new Vector2(155, 445), new Vector2(160, 465), new Vector2(150, 465), Color.Red)); // p5 T L
            spikes.Add(new Spike(new Vector2(190, 445), new Vector2(185, 465), new Vector2(195, 465), Color.Red)); // p5 T R
            spikes.Add(new Spike(new Vector2(5, 390), new Vector2(10, 410), new Vector2(0, 410), Color.Red)); // p6 T
            spikes.Add(new Spike(new Vector2(85, 410), new Vector2(105, 415), new Vector2(85, 420), Color.Red)); // p6 S
            spikes.Add(new Spike(new Vector2(160, 330), new Vector2(155, 350), new Vector2(165, 350), Color.Red)); // p7 T
            spikes.Add(new Spike(new Vector2(5, 330), new Vector2(10, 310), new Vector2(0, 310), Color.Red)); // p8 B
            spikes.Add(new Spike(new Vector2(85, 300), new Vector2(105, 305), new Vector2(85, 310), Color.Red)); // p8 S
            spikes.Add(new Spike(new Vector2(180, 215), new Vector2(185, 235), new Vector2(175, 235), Color.Red)); // p9 T
            spikes.Add(new Spike(new Vector2(280, 170), new Vector2(275, 190), new Vector2(285, 190), Color.Red)); // p10 T
            spikes.Add(new Spike(new Vector2(395, 140), new Vector2(395, 150), new Vector2(375, 145), Color.Red)); // p11 S L
            spikes.Add(new Spike(new Vector2(475, 140), new Vector2(495, 145), new Vector2(475, 150), Color.Red)); // p11 S R
            spikes.Add(new Spike(new Vector2(530, 75), new Vector2(530, 85), new Vector2(510, 80), Color.Red)); // p12 S L
            spikes.Add(new Spike(new Vector2(570, 75), new Vector2(590, 80), new Vector2(570, 85), Color.Red)); // p12 S R
            spikes.Add(new Spike(new Vector2(540, 125), new Vector2(530, 85), new Vector2(550, 85), Color.Red)); // p12 B L
            spikes.Add(new Spike(new Vector2(560, 125), new Vector2(550, 85), new Vector2(570, 85), Color.Red)); // p12 B R
            spikes.Add(new Spike(new Vector2(565, 55), new Vector2(570, 75), new Vector2(560, 75), Color.Red)); // p12 T
        }

        void LevelSeven(List<Platform> platforms, List<MovingPlatform> movingPlatforms)
        {
            platforms.Add(new Platform(new Vector2(670, 450), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(650, 325), new Vector2(60, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(305, 265), new Vector2(35, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(0, 210), new Vector2(115, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(710, 180), new Vector2(50, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(770, 140), new Vector2(30, 20), Color.Blue));

            movingPlatforms.Add(new MovingPlatform(new Vector2(415, 490), new Vector2(65, 20), new Vector2(415, 490), new Vector2(590, 490), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(750, 370), new Vector2(50, 20), new Vector2(751, 350), new Vector2(750, 420), new Vector2(0, 0.5f)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(450, 325), new Vector2(55, 20), new Vector2(400, 325), new Vector2(595, 325), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(210, 230), new Vector2(40, 20), new Vector2(210, 230), new Vector2(210, 450), new Vector2(0, 3)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(210, 170), new Vector2(80, 20), new Vector2(210, 170), new Vector2(610, 170), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(680, 0), new Vector2(35, 20), new Vector2(680, 0), new Vector2(680, 110), new Vector2(0, 0.6f)));
        }

        void LevelEight(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            platforms.Add(new Platform(new Vector2(110, 490), new Vector2(80, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(110, 270), new Vector2(60, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(260, 320), new Vector2(50, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(410, 470), new Vector2(70, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(540, 500), new Vector2(40, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(480, 170), new Vector2(45, 20), Color.Blue));

            movingPlatforms.Add(new MovingPlatform(new Vector2(-1, 200), new Vector2(25, 20), new Vector2(-1, 200), new Vector2(1, 480), new Vector2(0, 1)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(610, 205), new Vector2(30, 20), new Vector2(610, 205), new Vector2(610, 460), new Vector2(0, 1)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(390, 60), new Vector2(15, 20), new Vector2(390, 60), new Vector2(390, 220), new Vector2(0, 2)));

            spikes.Add(new Spike(new Vector2(15, 360), new Vector2(20, 380), new Vector2(10, 380), Color.Red)); // m1 r1
            spikes.Add(new Spike(new Vector2(5, 300), new Vector2(10, 320), new Vector2(0, 320), Color.Red)); // m1 l1
            spikes.Add(new Spike(new Vector2(15, 240), new Vector2(20, 260), new Vector2(10, 260), Color.Red)); // m1 r2
            spikes.Add(new Spike(new Vector2(5, 180), new Vector2(10, 200), new Vector2(0, 200), Color.Red)); // m1 l2
            spikes.Add(new Spike(new Vector2(115, 250), new Vector2(120, 270), new Vector2(110, 270), Color.Red)); // p1
            spikes.Add(new Spike(new Vector2(285, 300), new Vector2(290, 320), new Vector2(280, 320), Color.Red)); // p2
            spikes.Add(new Spike(new Vector2(415, 450), new Vector2(420, 470), new Vector2(410, 470), Color.Red)); // p3 l
            spikes.Add(new Spike(new Vector2(475, 450), new Vector2(480, 470), new Vector2(470, 470), Color.Red)); // p3 r
            spikes.Add(new Spike(new Vector2(630, 420), new Vector2(635, 440), new Vector2(625, 440), Color.Red)); // m2 r1
            spikes.Add(new Spike(new Vector2(620, 360), new Vector2(625, 380), new Vector2(615, 380), Color.Red)); // m2 l2
            spikes.Add(new Spike(new Vector2(630, 300), new Vector2(635, 320), new Vector2(625, 320), Color.Red)); // m2 r2
        }

        void LevelNine(List<Platform> platforms, List<Spike> spikes, List<MovingPlatform> movingPlatforms)
        {
            platforms.Add(new Platform(new Vector2(790, 470), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(690, 130), new Vector2(30, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(225, 200), new Vector2(40, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(285, 225), new Vector2(25, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(0, 220), new Vector2(110, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(110, 80), new Vector2(45, 20), Color.Blue));
            platforms.Add(new Platform(new Vector2(260, 70), new Vector2(100, 20), Color.Blue));

            movingPlatforms.Add(new MovingPlatform(new Vector2(410, 500), new Vector2(50, 20), new Vector2(410, 500), new Vector2(700, 500), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(775, 180), new Vector2(25, 20), new Vector2(775, 180), new Vector2(775, 430), new Vector2(0, 1)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(320, 150), new Vector2(50, 20), new Vector2(320, 150), new Vector2(600, 150), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(160, 260), new Vector2(50, 20), new Vector2(160, 260), new Vector2(370, 260), new Vector2(2, 0)));
            movingPlatforms.Add(new MovingPlatform(new Vector2(0, 100), new Vector2(30, 10), new Vector2(0, 100), new Vector2(0, 165), new Vector2(0, 1)));

            spikes.Add(new Spike(new Vector2(465, 480), new Vector2(470, 500), new Vector2(460, 500), Color.Red)); // m1 hl
            spikes.Add(new Spike(new Vector2(555, 480), new Vector2(560, 500), new Vector2(550, 500), Color.Red)); // m1 hm
            spikes.Add(new Spike(new Vector2(645, 480), new Vector2(650, 500), new Vector2(640, 500), Color.Red)); // m1 hr
            spikes.Add(new Spike(new Vector2(795, 360), new Vector2(800, 380), new Vector2(790, 380), Color.Red)); // m2 vr1
            spikes.Add(new Spike(new Vector2(785, 300), new Vector2(790, 320), new Vector2(780, 320), Color.Red)); // m2 vl1
            spikes.Add(new Spike(new Vector2(795, 240), new Vector2(800, 260), new Vector2(790, 260), Color.Red)); // m2 vr2
            spikes.Add(new Spike(new Vector2(495, 130), new Vector2(500, 150), new Vector2(490, 150), Color.Red)); // m3 hr
            spikes.Add(new Spike(new Vector2(425, 130), new Vector2(430, 150), new Vector2(420, 150), Color.Red)); // m3 hl
            spikes.Add(new Spike(new Vector2(260, 180), new Vector2(265, 200), new Vector2(255, 200), Color.Red)); // p3 t
            spikes.Add(new Spike(new Vector2(225, 200), new Vector2(225, 210), new Vector2(205, 205), Color.Red)); // p3 l
            spikes.Add(new Spike(new Vector2(265, 200), new Vector2(285, 205), new Vector2(265, 210), Color.Red)); // p3 r
            spikes.Add(new Spike(new Vector2(285, 225), new Vector2(285, 235), new Vector2(265, 230), Color.Red)); // p4 l
            spikes.Add(new Spike(new Vector2(165, 240), new Vector2(160, 260), new Vector2(170, 260), Color.Red)); // m4 l
            spikes.Add(new Spike(new Vector2(10, 180), new Vector2(20, 220), new Vector2(0, 220), Color.Red)); // p5 l
            spikes.Add(new Spike(new Vector2(30, 180), new Vector2(40, 220), new Vector2(20, 220), Color.Red)); // p5 r
            spikes.Add(new Spike(new Vector2(5, 130), new Vector2(10, 150), new Vector2(0, 150), Color.Red)); // m5 l
            spikes.Add(new Spike(new Vector2(115, 60), new Vector2(120, 80), new Vector2(110, 80), Color.Red)); // p6
        }

        void LevelTen(List<Platform> platforms, List<MovingPlatform> movingPlatforms)
        {
            platforms.Add(new Platform(new Vector2(295, 550), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(200, 500), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(365, 260), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(440, 310), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(560, 420), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(660, 375), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(650, 180), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(240, 220), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(100, 220), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(20, 165), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(15, 120), new Vector2(10, 10), Color.Blue));
            platforms.Add(new Platform(new Vector2(280, 70), new Vector2(10, 10), Color.Blue));

            movingPlatforms.Add(new MovingPlatform(new Vector2(90, 350), new Vector2(10, 10), new Vector2(90, 350), new Vector2(90, 470), new Vector2(0, 2))); // v
            movingPlatforms.Add(new MovingPlatform(new Vector2(155, 310), new Vector2(10, 10), new Vector2(155, 310), new Vector2(280, 310), new Vector2(2, 0))); // h
            movingPlatforms.Add(new MovingPlatform(new Vector2(710, 200), new Vector2(10, 10), new Vector2(710, 200), new Vector2(710, 340), new Vector2(0, 2))); // v
            movingPlatforms.Add(new MovingPlatform(new Vector2(300, 155), new Vector2(10, 10), new Vector2(300, 155), new Vector2(600, 155), new Vector2(3, 0))); // h
            movingPlatforms.Add(new MovingPlatform(new Vector2(80, 80), new Vector2(10, 10), new Vector2(80, 80), new Vector2(230, 80), new Vector2(3, 0))); // h
        }
        #endregion
    }
}
