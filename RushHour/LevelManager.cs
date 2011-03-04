using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
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
    public class LevelManager : DrawableGameComponent {
        SpriteBatch batch;
        DirectoryInfo levelDirectory;
        List<FileInfo> levels;
        NextButton nb;
        PrevButton pb;
        ResetButton rb;
        int pos = 0;

        public LevelManager(Game Game)
            : base(Game) {
            batch = new SpriteBatch(Game.GraphicsDevice);
            levelDirectory = new DirectoryInfo("data");
            levels = new List<FileInfo>(levelDirectory.GetFiles("*.rhl"));
            initButtons();

            getLevel(0);
        }

        void initButtons() {
            int HomeX = 103;

            pb = new PrevButton(Game.Content);
            pb.AddKeys(Keys.Left, Keys.A);
            pb.Location = new Vector2(HomeX, 475);
            pb.Clicked += (s, e) => MovePrev();

            rb = new ResetButton(Game.Content);
            rb.AddKeys(Keys.Space);
            rb.Location = new Vector2(HomeX + 150, 475);
            rb.Clicked += (s, e) => ResetCurrentLevel();

            nb = new NextButton(Game.Content);
            nb.AddKeys(Keys.Right, Keys.D);
            nb.Location = new Vector2(HomeX + 300, 475);
            nb.Clicked += (s, e) => MoveNext();
        }
        void getLevel(int level) {
            if(level >= levels.Count)
                level = 0;
            if(level < 0)
                level = levels.Count - 1;

            XDocument lvlDoc = XDocument.Load(levels[level].FullName);
            CurrentLevel = GameLevel.Load(Game, lvlDoc);
            pos = level;
        }

        public void MoveNext() {
            getLevel(++pos);
        }
        public void MovePrev() {
            getLevel(--pos);
        }
        public void ResetCurrentLevel() {
            getLevel(pos);
        }

        public override void Draw(GameTime gameTime) {
            if(CurrentLevel != null) {
                batch.Begin();
                CurrentLevel.Draw(batch);
                if(!CurrentLevel.Paused) {
                    nb.Draw(batch);
                    pb.Draw(batch);
                    rb.Draw(batch);
                }
                batch.End();
            }
            base.Draw(gameTime);
        }
        public override void Update(GameTime gameTime) {
            if(CurrentLevel != null) {

                if(CurrentLevel.LevelComplete) {
                    MoveNext();
                }

                CurrentLevel.Update(gameTime);
                if(!CurrentLevel.Paused) {
                    nb.Update(gameTime, Rectangle.Empty);
                    pb.Update(gameTime, Rectangle.Empty);
                    rb.Update(gameTime, Rectangle.Empty);
                }
            }
            base.Update(gameTime);
        }
        public GameLevel CurrentLevel {
            get;
            private set;
        }
    }
}
