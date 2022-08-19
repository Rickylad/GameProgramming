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
using System.Reflection;

namespace Assignment
{
    class EndGame : RC_GameStateParent
    {
        ImageBackground gameEnd = null;
        ImageBackground gameOverText = null;
        ImageBackground gameOverScoreText = null;

        public override void LoadContent()
        {
            Global.getTextures(graphicsDevice, Content);
            gameOverText = new ImageBackground(Global.texGameOverText, null, new Rectangle(100, 300, 600, 200), Color.White);
            gameEnd = new ImageBackground(Global.texGameEndBack, Color.White, graphicsDevice);
            gameOverScoreText = new ImageBackground(Global.texScoreText, null, new Rectangle(120, 520, 200, 50), Color.White);

        }

        public override void Update(GameTime gameTime)
        {
            //score
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            gameEnd.Draw(spriteBatch);
            gameOverText.Draw(spriteBatch);
            gameOverScoreText.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
