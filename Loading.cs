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
    class Loading : RC_GameStateParent
    {
        SpriteList loading = null;
        //ImageBackground back = null;
        int timer = 300;

        public override void LoadContent()
        {
            loading = new SpriteList();
            Global.getTextures(graphicsDevice, Content);
            //back = new ImageBackground(Global.texSplashBack, Color.White, graphicsDevice);
            loading.addSpriteReuse(Global.createExplosion(200f, 450f, Global.texLoading, 2, 8, 708, 776, 15, 0, 0, 0));
        }

        public override void Update(GameTime gameTime)
        {
            timer--;
            if(timer <= 0)
            {
                Global.gameStateManager.setLevel(5);
            }
            
            loading.animationTick(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            //back.Draw(spriteBatch);
            //loading.drawInfo(spriteBatch, Color.White, Color.Red);
            loading.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
