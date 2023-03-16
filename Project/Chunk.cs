using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Chunk : IDisposable
    {
        public int ID { get; private set; }

        private byte[] data { get; } = new byte[128];
        public Chunk()
        {
            ID = List.Count;

            Array.Copy(Program.Kos_Buffer, ID * 128, data, 0, 128);

            List.Add(this);

        }
        public static List<Chunk> List { get; } = new List<Chunk>();

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

            while (List.Count < (Program.bytesUncompressed/128))
            {
                new Chunk();
            }
            Console.WriteLine(List.Count);
        }
        public Bitmap ToBMP(bool hFlip, bool vFlip)
        {
            Bitmap bmp = new Bitmap(128, 128);

            int blockToDraw = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    bool Vflip = Convert.ToBoolean((data[blockToDraw * 2] & 0b0000_1000) >> 3);
                    bool Hflip = Convert.ToBoolean((data[blockToDraw * 2] & 0b0000_0100) >> 2);
                    int blockID = (data[blockToDraw * 2] & 0b0000_0011)<<8;
                    blockID += data[blockToDraw * 2 + 1];
                    Console.WriteLine(blockID);

                    Block block;
                    if (blockID > Block.List.Count-1)
                    {
                        block = new Block();
                    }
                    else
                    {
                        block = Block.List[blockID];
                    }
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImageUnscaled(block.ToBMP(Hflip, Vflip), x * 16, y * 16);
                    }
                    blockToDraw++;
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
