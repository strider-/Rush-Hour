using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RushHour {
    abstract class Button : Sprite {
        bool mouseDown, mouseUp;
        List<Keys> keys = new List<Keys>();
        KeyboardState prevKbdState;
        MouseState prevMouseState;
        
        public event EventHandler Clicked = delegate {
        };

        public void AddKeys(params Keys[] Keys) {
            keys.AddRange(Keys);
        }
        public void RemoveKey(Keys Key) {
            keys.Remove(Key);
        }

        public override void Update(GameTime gameTime, Rectangle bounds) {
            base.Update(gameTime, bounds);
            MouseState curMouseState = Mouse.GetState();
            getInput();

            if(Hovering) {
                this.color = Color.Lerp(Color.White, Color.AntiqueWhite, 1f);

                if(curMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                    mouseDown = true;
                mouseUp = curMouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed;

                if(mouseDown) {
                    this.color = Color.Lerp(Color.White, Color.SteelBlue, .5f);
                }

                if(mouseDown && mouseUp) {
                    mouseDown = false;
                    Clicked(this, EventArgs.Empty);
                }

                prevMouseState = curMouseState;
            } else {
                mouseDown = false;
                mouseUp = false;
                this.color = Color.White;
            }
        }

        void getInput() {
            KeyboardState state = Keyboard.GetState();
            foreach(Keys k in keys)
                if(state.IsKeyDown(k) && !prevKbdState.IsKeyDown(k))
                    Clicked(this, EventArgs.Empty);
            prevKbdState = state;
        }
    }
}
