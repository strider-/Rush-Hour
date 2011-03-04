using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RushHour {
    class Board : Sprite {
        const int BLOCK_SIZE = 64;
        const int GRID_SIZE = 6;

        Rectangle gridNode = new Rectangle(0, 0, BLOCK_SIZE, BLOCK_SIZE);
        List<MovableBlock> blocks;
        MovableBlock[,] grid = new MovableBlock[GRID_SIZE, GRID_SIZE];
        Texture2D pauseScreen;

        public Board(ContentManager Manager, Rectangle GameBounds) {        
            LoadTexture(Manager, "Board");

            int x = (GameBounds.Width / 2) - (Texture.Width / 2);
            int y = (GameBounds.Height / 2) - (Texture.Height / 2) - 25;

            Location = new Vector2(x, y);
            Bounds = new Rectangle(x + 3, y + 3, (BLOCK_SIZE * GRID_SIZE), (BLOCK_SIZE * GRID_SIZE));
            blocks = new List<MovableBlock>();
            pauseScreen = Manager.Load<Texture2D>("Paused");
        }

        public void AddPlayer(Player Player) {
            AddObstacle(Player, new Point(1, 2));
        }

        public void AddObstacle(MovableBlock Block, Point GridLocation) {
            blocks.Add(Block);
            Block.Board = this;
            Block.Location = new Vector2(Bounds.X + (BLOCK_SIZE * GridLocation.X), Bounds.Y + (BLOCK_SIZE * GridLocation.Y));
        }
        public override void Draw(SpriteBatch Batch) {
            if(!Paused) {
                base.Draw(Batch);

                foreach(MovableBlock mb in blocks) {
                    mb.Draw(Batch);
                }
            } else {
                Batch.Draw(pauseScreen, Location, Color.White);
            }
        }
        public override void Update(GameTime gameTime, Rectangle bounds) {
            if(!Paused) {
                foreach(MovableBlock mb in blocks) {
                    mb.Update(gameTime, this.Bounds);
                }
            }
            
            updateGrid();
            base.Update(gameTime, bounds);
        }
        void updateGrid() {
            for(int i = 0; i < GRID_SIZE; i++) {
                for(int j = 0; j < GRID_SIZE; j++) {
                    Rectangle gridNode = new Rectangle((j * BLOCK_SIZE) + Bounds.X, (i * BLOCK_SIZE) + Bounds.Y, BLOCK_SIZE, BLOCK_SIZE);
                    grid[j, i] = blocks.FirstOrDefault(b => gridNode.Intersects(b.Bounds));
                }
            }
        }
        public List<MovableBlock> Blocks {
            get {
                return blocks;
            }
        }
        public bool Paused {
            get;
            set;
        }
    }
}
