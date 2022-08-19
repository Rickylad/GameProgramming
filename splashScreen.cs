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
    class SplashScreen : RC_GameStateParent
    {
        
        ImageBackground back = null;
        ImageBackground back1 = null;
        ImageBackground title = null;
        Sprite3 scrollText = null;
        TextRenderableFlash splashScreenText = null;
        public override void LoadContent()
        {
            Global.getTextures(graphicsDevice, Content);
            splashScreenText = new TextRenderableFlash("Press 'Enter' to start", new Vector2(180, 600), Global.font1, Color.Red, 30);
            back1 = new ImageBackground(Global.texSplashBack1, null, new Rectangle(0, 0, 800, 690), Color.White);
            title = new ImageBackground(Global.texSplashTitle, null, new Rectangle(80, -50, 600, 400), Color.White);
            back = new ImageBackground(Global.texSplashBack, Color.White, graphicsDevice);
            scrollText = new Sprite3(true, Global.texSplashScrollText, 50, 1000);
            //scrollText.setDeltaSpeed(new Vector2(-1, 0));
            scrollText.setWidthHeight(700,800);
            scrollText.setAnimationSequence(new Vector2[1], 0, 0, 0);
            scrollText.setAnimFinished(1);
            scrollText.animationStart();
            scrollText.setMoveAngleDegrees(-90);
            scrollText.setMoveSpeed(0.3f);
        }

        public override void Update(GameTime gameTime)
        {
            Global.getKeyboardandMouseStates();
            Global.limSplashMusic.playSoundIfOk();
            if (Global.keyState.IsKeyDown(Keys.Enter) && Global.prevKeyState.IsKeyUp(Keys.Enter))
            {
                Global.gameStateManager.setLevel(3);
                Global.splashMusic.Dispose();
            }
            splashScreenText.Update(gameTime);
            scrollText.moveByAngleSpeed();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            back.Draw(spriteBatch);
            title.Draw(spriteBatch); 
            scrollText.Draw(spriteBatch);
            back1.Draw(spriteBatch);
            splashScreenText.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
