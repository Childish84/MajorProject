using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class Block : IDisposable
    {
        public int ID { get; private set; }
        public byte[] data { get; private set; } = new byte[8];

        public static List<Block> List { get; } = new List<Block>();
        public Block()
        {
            ID = List.Count;
            
            Array.Copy(Program.Kos_Buffer, ID * 8, data, 0, 8);

            List.Add(this);
        }
       

        public static void Clear()
        {
            while (List.Count > 0)
            {
                List[0].Dispose();
            }
        }
        public void Dispose()
        {
            if (List.Contains(this))
            {
                List.Remove(this);
            }
        }
        public static void Load(string path)
        {
            Program.Kos_Decomp(File.ReadAllBytes(path));

            while (Block.List.Count < Program.bytesUncompressed/8)
            {
                new Block();
            }
        }
        public Bitmap ToBMP(bool hFlip, bool vFlip)
        {
            Bitmap bmp = new Bitmap(16,16);
            
            int tileToDraw = 0;
            for (int y = 0; y < 2; y++)
            {
                for (int x=0; x < 2; x++)
                {
                    int palete = (data[tileToDraw*2]&0b0110_0000)>>5;
                    bool Vflip = Convert.ToBoolean((data[tileToDraw * 2] & 0b0001_0000)>> 4);
                    bool Hflip = Convert.ToBoolean((data[tileToDraw * 2] & 0b0000_1000) >> 3);
                    int tileID = (data[tileToDraw * 2] & 0b0000_0111)<<8;
                    tileID += data[tileToDraw*2 + 1];

                    Tile tile;
                    if (tileID > Tile.List.Count-1)
                    {
                        tile = new Tile();
                    }
                    else
                    {
                        tile = Tile.List[tileID];
                    }
                    


                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImageUnscaled(tile.ToBMP(palete, Hflip, Vflip), x * 8, y * 8);
                    }
                    tileToDraw++;


                }
            }
            if (hFlip)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (vFlip)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            return bmp;
        }
    }
}
