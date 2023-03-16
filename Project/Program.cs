using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Collections;
using System.Drawing.Text;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlTypes;
using static Project.Program;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Data;

namespace Project
{
    internal static class Program
    {
        public static Color[,] paletes = new Color[16, 4];
        public static int bytesUncompressed = 0;
        public static byte[] Kos_Buffer = new byte[0xFFFF];
        public static Tile test = new Tile();
        public static Block defaultBlock = new Block();
        public static Chunk defaultChunk = new Chunk();



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static byte[] ConvertToNibbles(byte[] byteArray)
        {
            byte[] nibbleArray = new byte[byteArray.Length * 2];
            int index = 0;

            foreach (byte b in byteArray)
            {
                nibbleArray[index++] = (byte)(b >> 4); // take the high 4 bits
                nibbleArray[index++] = (byte)(b & 0x0F); // take the low 4 bits
            }

            return nibbleArray;
        }

        public static void loadPalete(string path)
        {
            int[] c = new int[]
            {
                0x00,
                0x34,
                0x57,
                0x74,
                0x90,
                0xAC,
                0xCE,
                0xFF
            };

            byte[] CRAM = File.ReadAllBytes(path);

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 16; i++)
                {
                    int blue = CRAM[i * 2 + (j * 0x20)] & 0x0F;
                    int green = CRAM[i * 2 + 1 + (j * 0x20)] >> 4;
                    int red = CRAM[i * 2 + 1 + (+j * 0x20)] & 0x0F;

                    paletes[i, j+1] = Color.FromArgb(0xFF, c[red >> 1], c[green >> 1], c[blue >> 1]);
                }
            }
        }



        public static void Kos_Decomp(byte[] source)
        {
            int counter;
            short descriptor;
            int bytesToCopy;
            bool done = false;
            int offset;
            int sourcePos = 0;
            int bufferPos = 0;
            bytesUncompressed= 0;
            foreach(byte b in Kos_Buffer)
            {
                Kos_Buffer[b] = 0;
            }

            descriptor = (BitConverter.ToInt16(source, sourcePos)); sourcePos += 2;
            counter = 0xF;
            //Console.WriteLine(Convert.ToString(descriptor, 2).PadLeft(16, '0'));



            while (done == false)
            {
                if (Kos_Decomp_GetBit() == 1)
                {
                    //Console.WriteLine(source[sourcePos].ToString("X2"));
                    Kos_Buffer[(uint)bufferPos] = source[sourcePos]; sourcePos++; bufferPos++;    // it is uncompressed and can be copied as is
                    bytesUncompressed++;
                }
                else
                {
                    Kos_Decomp_Match();
                }
            }
            Console.WriteLine("done");
            return;


            void Kos_Decomp_Match()
            {
                if (Kos_Decomp_GetBit() == 0)   // Inline match is indicated by 00XX where XX is the amount of bytes to copy  - 2
                {
                    bytesToCopy = (Kos_Decomp_GetBit() << 1) + Kos_Decomp_GetBit() + 2;
                    offset = source[sourcePos] - 256; sourcePos++;    //work out offset
                }
                else
                {
                    //01 indicates full match

                    byte lowByte = source[sourcePos]; sourcePos++;
                    byte highByte = source[sourcePos]; sourcePos++;

                    //regardless of format offset is calculated the same


                    offset = -8192 + (highByte >> 3) * 256 + (byte)lowByte; //-8192 + HHHHH * 256 + LLLL_LLLL

                    //Console.WriteLine("stuff" + offset);
                    //Console.WriteLine(lowByte.ToString("X") + highByte.ToString("X"));

                    if ((highByte & 0b0000_0111) != 0)   //last 3 bits of the highByte are set, use 2byte format
                    {
                        bytesToCopy = (highByte & 0b0000_0111) + 2;
                        //Console.WriteLine(bytesToCopy);
                    }
                    else//last 3 bits of the highByte are unset use 3byte format               
                    {
                        byte thirdByte = source[sourcePos]; sourcePos++;
                        bytesToCopy = thirdByte + 1;

                        if (thirdByte == 0)
                        {
                            done = true;
                        }
                        if (thirdByte == 1)
                        {
                            Console.WriteLine("stuff");
                            Console.ReadKey();
                            descriptor = (BitConverter.ToInt16(source, sourcePos)); sourcePos += 2;
                            counter = 0xF;
                        }
                    }
                }
                if(offset > 0)
                {
                    Console.WriteLine("ERROR offset can't be positive");
                    Console.ReadKey();
                }
                
                while (bytesToCopy > 0)     //copy data acordingly
                {
                    try
                    {
                        Kos_Buffer[bufferPos] = Kos_Buffer[bufferPos + offset]; bufferPos++;
                        bytesToCopy--;
                        bytesUncompressed++;
                    }
                    catch
                    {
                        Console.WriteLine("ERROR offset was: " + offset + "destination was: " + bufferPos);
                    }

                }
            }

            int Kos_Decomp_GetBit()
            {


                int lowestBit = (descriptor & 1);  // read lowest bit
                descriptor >>= 1;               // shift descriptor over 1 bit ready for next read
                counter--;

                if (counter <= -1)  // get next description field if needed
                {
                    descriptor = (BitConverter.ToInt16(source, sourcePos)); sourcePos += 2;
                    counter = 0xF;

                }

                return (lowestBit);
            }
  
        }
        

    }

}

