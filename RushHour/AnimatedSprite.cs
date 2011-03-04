using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RushHour {
    abstract class AnimatedSprite : Sprite {
        int timeSinceLastFrame;
        Point currentFrame;

        public AnimatedSprite(Point FrameSize, Point SheetSize) {
            this.FrameSize = FrameSize;
            this.SheetSize = SheetSize;
            this.Speed = 16;
        }

        public override void Update(GameTime gameTime, Rectangle bounds) {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if(timeSinceLastFrame > Speed) {
                timeSinceLastFrame = 0;
                currentFrame.X++;
                if(currentFrame.X >= SheetSize.X) {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                    if(currentFrame.Y >= SheetSize.Y)
                        currentFrame.Y = 0;
                }
            }

            base.Update(gameTime, bounds);
        }

        public override void Draw(SpriteBatch Batch) {
            Batch.Draw(Texture, Location,
                new Rectangle(
                    currentFrame.X * FrameSize.X,
                    currentFrame.Y * FrameSize.Y,
                    FrameSize.X,
                    FrameSize.Y),
                Color.White);
        }

        public int Speed {
            get;
            set;
        }

        public Point FrameSize {
            get;
            private set;
        }

        public Point SheetSize {
            get;
            private set;
        }
    }
}
