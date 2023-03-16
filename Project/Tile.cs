using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Tile : IDisposable
    {
        public int ID { get; private set; }

        private byte[] data { get; } = new byte[64];
        
        public Tile()
        {
            ID = List.Count();
            Console.WriteLine("making tile " + ID);
            Array.Copy(Program.Kos_Buffer, ID * 0x20, data, 0, 0x20);
            data = Program.ConvertToNibbles(data);
            List.Add(this);
        }
        static public void Load(string path)
        {
            Program.Kos_Decomp(File.ReadAllBytes(path));

            while (Tile.List.Count() < Program.bytesUncompressed / 0x20 - 1)
            {
                new Tile();
            }
        }
        public static void clear()
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
        public static List<Tile> List { get; } = new List<Tile>();

        public Bitmap ToBMP(int palLine, bool hFlip, bool vFlip)
        {
            Bitmap bmp = new Bitmap(8, 8);
            int palIndex;
            int pixelToDraw = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)      //write a line
                {
                    palIndex = this.data[pixelToDraw];
                    Brush brush = new SolidBrush(Program.paletes[palIndex, palLine]);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.FillRectangle(brush, x, y, 1, 1);
                    }
                    pixelToDraw++;
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
