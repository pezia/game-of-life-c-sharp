using GoL;
using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoL_CLI
{
    class Program
    {
        private static Random random = new Random();
        
        static void Main(string[] args)
        {
            int outputWidth = 1280;
            int outputHeight = 720;
            int generationCount = 1500;

            if (args.Length != 1)
            {
                Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " <path_to_starting_figure>");
                return;
            }

            GameSolver<Cell> solver = new GameSolver<Cell>();
            WorldConverter converter = new WorldConverter();
            List<long> timingData = new List<long>(300);
            World<Cell> world = converter.fromString(System.IO.File.ReadAllText(args[0]));
            AviWriter avi = new AviWriter("out.avi") { FramesPerSecond = 30 };
            IVideoEncoder encoder = new MotionJpegVideoEncoderWpf(outputWidth, outputHeight, 100);
            IAviVideoStream vs = avi.AddVideoStream().WithEncoder(encoder);
            byte[] frameBuffer = new byte[outputWidth * outputHeight * 4];

            for (int i = 0; i < generationCount; i++)
            {
                Bitmap image = new Bitmap(outputWidth, outputHeight);
                int start = Environment.TickCount;
                world = solver.evolve(world);
                timingData.Add(Environment.TickCount - start);

                worldToBitmap(world, image);

                BitmapData bd = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
                Marshal.Copy(bd.Scan0, frameBuffer, 0, frameBuffer.Length);
                vs.WriteFrame(true, frameBuffer, 0, frameBuffer.Length);
                image.UnlockBits(bd);
                bd = null;
                image.Dispose();

                if (i % 10 == 0)
                    Console.Write('x');
                else
                    Console.Write('.');
            }

            avi.Close();

            Console.WriteLine("\n{0}ms average evolve time, {1} steps", timingData.Average(), timingData.Count);
            Console.WriteLine("{0}ms min. evolve time", timingData.Min());
            Console.WriteLine("{0}ms max. evolve time", timingData.Max());
        }

        static Image worldToBitmap(World<Cell> world, Image image)
        {
            Graphics imageGraphics = Graphics.FromImage(image);
            int offsetX = (int)Math.Floor(image.Width / 2.0);
            int offsetY = (int)Math.Floor(image.Height / 2.0);

            foreach (Cell cell in world)
            {
                imageGraphics.FillRectangle(Brushes.White, cell.X + offsetX, cell.Y + offsetY, 1, 1);
            }

            return image;
        }
    }
}
