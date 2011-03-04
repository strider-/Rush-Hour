using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace RushHour {
    public class GameLevel  {
        Rectangle gameBounds;
        Board board;
        Player player;
        KeyboardState prevKbdState;
        SpriteFont font;

        GameLevel(Game Game) {
            gameBounds = Game.Window.ClientBounds;

            board = new Board(Game.Content, gameBounds);
            player = new Player(Game.Content);
            font = Game.Content.Load<SpriteFont>("LevelAuthor");

            board.AddPlayer(player);
        }

        public static GameLevel Load(Game Game, XDocument Level) {
            try {
                GameLevel l = new GameLevel(Game);
                Assembly asm = Assembly.GetExecutingAssembly();

                XElement info = Level.Root.Element("Level").Element("Info");
                var obstacles = from o in Level.Root.Element("Level").Elements("Obstacle")
                                let type = asm.GetTypes().Where(t => t.FullName.ToLower().EndsWith("." + o.Element("Type").Value.ToLower())).FirstOrDefault()
                                where type != null
                                select new {
                                    Block = (MovableBlock)asm.CreateInstance(
                                        type.FullName, true, BindingFlags.CreateInstance, null, new object[] { Game.Content }, null, null
                                    ),
                                    Location = new Point(int.Parse(o.Element("X").Value), int.Parse(o.Element("Y").Value))
                                };

                l.Name = info.Element("Name").Value;
                l.Author = info.Element("Author").Value;
                l.Description = info.Element("Description").Value;

                foreach(var o in obstacles)
                    l.board.AddObstacle(o.Block, o.Location);

                return l;
            } catch {
                // Well we got an invalid level file or something.  Fail silently
                return null;
            }            
        }        
        public void Draw(SpriteBatch batch) {
            board.Draw(batch);

            if(Paused) {
                string desc = getWordWrappedDescription();
                Vector2 descLen = font.MeasureString(desc);
                Vector2 descCenter = new Vector2(batch.GraphicsDevice.Viewport.Width / 2, 350f);

                batch.DrawString(font, desc, descCenter - (descLen / 2), Color.White);
            }
        }
        public void Update(GameTime gameTime) {
            KeyboardState curKbdState = Keyboard.GetState();
            if(curKbdState.IsKeyDown(Keys.P) && !prevKbdState.IsKeyDown(Keys.P))
                Paused = !Paused;

            prevKbdState = curKbdState;
            board.Paused = Paused;
            board.Update(gameTime, gameBounds);

            if(!Paused)
                ElapsedTime += gameTime.ElapsedGameTime;
        }

        string getWordWrappedDescription() {
            const int BREAK_AT = 50;
            string desc = string.Empty;

            if(Description.Length <= BREAK_AT)
                desc = Description;
            else {
                for(int i = 0; i < Description.Length; i += BREAK_AT) {
                    string subDesc = Description.Substring(i, Math.Min(BREAK_AT, Description.Length - i));
                    if(subDesc.Length == BREAK_AT) {
                        int idxSpace = subDesc.LastIndexOf(" ");
                        if(idxSpace > 0)
                            desc += subDesc.Remove(idxSpace, 1).Insert(idxSpace, "\r\n");
                    } else
                        desc += subDesc;
                }
            }

            return desc;
        }

        public string Name {
            get;
            private set;
        }
        public string Author {
            get;
            private set;
        }
        public string Description {
            get;
            private set;
        }
        public TimeSpan ElapsedTime {
            get;
            private set;
        }
        public Rectangle BoardBounds {
            get {
                return board.Bounds;
            }
        }
        public int TotalMoves {
            get {
                return board.Blocks.Sum(b => b.MoveCount);
            }
        }
        public bool Paused {
            get;
            set;
        }

        public bool LevelComplete {
            get {
                return player.LevelComplete;
            }
        }
    }
}
