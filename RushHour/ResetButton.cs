using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RushHour {
    class ResetButton : Button {
        public ResetButton(ContentManager Manager) {
            LoadTexture(Manager, "Reset");
        }
    }
}
