using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using RC_Framework;
namespace Assignment
{
    class Global
    {
        public static GraphicsDevice graphicsDevice;
        public static SpriteBatch spriteBatch;

        public static Rectangle screenRec;
        public static Rectangle enemyOffRec;

        public static ContentManager Content;
        public static RC_GameStateManager gameStateManager;

        public static KeyboardState keyState;     // must use or keystate can be unstable on level change
        public static KeyboardState prevKeyState; // must use or keystate can be unstable on level change

        public static MouseState currentMouseState;  // must use or mousestate can be unstable on level change
        public static MouseState previousMouseState; // must use or mousestate can be unstable on level change

        public string stateId = ""; // expansion to identify levels/states


        public static float mouse_x = 0; // for convenience - not really needed
        public static float mouse_y = 0; // for convenience - not really needed
        public static string dir;

        public static Texture2D texBack1 = null;
        public static Texture2D texBack2 = null;
        public static Texture2D texBack3 = null;
        public static Texture2D texBackMeteorite1 = null;
        public static Texture2D texBackMeteorite2 = null;
        public static Texture2D texMeteorite1 = null;
        public static Texture2D texMeteorite2 = null;
        public static Texture2D texMyBullet1 = null;
        public static Texture2D texMyBullet2 = null;
        public static Texture2D texEnemyBullet = null;
        public static Texture2D texEnemyBullet2 = null;
        public static Texture2D texMyPlane1 = null;
        public static Texture2D texMyPlane2 = null;
        public static Texture2D texExplosion = null;
        public static Texture2D texShootExplosion = null;
        public static Texture2D texLoading = null;
        public static Texture2D texGameOverText = null;
        public static Texture2D texGameEndBack = null;
        public static Texture2D texGetReadyText = null;
        public static Texture2D texHelpScreen = null;
        public static Texture2D texHelpScreenKeys = null;
        public static Texture2D texLevel1Text = null;
        public static Texture2D texLevel2Text = null;
        public static Texture2D texLevel3Text = null;
        public static Texture2D texPauseBack = null;
        public static Texture2D texScoreText = null;
        public static Texture2D texShield = null;
        public static Texture2D texSplashBack = null;
        public static Texture2D texSplashTitle= null;
        public static Texture2D texTransition = null;
        public static Texture2D texUpdateBullet = null;
        public static Texture2D texxSign = null;
        public static Texture2D texEnemy1 = null;
        public static Texture2D texEnemy2 = null;
        public static Texture2D texEnemy3 = null;
        public static Texture2D texBoss1 = null;
        public static Texture2D texBoss2 = null;
        public static Texture2D texBoss3 = null;
        public static Texture2D texSplashScrollText = null;
        public static Texture2D texSplashBack1 = null;
        public static string shotpoint;
        public static string endGame = "Game Over, Ending...";

        public static Random rnd = new Random();

        public static Vector2[] framesequence = new Vector2[1];

        public static SpriteFont font1 = null;  
        public static SpriteFont font2 = null;
        public static SpriteFont font3 = null;  
        public static SpriteFont font4 = null;

