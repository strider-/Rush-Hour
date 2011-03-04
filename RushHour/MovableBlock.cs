using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RushHour {
    abstract class MovableBlock : Sprite {
        int offSet = 0;
        bool collided = false;
        float fadeInterval = 0.02f, fade = 1;
        Vector2 startPos;        

        public enum Movement {
            Horizontal,
            Vertical
        };

        MouseState prevMouseState;

        public override void Update(GameTime gameTime, Rectangle bounds) {
            base.Update(gameTime, bounds);
                        
            MouseState curMouseState = Mouse.GetState();
            Vector2 position = Location;
            GridLocation = new Point((int)(Location.X - Board.Bounds.X) / 64, (int)(Location.Y - Board.Bounds.Y) / 64);

            if(curMouseState.LeftButton == ButtonState.Pressed && ActionBlock == null || ActionBlock == this) {
                if(!Hovering && offSet == 0) {
                    return;
                }

                ActionBlock = this;
                color = DragColor;
                if(startPos == Vector2.Zero)
                    startPos = Location;

                if(AllowedMovement == Movement.Horizontal && curMouseState.X != prevMouseState.X) {
                    if(offSet <= 0)
                        offSet = curMouseState.X - (int)position.X;
                    position = new Vector2(curMouseState.X - offSet, position.Y);                    
                }
                if(AllowedMovement == Movement.Vertical && curMouseState.Y != prevMouseState.Y) {
                    if(offSet <= 0)
                        offSet = curMouseState.Y - (int)position.Y;
                    position = new Vector2(position.X, curMouseState.Y - offSet);
                }

                prevMouseState = curMouseState;

                if(position.X < bounds.X)
                    position.X = bounds.X;
                if(position.Y < bounds.Y)
                    position.Y = bounds.Y;
                if(this is Player) { // allow the player to escape the board
                    if(position.X + (Texture.Width / 2) > bounds.Width + bounds.X)
                        position.X = (bounds.Width + bounds.X) - (Texture.Width / 2);
                } else {
                    if(position.X + Texture.Width > bounds.Width + bounds.X)
                        position.X = (bounds.Width + bounds.X) - Texture.Width;
                }
                if(position.Y + Texture.Height > bounds.Height + bounds.Y)
                    position.Y = (bounds.Height + bounds.Y) - Texture.Height;

                Rectangle pos = new Rectangle((int)position.X + 5, (int)position.Y + 5, Texture.Width - 10, Texture.Height - 10);
                if(Board.Blocks.Any(b => b.Bounds.Intersects(pos) && b != this))
                    collided = true;
                else
                    if(!collided || Hovering) {
                        Location = position;                        
                    }

            } else if(curMouseState.LeftButton == ButtonState.Released) {
                fade = 1;
                offSet = 0;
                color = Color.White;
                ActionBlock = null;
                collided = false;

                if(startPos != Vector2.Zero && startPos != Location)
                    MoveCount++;
                startPos = Vector2.Zero;
            }            
        }
        public override void Draw(SpriteBatch Batch) {
            fade += fadeInterval;
            if(fade <= 0 || fade >= 1)
                fadeInterval *= -1;
            Batch.Draw(Texture, Location, Color.Lerp(Color, Color.White, fade));
        }

        public abstract Movement AllowedMovement {
            get;
        }

        public virtual Color DragColor {
            get {
                return Color.Crimson;
            }
        }
        public bool Collided {
            get {
                return collided;
            }
        }
        public Board Board {
            get;
            set;
        }
        public int MoveCount {
            get;
            private set;
        }
        public Point GridLocation {
            get;
            private set;
        }

        public static MovableBlock ActionBlock {
            get;
            private set;
        }
    }
}
