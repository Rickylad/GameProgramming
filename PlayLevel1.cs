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
    class PlayLevel1 : RC_GameStateParent
    {
        Sprite3 myPlane = null;
        Sprite3 level1GetReady = null;
        Sprite3 enemy1 = null;
        Sprite3 enemy2 = null;
        Sprite3 enemy3 = null;
        Sprite3 enemyBullet = null;
        Sprite3 boss = null;
        Sprite3 myBullet = null;
        Sprite3 myBullet2 = null;
        Sprite3 upgradeBullet = null;
        SpriteList enemyList1 = null;
        SpriteList enemyList2 = null;
        SpriteList bullets = null;
        SpriteList bullets2 = null;
        SpriteList booms1 = null;
        SpriteList enemyBullets = null;

        ImageBackground level1Back = null;
        ImageBackground level1ScoreText = null;
        ImageBackground level1PlaneBack = null;
        ImageBackground xSign = null;

        /*TextRenderableFlash level1GetReadyCounter = null*/

        int timerStart = 400;
        int timerEnemy1 = 180;
        int score = 0;
        int enemyCount = 20;
        int totalEnemy = 19;
        int myPlaneCounter = 5;
        float angle = 0.1f;
        int random = 0;
        float startPoint = 180.0f;
        float startPoint2 = 180.0f;
        int randomX = 0;
        WayPointList wl_enemy = null;
        WayPointList wl_enemy2 = null;
        //bool check1 = true;
        bool checkRight = false;
        bool checkLeft = false;
        bool checkUpgrade = false;
        public override void LoadContent()
        {
            Global.getTextures(graphicsDevice, Content);

            //level1GetReadyCounter = new TextRenderableFlash((timerStart * 0.01).ToString(), new Vector2(350, 830), Global.font1, Color.White, 10);
            level1Back = new ImageBackground(Global.texBack1, Color.White, graphicsDevice);
            level1ScoreText = new ImageBackground(Global.texScoreText, null, new Rectangle(550, 20, 100, 40), Color.White);
            level1PlaneBack = new ImageBackground(Global.texMyPlane1, null, new Rectangle(10, 10, 100, 80), Color.White);
            xSign = new ImageBackground(Global.texxSign, null, new Rectangle(110, 30, 50, 40), Color.White);

            level1GetReady = new Sprite3(true, Global.texGetReadyText, 270, 500);
            level1GetReady.setWidthHeight(250, 100);

            myPlane = new Sprite3(true, Global.texMyPlane1, 348, 880);
            //myPlane.setHSoffset(new Vector2(myPlane.getWidth() / 2, myPlane.getHeight() / 2));

            upgradeBullet = new Sprite3(true, Global.texUpdateBullet, -20, -20);
            upgradeBullet.setWidthHeight(50,50);
            upgradeBullet.setActiveAndVisible(false);

            enemy3 = new Sprite3(true, Global.texEnemy2, 200, -300);
            enemy3.hitPoints = 3;

            


            enemyList1 = new SpriteList();
            wl_enemy = new WayPointList();
            enemyList2 = new SpriteList();
            wl_enemy2 = new WayPointList();  
            bullets = new SpriteList();
            bullets2 = new SpriteList();
            booms1 = new SpriteList();
            enemyBullets = new SpriteList();

        }

        public override void Update(GameTime gameTime)
        {
            Global.getKeyboardandMouseStates();
            
            if (Global.keyState.IsKeyDown(Keys.P) && !Global.prevKeyState.IsKeyDown(Keys.P))
            {
                Global.gameStateManager.pushLevel(1);
            }
            if (Global.keyState.IsKeyDown(Keys.F1) && !Global.prevKeyState.IsKeyDown(Keys.F1))
            {
                Global.gameStateManager.pushLevel(4);
            }
            timerStart--;

            //level1GetReadyCounter.Update(gameTime);
            if (timerStart <= 100)
            {
                enemyList1.moveVisibleWayPoints();
                enemyList2.moveVisibleWayPoints();
                level1GetReady.setActiveAndVisible(false);
                //level1GetReadyCounter.setVisible(false);
                //enemyList1.moveDeltaXY();

                timerEnemy1--;
                if (timerEnemy1 <= 0)
                {
                    if (enemyCount > 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            enemy1 = new Sprite3(true, Global.texEnemy1, 20, 20);
                            wl_enemy.makePathCircle(new Vector2(0, -80), 380, startPoint, Util.degToRad(5), 45, 2, 1);
                            //enemy1.setDeltaSpeed(new Vector2(2,1));
                            enemy1.setWidthHeight(80, 100);
                            enemy1.setBB(50, 0, 160, 250);
                            enemy1.setHSoffset(new Vector2(125, 120));
                            enemy1.wayList = wl_enemy;
                            enemy1.hitPoints = 1;
                            enemy1.moveToStartOfWayPoints();
                            enemyList1.addSpriteReuse(enemy1);
                            startPoint += 0.2f;

                        }
                        enemyCount = enemyCount - 5;
                    }

                    if (enemyCount > 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            enemy2 = new Sprite3(true, Global.texEnemy1, 20, 20);
                            wl_enemy2.makePathCircle(new Vector2(800, -80), 380, startPoint2, Util.degToRad(5), 70, 2, 1);
                            //enemy1.setDeltaSpeed(new Vector2(2,1));
                            enemy2.setWidthHeight(80, 100);
                            enemy2.setBB(50, 0, 160, 250);
                            enemy2.hitPoints = 1;
                            enemy2.setHSoffset(new Vector2(125, 120));
                            enemy2.wayList = wl_enemy2;
                            enemy2.moveToStartOfWayPoints();
                            enemyList2.addSpriteReuse(enemy2);
                            startPoint2 += 0.2f;
                        }
                        enemyCount = enemyCount - 5;
                    }
                }
                for(int i =0; i < enemyList1.count(); i++)
                {
                    Sprite3 s = enemyList1.getSprite(i);
                    if (s == null) continue;
                    if (!s.active) continue;
                    if (!s.visible) continue;
                    int collision = bullets.collisionAA(s);
                    if(collision != -1)
                    {
                        s.setActiveAndVisible(false);
                        bullets.getSprite(collision).setActiveAndVisible(false);
                        totalEnemy--;
                        score += 100;
                        booms1.addSpriteReuse(Global.createExplosion(s.getPosX(), s.getPosY(), Global.texExplosion, 4, 4, 256, 256, 15, 40, 40, 2));
                        Global.limBoomSound.playSoundIfOk();
                    }
                    if (totalEnemy < 0)
                    {
                        upgradeBullet.setActiveAndVisible(true);
                        upgradeBullet.setPos(s.getPosX(), s.getPosY());
                        upgradeBullet.setDeltaSpeed(new Vector2(-1, 1));
                    }
                }

                for (int i = 0; i < enemyList2.count(); i++)
                {
                    Sprite3 s = enemyList2.getSprite(i);
                    if (s == null) continue;
                    if (!s.active) continue;
                    if (!s.visible) continue;
                    int collision = bullets.collisionAA(s);
                    if (collision != -1)
                    {
                        s.setActiveAndVisible(false);
                        bullets.getSprite(collision).setActiveAndVisible(false);
                        totalEnemy--;
                        score += 100;
                        booms1.addSpriteReuse(Global.createExplosion(s.getPosX(), s.getPosY(), Global.texExplosion, 4, 4, 256, 256, 15, 40, 40, 2));
                        Global.limBoomSound.playSoundIfOk();
                        
                    }
                    if (totalEnemy < 0)
                    {
                        upgradeBullet.setActiveAndVisible(true);
                        upgradeBullet.setPos(s.getPosX()-20, s.getPosY());
                        upgradeBullet.setDeltaSpeed(new Vector2(-3, 3));
                    }
                }

            }
            upgradeBullet.savePosition();
            upgradeBullet.moveByDeltaXY();
            Rectangle upgradeBulletbb = upgradeBullet.getBoundingBoxAA();

            if (upgradeBulletbb.X < 0)
            {
                upgradeBullet.setDeltaSpeed(upgradeBullet.getDeltaSpeed() * new Vector2(-1, 1));
            }
            if (upgradeBulletbb.Y + upgradeBulletbb.Height > 1000)
            {
                upgradeBullet.setDeltaSpeed(upgradeBullet.getDeltaSpeed() * new Vector2(1, -1));

            }
            if (upgradeBulletbb.X + upgradeBulletbb.Width > 800)
            {
                upgradeBullet.setDeltaSpeed(upgradeBullet.getDeltaSpeed() * new Vector2(-1, 1));

            }
            if (upgradeBulletbb.Y < 0)
            {
                upgradeBullet.setDeltaSpeed(upgradeBullet.getDeltaSpeed() * new Vector2(1, -1));

            }
            if(upgradeBullet.collision(myPlane))
            {
                upgradeBullet.savePosition();
                upgradeBullet.setBB(0,0,0,0);
                upgradeBullet.setDeltaSpeed(upgradeBullet.getDeltaSpeed() * new Vector2(0,0));
                upgradeBullet.visible = false;
                upgradeBullet.active = false;
                myPlane.setTexture(Global.texMyPlane2, true);
                checkUpgrade = true;
                Global.limupgradeSound.playSoundIfOk();
            }
            
            booms1.animationTick(gameTime);
            int enemybulletTimer = 100;
            if (totalEnemy < 0) // if there is no enemy one
            {
                enemy3.setMoveAngleDegrees(90);
                enemy3.setMoveSpeed(1);
                enemy3.savePosition();
                enemy3.moveByAngleSpeed();
                enemybulletTimer--;
                if(enemybulletTimer < 0)
                {
                    addToBulletList(enemy3.getPosX(), enemy3.getPosY(), Global.texEnemyBullet, enemyBullets, 0, 5);

                }
                
                enemybulletTimer = 100;
                Rectangle enemy3bb = enemy3.getBoundingBoxAA();

                if (enemy3bb.Y > 300)
                {
                    enemy3.setMoveSpeed(0);

                }
                if (enemy3bb.X + enemy3.getWidth() > 800)
                {
                    enemy3.setMoveAngleDegrees(180);
                    
                }
                if (enemy3bb.X < 0)
                {
                    enemy3.setMoveAngleDegrees(0);
                    
                }

            }
            

            

            if (myPlane.getPosX() + myPlane.getWidth() < Global.screenRec.Width)
            {
                if (Global.keyState.IsKeyDown(Keys.D))
                {
                    myPlane.setPosX(myPlane.getPosX() + 5);
                }
            }

            if (myPlane.getPosX() > 0)
            {
                if (Global.keyState.IsKeyDown(Keys.A))
                {
                    myPlane.setPosX(myPlane.getPosX() - 5);
                }
            }
            if (myPlane.getPosY() > 500)
            {
                if (Global.keyState.IsKeyDown(Keys.W))
                {
                    myPlane.setPosY(myPlane.getPosY() - 5);
                }
            }
            if (myPlane.getPosY() + myPlane.getHeight() < Global.screenRec.Height)
            {
                if (Global.keyState.IsKeyDown(Keys.S))
                {
                    myPlane.setPosY(myPlane.getPosY() + 5);
                }
            }

            if (Global.keyState.IsKeyDown(Keys.Space) && Global.prevKeyState.IsKeyUp(Keys.Space))
            {
                addToBulletList(myPlane.getPosX()+ (myPlane.getWidth() / 2) - 4, myPlane.getPosY() + (myPlane.getHeight() / 2), Global.texMyBullet1,bullets, 0, -10);
                Global.limShootSound.playSoundIfOk();
                if(checkUpgrade)
                {
                    addToBulletList(myPlane.getPosX() + (myPlane.getWidth() / 2) - 8, myPlane.getPosY() + (myPlane.getHeight() / 2), Global.texMyBullet2, bullets2, -1, -10);
                    addToBulletList(myPlane.getPosX() + (myPlane.getWidth() / 2), myPlane.getPosY() + (myPlane.getHeight() / 2), Global.texMyBullet2, bullets2, 1, -10);
                }
            }

            // set bullet to not active to not be able to damage the enemy off screen
            for(int x=0; x<bullets.count(); x++)
            {
                if (bullets.getSprite(x).getPosY() < 0)
                {
                    bullets.getSprite(x).setActiveAndVisible(false);
                }
            }

            if (checkUpgrade)
            {
                for (int x = 0; x < bullets2.count(); x++)
                {
                    if (bullets2.getSprite(x).getPosY() < 0)
                    {
                        bullets2.getSprite(x).setActiveAndVisible(false);
                    }
                }
            }

            bullets.moveDeltaXY();
            bullets2.moveDeltaXY();
            enemyBullets.moveDeltaXY();
        }



    

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            level1Back.Draw(spriteBatch);
            enemyList1.Draw(spriteBatch);
            enemyList2.Draw(spriteBatch);
            enemy3.Draw(spriteBatch);
            enemyBullets.Draw(spriteBatch);
            bullets.Draw(spriteBatch);
            bullets2.Draw(spriteBatch);
            booms1.Draw(spriteBatch);
            level1ScoreText.Draw(spriteBatch);
            level1PlaneBack.Draw(spriteBatch);
            myPlane.Draw(spriteBatch);
            level1GetReady.Draw(spriteBatch);
            upgradeBullet.Draw(spriteBatch);
            xSign.Draw(spriteBatch);
            
            spriteBatch.DrawString(Global.font3, "" + myPlaneCounter, new Vector2(160,20), Color.White);
            spriteBatch.DrawString(Global.font1, "" + score, new Vector2(700, 20), Color.White);
            if (timerStart >= 100)
            {
                //level1GetReadyCounter.Draw(spriteBatch);
                
                spriteBatch.DrawString(Global.font1, ""+(int)(timerStart*0.01), new Vector2(390, 830), Color.White);
            }
            if (Game1.showbb)
            {
                myPlane.drawInfo(spriteBatch, Color.White, Color.Yellow);
                enemyList1.drawInfo(spriteBatch, Color.White, Color.Yellow);
                enemyList2.drawInfo(spriteBatch, Color.White, Color.Yellow);
                bullets.drawInfo(spriteBatch, Color.White, Color.Yellow);
                enemy3.drawInfo(spriteBatch, Color.White, Color.Yellow);
                bullets2.drawInfo(spriteBatch, Color.White, Color.Yellow);
                upgradeBullet.drawInfo(spriteBatch, Color.White, Color.Yellow);
            }

            spriteBatch.End();
        }

        public static void addToList(Sprite3 s, SpriteList sl, Texture2D tex, int x, int y, int hitPoint, int width, int height, float speedX, float speedY)
        {
            s = new Sprite3(true, tex, x, y);
            s.hitPoints = hitPoint;
            s.setWidthHeight(width, height);
            //s.setPos(-200, Global.rnd.Next(70, 100));
            s.setDeltaSpeed(new Vector2(speedX, speedY));
            sl.addSpriteReuse(s);
        }

        public static void addToBulletList(float posX, float posY, Texture2D tex, SpriteList sl, int speedX, int speedY)
        {
            Sprite3 s = new Sprite3(true, tex, posX, posY);
            s.setWidthHeight(10, 30);
            s.setHSoffset(new Vector2(s.getWidth() / 2, s.getHeight() / 2));
            s.setDeltaSpeed(new Vector2(speedX, speedY));
            sl.addSpriteReuse(s);
        }
    }
}
