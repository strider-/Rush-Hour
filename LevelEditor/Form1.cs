using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LevelEditor {
    public partial class Form1 : Form {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(CursorResources));
        List<Obstacle> blocks;
        Obstacle[,] usage;
        ObstacleType currentType = ObstacleType.Block1x3;
        Obstacle player = new Obstacle {
            Type = ObstacleType.Player,
            X = 1,
            Y = 2
        };

        public Form1() {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            setToolStripImages();
            clear();
        }

        void setToolStripImages() {
            foreach(ToolStripItem btn in toolStrip2.Items.OfType<ToolStripButton>()) {
                btn.Image = btn.Image.GetThumbnailImage(btn.Image.Width / 4, btn.Image.Height / 4, null, IntPtr.Zero);
                btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            }
        }
        void add(Obstacle o) {
            if(willBeValid(o)) {
                blocks.Add(o);
                for(int i = o.Y; i < o.Height + o.Y; i++) {
                    for(int j = o.X; j < o.Width + o.X; j++) {
                        usage[j, i] = o;
                    }
                }
            }
        }
        void remove(Point gridPoint) {
            Obstacle o = usage[gridPoint.X, gridPoint.Y];

            if(o != null) {
                if(o.Type == ObstacleType.Player)
                    return;

                blocks.Remove(o);
                for(int i = 0; i < 6; i++)
                    for(int j = 0; j < 6; j++)
                        if(usage[j, i] == o)
                            usage[j, i] = null;
            }
        }
        bool willBeValid(Obstacle o) {
            for(int i = o.Y; i < o.Height + o.Y; i++) {
                for(int j = o.X; j < o.Width + o.X; j++) {
                    if(i > usage.GetUpperBound(1) || j > usage.GetUpperBound(0))
                        return false;
                    if(usage[j, i] != null)
                        return false;
                }
            }
            return true;
        }
        void clear() {
            blocks = new List<Obstacle>();
            usage = new Obstacle[6, 6];
            add(player);

            txtName.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }        

        void pnlGrid_Paint(object sender, PaintEventArgs e) {
            Panel grid = (sender as Panel);

            foreach(Obstacle o in blocks) {
                e.Graphics.FillRectangle(o.Color, o.GridRect);
                if(o.Width > o.Height)
                    e.Graphics.FillRectangle(Brushes.White, o.GridRect.X + 32, o.GridRect.Y + (o.GridRect.Height / 2), o.GridRect.Width - 64, 2);
                else
                    e.Graphics.FillRectangle(Brushes.White, o.GridRect.X + (o.GridRect.Width / 2), o.GridRect.Y + 32, 2, o.GridRect.Height - 64);
            }

            for(int i = 64; i < grid.Width; i += 64) {
                e.Graphics.DrawLine(Pens.Black, new Point(i, 0), new Point(i, grid.Height));
                e.Graphics.DrawLine(Pens.Black, new Point(0, i), new Point(grid.Width, i));
            }
        }
        void pnlGrid_MouseDown(object sender, MouseEventArgs e) {
            Point gridPoint = new Point(e.X / 64, e.Y / 64);

            if(gridPoint.X < 0)
                gridPoint.X = 0;
            if(gridPoint.X > 5)
                gridPoint.X = 5;
            if(gridPoint.Y < 0)
                gridPoint.Y = 0;
            if(gridPoint.Y > 5)
                gridPoint.Y = 5;

            if(e.Button == MouseButtons.Left) {
                add(new Obstacle {
                    Type = currentType,
                    X = gridPoint.X,
                    Y = gridPoint.Y
                });
            } else if(e.Button == MouseButtons.Right) {
                remove(gridPoint);
            }

            pnlGrid.Refresh();
        }
        void typeSelected(object sender, EventArgs e) {
            btn1x3.Checked = false;
            btn1x2.Checked = false;
            btn3x1.Checked = false;
            btn2x1.Checked = false;

            (sender as ToolStripButton).Checked = true;
            currentType = (ObstacleType)Enum.Parse(typeof(ObstacleType), (sender as ToolStripButton).Tag.ToString());
        }

        void btnNew_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Discard current level?", "Create New", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(result == DialogResult.Yes) {
                clear();
                pnlGrid.Refresh();
            }
        }
        void btnOpen_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Rush Hour Levels|*.rhl";
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK) {
                clear();

                XDocument level = XDocument.Load(ofd.FileName);
                XElement info = level.Root.Element("Level").Element("Info");
                
                txtName.Text = info.Element("Name").Value;
                txtAuthor.Text = info.Element("Author").Value;
                txtDescription.Text = info.Element("Description").Value;

                foreach(var ob in level.Root.Element("Level").Elements("Obstacle").Select(o =>
                        new Obstacle {
                            Type = (ObstacleType)Enum.Parse(typeof(ObstacleType), o.Element("Type").Value),
                            X = int.Parse(o.Element("X").Value),
                            Y = int.Parse(o.Element("Y").Value)
                        })) {
                    add(ob);
                }

                pnlGrid.Refresh();
            }
        }
        void btnSave_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rush Hour Levels|*.rhl";
            sfd.AddExtension = true;
            sfd.OverwritePrompt = true;

            if(string.IsNullOrEmpty(txtName.Text.Trim())) {
                MessageBox.Show("You must specify a level name before you save.", "Level Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcMain.SelectedTab = infoTab;
                txtName.Focus();
                return;
            }

            if(sfd.ShowDialog() == DialogResult.OK) {
                XDocument level = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("RushHour",
                        new XElement("Level",
                            new XElement("Info",
                                new XElement("Name", txtName.Text),
                                new XElement("Author", txtAuthor.Text),
                                new XElement("Description", txtDescription.Text)
                            ),
                            from o in blocks
                            where o.Type != ObstacleType.Player
                            select new XElement("Obstacle",
                                new XElement("Type", o.Type),
                                new XElement("X", o.X),
                                new XElement("Y", o.Y)
                            )
                        )
                    )
                );

                level.Save(sfd.FileName);
            }
        }

        void pnlGrid_MouseEnter(object sender, EventArgs e) {
            Bitmap bmp = (Bitmap)resources.GetObject(currentType.ToString());
            Bitmap resizedBmp = (Bitmap)bmp.GetThumbnailImage(bmp.Width / 8, bmp.Height / 8, null, IntPtr.Zero);

            this.Cursor = new Cursor(resizedBmp.GetHicon());
        }
        void pnlGrid_MouseLeave(object sender, EventArgs e) {
            this.Cursor = Cursors.Default;
        }
    }

    enum ObstacleType {
        Block1x3, Block1x2, Block3x1, Block2x1, Player
    };
    class Obstacle {
        public ObstacleType Type {
            get;
            set;
        }
        public int X {
            get;
            set;
        }
        public int Y {
            get;
            set;
        }
        public Rectangle GridRect {
            get {
                int width;
                int height;

                switch(Type) {
                    case ObstacleType.Block1x3:
                        width = 64;
                        height = 64 * 3;
                        break;
                    case ObstacleType.Block1x2:
                        width = 64;
                        height = 64 * 2;
                        break;
                    case ObstacleType.Block3x1:
                        width = 64 * 3;
                        height = 64;
                        break;
                    case ObstacleType.Block2x1:
                    case ObstacleType.Player:
                        width = 64 * 2;
                        height = 64;
                        break;
                    default:
                        width = 0;
                        height = 0;
                        break;
                }

                return new Rectangle(X * 64, Y * 64, width, height);
            }
        }
        public Brush Color {
            get {
                switch(Type) {
                    case ObstacleType.Block1x2:
                    case ObstacleType.Block2x1:
                        return Brushes.SteelBlue;
                    case ObstacleType.Block1x3:
                    case ObstacleType.Block3x1:
                        return Brushes.LightSteelBlue;
                    case ObstacleType.Player:
                        return Brushes.DarkGray;
                    default:
                        return Brushes.White;
                }
            }
        }
        public int Width {
            get {
                return GridRect.Width / 64;
            }
        }
        public int Height {
            get {
                return GridRect.Height / 64;
            }
        }
    }
}
