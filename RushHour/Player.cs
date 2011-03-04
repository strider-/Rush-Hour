using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RushHour {
    class Player : MovableBlock {
        public Player(ContentManager Manager) {
            LoadTexture(Manager, "Player");
        }

        public override void Update(GameTime gameTime, Rectangle bounds) {
            base.Update(gameTime, bounds);
            LevelComplete = Location.X >= (bounds.Width + bounds.X) - (Texture.Width / 2);
        }

        public override Movement AllowedMovement {
            get {
                return Movement.Horizontal;
            }
        }

        public override Color DragColor {
            get {
                return Color.Gold;
            }
        }

        public bool LevelComplete {
            get;
            private set;
        }
    }
}
