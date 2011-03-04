using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RushHour {
    class PrevButton : Button {
        public PrevButton(ContentManager Manager) {
            LoadTexture(Manager, "Prev");
        }
    }
}
