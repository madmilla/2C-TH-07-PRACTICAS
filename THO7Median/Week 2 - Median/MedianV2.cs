
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;

    namespace THO7AlgorithmTimerApplication
    {
        class MedianV2 : VisionAlgorithm
        {
            //  Authors:  
            //  Lars Veenendaal                     1633223
            //  lars.veenendaal@student.hu.nl       TIV-2A
            //
            //  Mitchell Werensteijn                1624291
            //  mitchell.werensteijn@student.hu.nl  TIV-2A
            protected byte[][] image_data = null;
            protected byte[][] return_Image = null;
            protected int Width = 0;
            protected int Height = 0;
            protected int SearchWidth = 3;
            protected int SearchHeight = 3;

            public void prepImage(int width, int height)
            {
                image_data = new byte[height][];
                for (int y = 0; y < height; y++)
                    image_data[y] = new byte[width];
                Width = width;
                Height = height;
            }
            public byte getValue(int row, int col)
            {
                if (row < 0)
                    row = 0;
                else if (row >= Height)
                    row = Height - 1;

                if (col < 0)
                    col = 0;
                else if (col >= Width)
                    col = Width - 1;
                return image_data[row][col];
            }

            public void setValue(int row, int col, byte value)
            {
                return_Image[row][col] = value;
            }


            public MedianV2(String name) : base(name) { }
            public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
            {
                Console.Write("This version is currently broken.");
                Console.Write("At time of writing there was already a better version present.");
                Console.Write("You can ignore this one.");
                /*
                prepImage(sourceImage.Width, sourceImage.Height);
                Bitmap returnImage = new Bitmap(sourceImage);
                List<byte> neighbourhood = new List<byte>();
                int wx2 = Width / 2;
                int wy2 = Height / 2;

                for (int row = 0; row < sourceImage.Height; row++)
                {
                    for (int col = 0; col < sourceImage.Width; col++)
                    {
                        for (int r = row - wy2; r <= row + wy2; r++)
                        {
                            for (int c = col - wx2; c <= col + wx2; c++)
                            {
                                int position = TempY * bitmapData.Stride + (TempX * 4);

                                // Add the colors to the lists.
                                redValues.Add(oldValues[position]);
                                greenValues.Add(oldValues[position + 1]);
                                blueValues.Add(oldValues[position + 2]);

                                neighbourhood.Add(getValue(r, c));
                            }
                            neighbourhood.Sort();

                            setValue(row, col, neighbourhood[(Width * Height) / 2]);
                            neighbourhood.Clear();
                        }
                    }
                }
                System.Drawing.Imaging.BitmapData bmd = returnImage.LockBits(new System.Drawing.Rectangle(0, 0, Width - 1, Height - 1), System.Drawing.Imaging.ImageLockMode.WriteOnly, sourceImage.PixelFormat);
                for (int y = 0; y < bmd.Height; y++)
                {
                    System.Runtime.InteropServices.Marshal.Copy(return_Image[y], 0, new IntPtr((int)bmd.Scan0 + bmd.Stride * y), returnImage.Width);
                }
                sourceImage.UnlockBits(bmd);
                 */
                return sourceImage;
            }
        }
    }
