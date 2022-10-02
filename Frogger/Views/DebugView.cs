using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Frogger.Views
{
    internal class DebugView : BaseView
    {
        readonly struct Rect
        {
            public Rectangle Box { get; }
            public Color RectColor { get; }

            public Rect(Rectangle box, Color color) => (Box, RectColor) = (box, color);
        }

        private readonly Dictionary<string, Rect> Rectangles = new();
        private readonly Texture2D RectTexture;

        public DebugView(ContentManager contentManager, SpriteBatch spriteBatch) : base(contentManager, spriteBatch)
        {
            RectTexture = new Texture2D(Sprites.GraphicsDevice, 1, 1);
            RectTexture.SetData(new[] { Color.White });
        }

        public void AddRect(string name, Rectangle rect, Color color)
        {
            if (Rectangles.ContainsKey(name))
            {
                throw new Exception($"Rect with name {name} already exists!");
            }

            Rect r = new(rect, color);
            Rectangles.Add(name, r);
        }

        public override void Draw()
        {
            foreach (var rect in Rectangles)
            {
                Sprites.Draw(RectTexture, rect.Value.Box, rect.Value.RectColor);
            }
        }
    }
}
