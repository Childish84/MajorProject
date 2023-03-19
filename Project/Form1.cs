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
            Program.loadPalete("default.bin");
        }

        private void refresh()
        {
            TileBmp = Tile.List[(int)tileID.Value].ToBMP((int)paleteLine.Value, tileHflip.Checked, tileVflip.Checked);
            currentTile.Refresh();

            BlockBmp = Block.List[(int)blockID.Value].ToBMP(blockHflip.Checked, blockVflip.Checked);
            currentBlock.Refresh();

            ChunkBmp = Chunk.List[(int)ChunkID.Value].ToBMP(chunkHflip.Checked, chunkVflip.Checked);
            currentChunk.Refresh();
        }

        private void loadTiles_Click(object sender, EventArgs e)
        {
            
            var fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                Tile.clear();
                Tile.Load(fileExplorer.FileName);
                tileID.Maximum = Tile.List.Count - 1;
                refresh();
            }
        }
        private void loadPal_Click(object sender, EventArgs e)
        {
            var fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                Program.loadPalete(fileExplorer.FileName);
                refresh();
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
                refresh();
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
                refresh();
            }
        }


        private void tileID_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void paleteLine_ValueChanged(object sender, EventArgs e)
        {

            refresh();
        }

        private void tileHflip_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void tileVflip_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void blockID_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }
        

        private void blockHflip_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void blockVflip_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void ChunkID_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void chunkHflip_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void chunkVflip_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
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

        private void currentChunk_MouseClick(object sender, MouseEventArgs e)
        {
            int clickedBlockX = Math.Abs(Convert.ToInt32(chunkHflip.Checked)*7 - e.X / 32);
            int clickedBlockY = Math.Abs(Convert.ToInt32(chunkVflip.Checked)*7 - e.Y / 32);

            int blocknumber = (clickedBlockY * 8) + clickedBlockX;

            bool Vflip = Convert.ToBoolean((Chunk.List[(int)ChunkID.Value].data[blocknumber * 2] & 0b0000_1000) >> 3);
            bool Hflip = Convert.ToBoolean((Chunk.List[(int)ChunkID.Value].data[blocknumber * 2] & 0b0000_0100) >> 2);
            int block = (Chunk.List[(int)ChunkID.Value].data[blocknumber * 2] & 0b0000_0011) << 8;
            block += Chunk.List[(int)ChunkID.Value].data[blocknumber * 2 + 1];

            blockID.Value = block;
            blockHflip.Checked = Hflip;
            blockVflip.Checked = Vflip;
        }

        private void currentBlock_MouseClick(object sender, MouseEventArgs e)
        {
            int clickedTileX = Math.Abs(Convert.ToInt32(blockHflip.Checked) - e.X / 80);
            int clickedTileY = Math.Abs(Convert.ToInt32(blockVflip.Checked) - e.Y / 80);

            int tilenumber = (clickedTileY * 2) + clickedTileX;

            int palete = (Block.List[(int)blockID.Value].data[tilenumber * 2] & 0b0110_0000) >> 5;
            bool Vflip = Convert.ToBoolean((Block.List[(int)blockID.Value].data[tilenumber * 2] & 0b0001_0000) >> 4);
            bool Hflip = Convert.ToBoolean((Block.List[(int)blockID.Value].data[tilenumber * 2] & 0b0000_1000) >> 3);

            int tile = (Block.List[(int)blockID.Value].data[tilenumber * 2] & 0b0000_0111) << 8;
            tile += Block.List[(int)blockID.Value].data[tilenumber * 2 + 1];

            tileID.Value = tile;
            tileHflip.Checked = Hflip;
            tileVflip.Checked = Vflip;
            paleteLine.Value = palete;        
        }
    }
}