        static public SoundEffect boomSound;
        static public LimitSound limBoomSound;
        static public SoundEffect shootSound;
        static public LimitSound limShootSound;
        static public SoundEffect splashMusic;
        static public LimitSound limSplashMusic;
        static public SoundEffect upgradeSound;
        static public LimitSound limupgradeSound;
        public static void getTextures(GraphicsDevice graphicsDevice, ContentManager content)
        {
            dir = Util.findDirWithFile("back1.png");

            screenRec = new Rectangle(0, 0, 800, 1000);
            enemyOffRec = new Rectangle(0, 0, 900,1050);
            font1 = content.Load<SpriteFont>("font1_s24");
            font2 = content.Load<SpriteFont>("font2_s14");
            font3 = content.Load<SpriteFont>("font3_s36");
            font4 = content.Load<SpriteFont>("font4_s48");

            boomSound = content.Load<SoundEffect>("explosion");
            shootSound = content.Load<SoundEffect>("shoot");
            splashMusic = content.Load<SoundEffect>("splashMusic");
            upgradeSound = content.Load<SoundEffect>("upgrade");
            limBoomSound = new LimitSound(boomSound, 5);
            limShootSound = new LimitSound(shootSound, 3);
            limSplashMusic = new LimitSound(splashMusic, 1);
            limupgradeSound = new LimitSound(upgradeSound, 1);

            texBack1 = Util.texFromFile(graphicsDevice, dir + "back1.png");
            texBack2 = Util.texFromFile(graphicsDevice, dir + "back2.png");
            texBack3 = Util.texFromFile(graphicsDevice, dir + "back3.png");
            texBackMeteorite1 = Util.texFromFile(graphicsDevice, dir + "backMeteorite1.png");
            texBackMeteorite2 = Util.texFromFile(graphicsDevice, dir + "backMeteorite2.png");
            texMeteorite1 = Util.texFromFile(graphicsDevice, dir + "meteorite1.png");
            texMeteorite2 = Util.texFromFile(graphicsDevice, dir + "meteorite2.png");
            texMyBullet1 = Util.texFromFile(graphicsDevice, dir + "myBullet1.png");
            texMyBullet2 = Util.texFromFile(graphicsDevice, dir + "myBullet2.png");
            texEnemyBullet = Util.texFromFile(graphicsDevice, dir + "enemyBullet.png");
            texEnemyBullet2 = Util.texFromFile(graphicsDevice, dir + "enemyBullet2.png");
            texMyPlane1 = Util.texFromFile(graphicsDevice, dir + "myPlane1.png");
            texMyPlane2 = Util.texFromFile(graphicsDevice, dir + "myPlane2.png");
            texExplosion = Util.texFromFile(graphicsDevice, dir + "explosion.png");
            texShootExplosion = Util.texFromFile(graphicsDevice, dir + "shootExplosion.png");
            texLoading = Util.texFromFile(graphicsDevice, dir + "loading.png");
            texGameOverText = Util.texFromFile(graphicsDevice, dir + "gameOverText.png");
            texGetReadyText = Util.texFromFile(graphicsDevice, dir + "getReadyText.png");
            texHelpScreen = Util.texFromFile(graphicsDevice, dir + "helpScreen.png");
            texHelpScreenKeys = Util.texFromFile(graphicsDevice, dir + "helpScreenKeys.png");
            texLevel1Text = Util.texFromFile(graphicsDevice, dir + "level1Text.png");
            texLevel2Text = Util.texFromFile(graphicsDevice, dir + "level2Text.png");
            texLevel3Text = Util.texFromFile(graphicsDevice, dir + "level3Text.png");
            texPauseBack = Util.texFromFile(graphicsDevice, dir + "pauseBack.png");
            texScoreText = Util.texFromFile(graphicsDevice, dir + "scoreText.png");
            texShield = Util.texFromFile(graphicsDevice, dir + "shield.png");
            texSplashBack = Util.texFromFile(graphicsDevice, dir + "splashBack.jpg");
            texTransition = Util.texFromFile(graphicsDevice, dir + "transition.png");
            texUpdateBullet = Util.texFromFile(graphicsDevice, dir + "updateBullet.png");
            texxSign = Util.texFromFile(graphicsDevice, dir + "xSign.png");
            texEnemy1 = Util.texFromFile(graphicsDevice, dir + "enemy1.png");
            texEnemy2 = Util.texFromFile(graphicsDevice, dir + "enemy2.png");
            texEnemy3 = Util.texFromFile(graphicsDevice, dir + "enemy3.png");
            texBoss1 = Util.texFromFile(graphicsDevice, dir + "boss1.png");
            texBoss2 = Util.texFromFile(graphicsDevice, dir + "boss2.png");
            texBoss3 = Util.texFromFile(graphicsDevice, dir + "boss3.png");
            texSplashTitle = Util.texFromFile(graphicsDevice, dir + "splashTitle.png"); 
            texSplashScrollText = Util.texFromFile(graphicsDevice, dir + "splashScrollText.png");
            texGameEndBack = Util.texFromFile(graphicsDevice, dir + "gameendback.png");
            texSplashBack1 = Util.texFromFile(graphicsDevice, dir + "splashback1.png");
        }
        public static void getKeyboardandMouseStates()
        {
            prevKeyState = keyState;
            keyState = Keyboard.GetState();
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            mouse_x = currentMouseState.X;
            mouse_y = currentMouseState.Y;
        }

        public static Sprite3 createExplosion(float x, float y, Texture2D texAnim, int xFrame, int yFrame, int width, int height, int lastFrame, int xOffset, int yOffset, int animState)
        {

            float scale = 1.0f;
            Sprite3 s = null;
            s = new Sprite3(true, texAnim, x - xOffset, y - yOffset);

            //s.setWidthHeightOfTex(width, height);
            s.setXframes(xFrame);
            s.setYframes(yFrame);
            s.setWidthHeight(width / xFrame * scale, height / yFrame * scale);//1024 / 7 * scale, 64 / 3 * scale
            s.setBB(0,0,width / xFrame * scale, height / yFrame * scale);

            Vector2[] anim = new Vector2[yFrame* xFrame];

            int z = 0;
           
                for (int i = 0; i < yFrame; i++)
                {
                    for (int j = 0; j < xFrame; j++)
                    {
                        anim[z].X = j;
                        anim[z].Y = i;
                    z++;
                    }
                }
            
            
            s.setAnimationSequence(anim, 0, lastFrame, 5);
            s.animationStart();
            s.setAnimFinished(animState);
            return s;
        }
    }
}
