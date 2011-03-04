using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RushHour {
    class Block1x2 : MovableBlock {
        public Block1x2(ContentManager Manager) {
            LoadTexture(Manager, "Block_1x2");
        }

        public override Movement AllowedMovement {
            get {
                return Movement.Vertical;
            }
        }
    }
}
