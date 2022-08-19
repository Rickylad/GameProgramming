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
    class HelpScreen : RC_GameStateParent
    {
        ColorField trans = null;
        ImageBackground helpBack = null;
        ImageBackground helpKeys = null;
        TextRenderableFlash helpText = null;
        public override void LoadContent()
        {
            helpBack = new ImageBackground(Global.texHelpScreen, null, new Rectangle(10, 200, 800, 550), Color.White);
            helpKeys = new ImageBackground(Global.texHelpScreenKeys, null, new Rectangle(40, 310, 750, 400), Color.White);
            trans = new ColorField(new Color(255, 255, 255, 100), new Rectangle(0, 0, 800, 1000));
            helpText = new TextRenderableFlash("Press 'R' to resume.", new Vector2(150, 750), Global.font3, Color.Red, 30);
        }

        public override void Update(GameTime gameTime)
        {
            Global.getKeyboardandMouseStates();
            if (Global.keyState.IsKeyDown(Keys.R) && Global.prevKeyState.IsKeyUp(Keys.R))
            {
                Global.gameStateManager.popLevel();
            }
            helpText.Update(gameTime);
            
        }

        public override void Draw(GameTime gameTime)
        {
            Global.gameStateManager.prevStatePlayLevel.Draw(gameTime);//draws the currently set level that was not pushed to.
            
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            trans.Draw(spriteBatch);
            helpBack.Draw(spriteBatch);
            helpKeys.Draw(spriteBatch);
            helpText.Draw(spriteBatch);
            spriteBatch.End();
        }

    }
}
