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
    class Pause : RC_GameStateParent
    {
        ColorField trans = null;
        ImageBackground pauseBack = null;
        TextRenderableFlash pause2 = null;
        public override void LoadContent()
        {
            pauseBack = new ImageBackground(Global.texPauseBack, null, new Rectangle(40, 350, 750, 200), Color.White);
            trans = new ColorField(new Color(255, 255, 255, 100), new Rectangle(0, 0, 800, 1000));
            pause2 = new TextRenderableFlash("Press 'R' to resume.", new Vector2(250, 410), Global.font3, Color.Red, 30);
        }

        public override void Update(GameTime gameTime)
        {
            Global.getKeyboardandMouseStates();
            if (Global.keyState.IsKeyDown(Keys.R) && Global.prevKeyState.IsKeyUp(Keys.R))
            {
                Global.gameStateManager.popLevel();
            }
            pause2.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Global.gameStateManager.prevStatePlayLevel.Draw(gameTime);//draws the currently set level that was not pushed to.
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            trans.Draw(spriteBatch);
            pauseBack.Draw(spriteBatch);
            pause2.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
