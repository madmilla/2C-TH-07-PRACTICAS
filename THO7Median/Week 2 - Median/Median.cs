using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    class Median : VisionAlgorithm
    {
        //  Authors:  
        //  Lars Veenendaal                     1633223
        //  lars.veenendaal@student.hu.nl       TIV-2A
        //
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public Median(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);

            double bitmapWidth = returnImage.Width;      // Width of the bitmap.
            double bitmapHeight = returnImage.Height;    // Height of the bitmap.
            int bitmapW = returnImage.Width;
            int bitmapH = returnImage.Height;


            //////
            int[] green_array = new int[9];
            int[] red_array = new int[9];
            int[] blue_array = new int[9];
            Color cr;
            int edgex = (int) Math.Floor(bitmapWidth /2);
            int edgey = (int) Math.Floor(bitmapHeight /2);

            for (int x = 1; x <= (bitmapW - 2); x++)           // For every row.
            {
                for (int y = 1; y <= (bitmapH - 2); y++)        // For every pixel in a row.
                {
                   // Console.WriteLine("bitmapH:" + bitmapH + " y:" + y);
                    for (int fx = -1; fx != 2; fx++)
                    {
                        for (int fy = -1; fy != 2; fy++)
                        {
                            //Console.WriteLine("CRASH" + fx + "-" + fy);
                            cr = sourceImage.GetPixel(x + fx, y + fy);

                            green_array[(fx + 1 + fy + 1)] = cr.G;
                            red_array[(fx + 1 + fy + 1)] = cr.R;
                            blue_array[(fx + 1 + fy + 1)] = cr.B;
                        }
                    }
                    InsertionSort(green_array);
                    InsertionSort(red_array);
                    InsertionSort(blue_array);
                    returnImage.SetPixel(x, y, Color.FromArgb(red_array[4], green_array[4], blue_array[4])); 
                }
            }
            return returnImage;
        }

        public void InsertionSort(int[] Tabel)
        {
            int X;
            for (int I = 1; I < Tabel.Length; I++)
            {
                X = Tabel[I];
                while ((I - 1 >= 0) && (X < Tabel[I - 1]))
                {
                    Tabel[I] = Tabel[I - 1];
                    I--;
                }
                Tabel[I] = X;
            }
        }
    }
}
