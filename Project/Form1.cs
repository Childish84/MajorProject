using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using static Project.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Net.Mime.MediaTypeNames;


namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap TileBmp = new Bitmap(8,8);
        Bitmap BlockBmp = new Bitmap(16,16);
        Bitmap ChunkBmp = new Bitmap(128,128);

        private void currentTile_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.DrawImage(TileBmp, 0, 0, currentTile.Width, currentTile.Height);
        }
        private void currentBlock_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.DrawImage(BlockBmp, 0, 0, currentBlock.Width, currentBlock.Height);
        }
        private void currentChunk_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.DrawImage(ChunkBmp, 0, 0, currentChunk.Width, currentChunk.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void loadTiles_Click(object sender, EventArgs e)
        {
            
            var fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                Tile.clear();
                Tile.Load(fileExplorer.FileName);
                tileID.Maximum = Tile.List.Count - 1;
            }    
        }
        private void loadPal_Click(object sender, EventArgs e)
        {
            var fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                Program.loadPalete(fileExplorer.FileName);
            }
        }
        private void loadBlock_Click(object sender, EventArgs e)
        {
            var fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                Block.Clear();
                Block.Load(fileExplorer.FileName);
                blockID.Maximum = Block.List.Count - 1;
            }

        }
        private void loadChunk_Click(object sender, EventArgs e)
        {
            
            var fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                Chunk.Clear();
                Chunk.Load(fileExplorer.FileName);
                ChunkID.Maximum = Chunk.List.Count - 1;
            }
        }


        private void tileID_ValueChanged(object sender, EventArgs e)
        {
            TileBmp = Tile.List[(int)tileID.Value].ToBMP((int)paleteLine.Value, tileHflip.Checked, tileVflip.Checked);
            currentTile.Refresh();
        }

        private void paleteLine_ValueChanged(object sender, EventArgs e)
        {

            TileBmp = Tile.List[(int)tileID.Value].ToBMP((int)paleteLine.Value, tileHflip.Checked, tileVflip.Checked);
            currentTile.Refresh();
        }

        private void tileHflip_CheckedChanged(object sender, EventArgs e)
        {
            TileBmp = Tile.List[(int)tileID.Value].ToBMP((int)paleteLine.Value, tileHflip.Checked, tileVflip.Checked);
            currentTile.Image = TileBmp;
            currentTile.Refresh();
        }
        private void tileVflip_CheckedChanged(object sender, EventArgs e)
        {
            TileBmp = Tile.List[(int)tileID.Value].ToBMP((int)paleteLine.Value, tileHflip.Checked, tileVflip.Checked);
            currentTile.Refresh();
        }

        private void blockID_ValueChanged(object sender, EventArgs e)
        {
            BlockBmp = Block.List[(int)blockID.Value].ToBMP(blockHflip.Checked, blockVflip.Checked);
            currentBlock.Refresh();
        }
        

        private void blockHflip_CheckedChanged(object sender, EventArgs e)
        {
            BlockBmp = Block.List[(int)blockID.Value].ToBMP(blockHflip.Checked, blockVflip.Checked);
            currentBlock.Refresh();
        }

        private void blockVflip_CheckedChanged(object sender, EventArgs e)
        {
            BlockBmp = Block.List[(int)blockID.Value].ToBMP(blockHflip.Checked, blockVflip.Checked);
            currentBlock.Refresh();
        }

        private void ChunkID_ValueChanged(object sender, EventArgs e)
        {
            ChunkBmp = Chunk.List[(int)ChunkID.Value].ToBMP(chunkHflip.Checked, chunkVflip.Checked);
            currentChunk.Refresh();
        }

        private void chunkHflip_CheckedChanged(object sender, EventArgs e)
        {
            ChunkBmp = Chunk.List[(int)ChunkID.Value].ToBMP(chunkHflip.Checked, chunkVflip.Checked);
            currentChunk.Refresh();
        }

        private void chunkVflip_CheckedChanged(object sender, EventArgs e)
        {
            ChunkBmp = Chunk.List[(int)ChunkID.Value].ToBMP(chunkHflip.Checked, chunkVflip.Checked);
            currentChunk.Refresh();
        }

        private void saveTile_Click(object sender, EventArgs e)
        {
            savefile(TileBmp);
        }

        private void saveBlock_Click(object sender, EventArgs e)
        {
            savefile(BlockBmp);
        }

        private void saveChunk_Click(object sender, EventArgs e)
        {
            savefile(ChunkBmp);
        }
        private void savefile(Bitmap bmp)
        {
            var fileExplorer = new SaveFileDialog();
            fileExplorer.Filter = "JPEG Image|*.jpg|PNG Image|*.png|GIF Image|*.gif|Bitmap Image|*.bmp";
            fileExplorer.Title = "Save Image As";
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                string chosenFormat = System.IO.Path.GetExtension(fileExplorer.FileName);
                ImageFormat format = null;


                switch (chosenFormat)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }

                bmp.Save(fileExplorer.FileName);
            }
        }
    }
}
