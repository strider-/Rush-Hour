using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RushHour {
    abstract class Sprite {
        Texture2D t;
        Vector2 position;
        protected Color color = Color.White;

        protected void LoadTexture(ContentManager Manager, string AssetName) {
            t = Manager.Load<Texture2D>(AssetName);
            GridSize = new Vector2(t.Width / 64, t.Height / 64);
        }

        public virtual void Draw(SpriteBatch Batch) {
            Batch.Draw(t, Location, Color);
        }

        public virtual void Update(GameTime gameTime, Rectangle bounds) {
            MouseState curMouseState = Mouse.GetState();
            Hovering = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height)
                .Intersects(new Rectangle(curMouseState.X, curMouseState.Y, 1, 1));
        }

        public Vector2 Location {
            get {
                return position;
            }
            set {
                position = value;
                Bounds = new Rectangle((int)position.X, (int)position.Y, t.Width, t.Height);
            }
        }

        public Rectangle Bounds {
            get;
            protected set;
        }

        public Texture2D Texture {
            get {
                return t;
            }
        }

        public bool Hovering {
            get;
            protected set;
        }

        public Color Color {
            get {
                return color;
            }
        }

        public Vector2 GridSize {
            get;
            set;
        }
    }
}
