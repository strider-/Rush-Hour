using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RushHour {
    class Block3x1 : MovableBlock {
        public Block3x1(ContentManager Manager) {
            LoadTexture(Manager, "Block_3x1");
        }

        public override Movement AllowedMovement {
            get {
                return Movement.Horizontal;
            }
        }
    }
}
